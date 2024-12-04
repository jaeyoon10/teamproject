using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace TeamProject
{
    public partial class Form2 : Form
    {
        private int storeOwnerId;
        private DBClass db;

        public Form2(int storeOwnerId)
        {
            InitializeComponent();
            this.storeOwnerId = storeOwnerId; // 점주 ID 설정
            db = new DBClass();
            db.DB_Open(); // DB 연결
            InitializeFields(); // 필드 초기화
        }

        private void InitializeFields()
        {
            카테고리.DataSource = new string[] { "음료", "스낵", "즉석식품", "유제품", "가공식품", "생활용품", "주류", "담배", "뷰티", "기타" };
            카테고리.SelectedIndex = 0;
        }

        private void 등록버튼_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                int supplierId = GetOrAddSupplierId(공급업체.Text);
                if (supplierId == -1)
                {
                    MessageBox.Show("유효한 공급업체 이름을 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int registrationId = db.GetNextRegistrationId();
                int stockQuantity = int.Parse(상품수량.Text.Trim()); // 입력된 수량

                string registrationQuery = $@"
        INSERT INTO registration (registration_id, product_name, registration_price, category, remarks, storeowner_id, supplier_id, expiration_date)
        VALUES (:registrationId, :productName, :registrationPrice, :category, :remarks, :storeOwnerId, :supplierId, TO_DATE(:expirationDate, 'YYYY-MM-DD'))";

                string stockQuery = $@"
        INSERT INTO stock (stock_id, stock_quantity, min_stock_quantity, registration_id)
        VALUES (stock_seq.NEXTVAL, :stockQuantity, 10, :registrationId)";

                db.DB_Open();
                using (OracleCommand cmd = new OracleCommand(registrationQuery, db.Connection))
                {
                    cmd.Parameters.Add(new OracleParameter("registrationId", registrationId));
                    cmd.Parameters.Add(new OracleParameter("productName", 상품이름.Text.Trim()));
                    cmd.Parameters.Add(new OracleParameter("registrationPrice", decimal.Parse(등록가격.Text.Trim())));
                    cmd.Parameters.Add(new OracleParameter("category", 카테고리.SelectedItem.ToString()));
                    cmd.Parameters.Add(new OracleParameter("remarks", 비고.Text.Trim()));
                    cmd.Parameters.Add(new OracleParameter("storeOwnerId", storeOwnerId));
                    cmd.Parameters.Add(new OracleParameter("supplierId", supplierId));
                    cmd.Parameters.Add(new OracleParameter("expirationDate", 유통기한.Value.ToString("yyyy-MM-dd")));

                    cmd.ExecuteNonQuery();
                }

                using (OracleCommand stockCmd = new OracleCommand(stockQuery, db.Connection))
                {
                    stockCmd.Parameters.Add(new OracleParameter("stockQuantity", stockQuantity)); // 입력된 수량
                    stockCmd.Parameters.Add(new OracleParameter("registrationId", registrationId));
                    stockCmd.ExecuteNonQuery();
                }

                MessageBox.Show("성공적으로 저장되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Owner is 상품재고관리 parentForm)
                {
                    parentForm.LoadRegistrationData(); // 부모 폼 새로고침
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"저장 중 오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.DB_Close();
            }
        }

        private int GetOrAddSupplierId(string supplierName)
        {
            try
            {
                string selectQuery = "SELECT supplier_id FROM supplier WHERE name = :supplierName";
                using (OracleCommand cmd = new OracleCommand(selectQuery, db.Connection))
                {
                    cmd.Parameters.Add(new OracleParameter("supplierName", supplierName.Trim()));

                    if (db.Connection.State != ConnectionState.Open)
                    {
                        db.Connection.Open();
                    }

                    object result = cmd.ExecuteScalar();
                    if (result != null) return Convert.ToInt32(result);
                }

                string insertQuery = "INSERT INTO supplier (supplier_id, name, contact_info) VALUES (supplier_seq.NEXTVAL, :name, 'Unknown')";
                using (OracleCommand insertCmd = new OracleCommand(insertQuery, db.Connection))
                {
                    insertCmd.Parameters.Add(new OracleParameter("name", supplierName.Trim()));
                    insertCmd.ExecuteNonQuery();
                }

                string getIdQuery = "SELECT supplier_seq.CURRVAL FROM DUAL";
                using (OracleCommand getIdCmd = new OracleCommand(getIdQuery, db.Connection))
                {
                    object newId = getIdCmd.ExecuteScalar();
                    return Convert.ToInt32(newId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"공급업체 처리 중 오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(상품이름.Text))
            {
                MessageBox.Show("상품 이름을 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                상품이름.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(등록가격.Text) || !decimal.TryParse(등록가격.Text, out _))
            {
                MessageBox.Show("유효한 등록 가격을 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                등록가격.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(공급업체.Text))
            {
                MessageBox.Show("공급업체 이름을 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                공급업체.Focus();
                return false;
            }

            if (카테고리.SelectedItem == null)
            {
                MessageBox.Show("카테고리를 선택하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                카테고리.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(상품수량.Text) || !int.TryParse(상품수량.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("유효한 수량을 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                상품수량.Focus();
                return false;
            }

            return true;
        }

        private void RefreshParentForm()
        {
            if (Owner is 상품재고관리 parentForm)
            {
                parentForm.LoadRegistrationData(); // 부모 폼의 데이터를 새로고침
            }
            else
            {
                MessageBox.Show("부모 폼을 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}