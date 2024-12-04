using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject
{
    public partial class 수정창 : Form
    {
        private int registrationId;
        private DBClass db;

        public 수정창(int registrationId)
        {
            InitializeComponent();
            this.registrationId = registrationId;
            db = new DBClass();
            db.DB_Open();
            LoadRegistrationData();
        }

        private void LoadRegistrationData()
        {
            try
            {
                string query = @"
            SELECT r.*, s.name AS supplier_name, st.stock_quantity 
            FROM registration r 
            LEFT JOIN supplier s ON r.supplier_id = s.supplier_id 
            LEFT JOIN stock st ON r.registration_id = st.registration_id
            WHERE r.registration_id = :registrationId";

                using (OracleCommand cmd = new OracleCommand(query, db.Connection))
                {
                    cmd.Parameters.Add(new OracleParameter("registrationId", registrationId));
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            상품이름.Text = row["product_name"].ToString();
                            등록가격.Text = row["registration_price"].ToString();
                            카테고리.SelectedItem = row["category"].ToString();
                            유통기한.Value = Convert.ToDateTime(row["expiration_date"]);
                            비고.Text = row["remarks"].ToString();
                            상품수량.Text = row["stock_quantity"].ToString(); // 수량 표시
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 로드 중 오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 수정버튼_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                string registrationQuery = @"
    UPDATE registration
    SET 
        product_name = :productName,
        registration_price = :registrationPrice,
        category = :category,
        remarks = :remarks,
        expiration_date = TO_DATE(:expirationDate, 'YYYY-MM-DD')
    WHERE registration_id = :registrationId";

                string stockQuery = @"
    UPDATE stock
    SET 
        stock_quantity = :stockQuantity
    WHERE registration_id = :registrationId";

                db.DB_Open();
                using (OracleCommand cmd = new OracleCommand(registrationQuery, db.Connection))
                {
                    cmd.Parameters.Add(new OracleParameter("productName", 상품이름.Text.Trim()));
                    cmd.Parameters.Add(new OracleParameter("registrationPrice", decimal.Parse(등록가격.Text.Trim())));
                    cmd.Parameters.Add(new OracleParameter("category", 카테고리.SelectedItem.ToString()));
                    cmd.Parameters.Add(new OracleParameter("remarks", 비고.Text.Trim()));
                    cmd.Parameters.Add(new OracleParameter("expirationDate", 유통기한.Value.ToString("yyyy-MM-dd")));
                    cmd.Parameters.Add(new OracleParameter("registrationId", registrationId));

                    cmd.ExecuteNonQuery();
                }

                using (OracleCommand stockCmd = new OracleCommand(stockQuery, db.Connection))
                {
                    stockCmd.Parameters.Add(new OracleParameter("stockQuantity", int.Parse(상품수량.Text.Trim())));
                    stockCmd.Parameters.Add(new OracleParameter("registrationId", registrationId));
                    stockCmd.ExecuteNonQuery();
                }

                MessageBox.Show("수정이 완료되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Owner is 상품재고관리 parentForm)
                {
                    parentForm.LoadRegistrationData(); // 부모 폼 새로고침
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"수정 중 오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.DB_Close();
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

            if (카테고리.SelectedItem == null)
            {
                MessageBox.Show("카테고리를 선택하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                카테고리.Focus();
                return false;
            }

            if (유통기한.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("유통기한은 오늘 이후 날짜여야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                유통기한.Focus();
                return false;
            }

            return true;
        }
    }
}