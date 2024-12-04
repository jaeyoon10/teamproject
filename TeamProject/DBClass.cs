using Oracle.DataAccess.Client;
using System.Data;
using System.Windows.Forms;
using System;

public class DBClass
{
    private OracleDataAdapter dBAdapter;
    private DataSet dS;
    private OracleCommandBuilder myCommandBuilder;
    private OracleConnection connection;
    public OracleConnection Connection
    {
        get
        {
            if (connection == null)
            {
                connection = new OracleConnection("User Id=team; Password=1234; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));");
            }
            return connection;
        }
    }
    public OracleDataAdapter DBAdapter { get { return dBAdapter; } set { dBAdapter = value; } }
    public DataSet DS { get { return dS; } set { dS = value; } }

    // 데이터베이스 연결 열기
    public void DB_Open()
    {
        try
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // 데이터베이스 연결 닫기
    public void DB_Close()
    {
        try
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Database close error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // storeowner 테이블에서 로그인 검증
    // storeowner 테이블에서 로그인 검증
    public bool ValidateStoreOwner(string storeOwnerId, string password)
    {
        try
        {
            DB_Open();

            string query = $"SELECT COUNT(*) FROM storeowner WHERE storeownerid = :storeOwnerId AND password = :password";
            using (OracleCommand cmd = new OracleCommand(query, Connection))
            {
                cmd.Parameters.Add(new OracleParameter("storeOwnerId", storeOwnerId));
                cmd.Parameters.Add(new OracleParameter("password", password));

                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result) > 0; // 로그인 성공 여부 반환
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("로그인 중 오류 발생: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        finally
        {
            DB_Close();
        }
    }



    // registration 테이블 데이터 가져오기
    public DataTable GetRegistrationData(string filterQuery = "")
    {
        DataTable registrationTable = new DataTable();
        try
        {
            DB_Open();

            string query = $@"
        SELECT 
            r.registration_id AS 등록ID,  
            r.registration_price AS 등록가격, 
            r.category AS 카테고리, 
            r.product_name AS 상품명, 
            r.expiration_date AS 유통기한, 
            r.remarks AS 비고, 
            s.name AS 공급업체명,
            st.stock_quantity AS 수량
        FROM 
            registration r
        LEFT JOIN 
            supplier s ON r.supplier_id = s.supplier_id
        LEFT JOIN 
            stock st ON r.registration_id = st.registration_id
        {filterQuery}";

            using (OracleDataAdapter adapter = new OracleDataAdapter(query, Connection))
            {
                adapter.Fill(registrationTable);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to retrieve registration data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            DB_Close();
        }
        return registrationTable;
    }



    // stock 테이블 데이터 가져오기
    public DataTable GetStockData(string filterQuery = "")
    {
        DataTable stockTable = new DataTable();
        try
        {
            string query = $@"
            SELECT 
                s.stock_id, 
                s.stock_quantity, 
                s.min_stock_quantity, 
                r.product_name, 
                r.category
            FROM 
                stock s
            JOIN 
                registration r ON s.registration_id = r.registration_id
            {filterQuery}";

            OracleDataAdapter adapter = new OracleDataAdapter(query, dBAdapter.SelectCommand.Connection);
            adapter.Fill(stockTable);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to retrieve stock data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return stockTable;
    }

    // supplier 추가 및 ID 반환
    public int GetOrAddSupplierId(string supplierName)
    {
        try
        {
            DB_Open();

            // 공급업체 ID 조회
            string selectQuery = "SELECT supplier_id FROM supplier WHERE name = :supplierName";
            using (OracleCommand cmd = new OracleCommand(selectQuery, Connection))
            {
                cmd.Parameters.Add(new OracleParameter("supplierName", supplierName));
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result); // 기존 ID 반환
                }
            }

            // 공급업체 추가
            string insertQuery = "INSERT INTO supplier (supplier_id, name, contact_info) VALUES (supplier_seq.NEXTVAL, :name, 'Unknown')";
            using (OracleCommand insertCmd = new OracleCommand(insertQuery, Connection))
            {
                insertCmd.Parameters.Add(new OracleParameter("name", supplierName));
                insertCmd.ExecuteNonQuery();
            }

            // 새로 추가된 ID 반환
            string getIdQuery = "SELECT supplier_seq.CURRVAL FROM DUAL";
            using (OracleCommand getIdCmd = new OracleCommand(getIdQuery, Connection))
            {
                object newId = getIdCmd.ExecuteScalar();
                return Convert.ToInt32(newId);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"공급업체 추가 또는 조회 중 오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }
        finally
        {
            DB_Close();
        }
    }
    // 판매 기록 저장
    public void SaveSaleRecord(string memberName, int saleQuantity, int registrationId)
    {
        try
        {
            DB_Open(); // 데이터베이스 연결 확인 및 열기

            // 회원 ID 가져오기 또는 생성
            int memberId = GetOrAddMemberId(memberName);
            if (memberId == -1)
            {
                MessageBox.Show("회원 ID를 처리할 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 판매 기록 저장
            string insertQuery = @"
            INSERT INTO sales_history (sales_id, sale_time, quantity, stock_id, member_id)
            VALUES (sales_seq.NEXTVAL, SYSDATE, :saleQuantity, 
            (SELECT stock_id FROM stock WHERE registration_id = :registrationId), :memberId)";

            using (OracleCommand cmd = new OracleCommand(insertQuery, Connection))
            {
                cmd.Parameters.Add(new OracleParameter("saleQuantity", saleQuantity));
                cmd.Parameters.Add(new OracleParameter("registrationId", registrationId));
                cmd.Parameters.Add(new OracleParameter("memberId", memberId));
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("판매 기록이 성공적으로 저장되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"판매 기록 저장 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            DB_Close(); // 데이터베이스 연결 닫기
        }
    }

    // 회원 ID 조회 및 추가
    public int GetOrAddMemberId(string memberName)
    {
        try
        {
            DB_Open(); // 데이터베이스 연결 확인 및 열기

            // 회원 ID 조회
            string selectQuery = "SELECT member_id FROM member WHERE name = :memberName";
            using (OracleCommand cmd = new OracleCommand(selectQuery, Connection))
            {
                cmd.Parameters.Add(new OracleParameter("memberName", memberName));
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result); // 기존 회원 ID 반환
                }
            }

            // 회원이 없으면 새로 추가
            string insertQuery = "INSERT INTO member (member_id, name, card_number) VALUES (member_seq.NEXTVAL, :name, '0000000000000000')";
            using (OracleCommand insertCmd = new OracleCommand(insertQuery, Connection))
            {
                insertCmd.Parameters.Add(new OracleParameter("name", memberName));
                insertCmd.ExecuteNonQuery();
            }

            // 새로 추가된 회원 ID 반환
            string getIdQuery = "SELECT member_seq.CURRVAL FROM DUAL";
            using (OracleCommand getIdCmd = new OracleCommand(getIdQuery, Connection))
            {
                object newId = getIdCmd.ExecuteScalar();
                return Convert.ToInt32(newId);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"회원 처리 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }
        finally
        {
            DB_Close(); // 데이터베이스 연결 닫기
        }
    }

    public void DeleteOutOfStockItems()
    {
        try
        {
            DB_Open();
            // stock 삭제 -> sales_history의 stock_id는 NULL로 유지됨
            string query = @"
            DELETE FROM stock 
            WHERE stock_quantity = 0";
            using (OracleCommand cmd = new OracleCommand(query, Connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"재고 0인 상품 삭제 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            DB_Close();
        }
    }

    // DBClass에 상품 삭제 메서드 추가
    public void DeleteProductAndKeepSales(int registrationId)
    {
        try
        {
            DB_Open(); // 데이터베이스 연결 열기

            // 판매 내역에서 상품에 대한 stock_id를 NULL로 업데이트 (판매 내역은 유지)
            string updateSalesHistoryQuery = @"
            UPDATE sales_history
            SET stock_id = NULL
            WHERE stock_id IN (
                SELECT stock_id FROM stock WHERE registration_id = :registration_id
            )";

            using (OracleCommand cmd = new OracleCommand(updateSalesHistoryQuery, Connection))
            {
                cmd.Parameters.Add(new OracleParameter("registration_id", registrationId)); // 파라미터 바인딩
                cmd.ExecuteNonQuery();
            }

            // 재고 테이블에서 해당 상품 삭제
            string deleteStockQuery = "DELETE FROM stock WHERE registration_id = :registration_id";
            using (OracleCommand cmd = new OracleCommand(deleteStockQuery, Connection))
            {
                cmd.Parameters.Add(new OracleParameter("registration_id", registrationId)); // 파라미터 바인딩
                cmd.ExecuteNonQuery();
            }

            // 상품 테이블에서 해당 상품 삭제
            string deleteRegistrationQuery = "DELETE FROM registration WHERE registration_id = :registration_id";
            using (OracleCommand cmd = new OracleCommand(deleteRegistrationQuery, Connection))
            {
                cmd.Parameters.Add(new OracleParameter("registration_id", registrationId)); // 파라미터 바인딩
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("상품이 삭제되었습니다. 판매 내역은 그대로 남아 있습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"상품 삭제 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            DB_Close(); // 데이터베이스 연결 닫기
        }
    }

    // 새로운 등록 ID 생성
    public int GetNextRegistrationId()
    {
        try
        {
            DB_Open();

            string query = "SELECT NVL(MAX(registration_id), 0) + 1 FROM registration";
            using (OracleCommand cmd = new OracleCommand(query, Connection))
            {
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("등록 ID 생성 중 오류 발생: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }
        finally
        {
            DB_Close();
        }
    }
}

