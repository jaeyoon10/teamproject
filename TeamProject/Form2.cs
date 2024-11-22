using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace TeamProject
{
    public partial class Form2 : Form
    {
        private int registrationId = -1; // 기본값: 추가 모드
        private DBClass db;

        public Form2(int registrationId = -1)
        {
            InitializeComponent();
            this.registrationId = registrationId;
            db = new DBClass();
            db.DB_Open(); // DB 연결
            InitializeFields(); // 필드 초기화
            if (registrationId != -1)
                LoadRegistrationData(registrationId); // 수정 모드일 경우 데이터 로드
        }

        private void InitializeFields()
        {
            // 카테고리 초기화
            카테고리.DataSource = new string[] { "음료", "스낵", "즉석식품", "유제품", "가공식품", "생활용품", "주류", "담배", "뷰티", "기타" };
            카테고리.SelectedIndex = 0; // 기본값 설정
        }

        private void LoadRegistrationData(int registrationId)
        {
            try
            {
                string query = $"SELECT r.*, s.name AS supplier_name FROM registration r LEFT JOIN supplier s ON r.supplier_id = s.supplier_id WHERE r.registration_id = {registrationId}";
                OracleDataAdapter adapter = new OracleDataAdapter(query, db.DBAdapter.SelectCommand.Connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    등록ID.Text = row["registration_id"].ToString();
                    상품이름.Text = row["product_name"].ToString();
                    등록가격.Text = row["registration_price"].ToString();
                    공급업체.Text = row["supplier_name"].ToString(); // 공급업체 이름 표시
                    카테고리.SelectedItem = row["category"].ToString();
                    유통기한.Value = Convert.ToDateTime(row["expiration_date"]);
                    비고.Text = row["remarks"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 로드 중 오류 발생: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 등록버튼_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return; // 유효성 검사

            try
            {
                // 공급업체 이름으로 ID 조회
                int supplierId = GetSupplierIdByName(공급업체.Text);
                if (supplierId == -1)
                {
                    MessageBox.Show("유효한 공급업체 이름을 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query;
                if (registrationId == -1)
                {
                    // 추가 모드
                    query = $@"
                    INSERT INTO registration (registration_id, registration_date, product_name, registration_price, category, remarks, storeowner_id, supplier_id, expiration_date)
                    VALUES (
                        {등록ID.Text},
                        TO_DATE('{유통기한.Value:yyyy-MM-dd}', 'YYYY-MM-DD'),
                        '{상품이름.Text}',
                        {등록가격.Text},
                        '{카테고리.SelectedItem}',
                        '{비고.Text}',
                        1, -- 점주 ID는 고정값
                        {supplierId}
                    )";
                }
                else
                {
                    // 수정 모드
                    query = $@"
                    UPDATE registration
                    SET 
                        registration_date = TO_DATE('{유통기한.Value:yyyy-MM-dd}', 'YYYY-MM-DD'),
                        product_name = '{상품이름.Text}',
                        registration_price = {등록가격.Text},
                        category = '{카테고리.SelectedItem}',
                        remarks = '{비고.Text}',
                        supplier_id = {supplierId}
                    WHERE registration_id = {registrationId}";
                }

                OracleCommand cmd = new OracleCommand(query, db.DBAdapter.SelectCommand.Connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("성공적으로 저장되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("저장 중 오류 발생: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSupplierIdByName(string supplierName)
        {
            try
            {
                string query = "SELECT supplier_id FROM supplier WHERE name = :supplierName";
                OracleCommand cmd = new OracleCommand(query, db.DBAdapter.SelectCommand.Connection);
                cmd.Parameters.Add(new OracleParameter("supplierName", supplierName));

                object result = cmd.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result); // 유효한 경우 supplier_id 반환
                else
                    return -1; // 유효하지 않은 경우
            }
            catch (Exception ex)
            {
                MessageBox.Show("공급업체 이름 확인 중 오류 발생: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            return true;
        }
    }
}
