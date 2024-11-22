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
    public partial class Form7 : Form
    {
        private string productName;
        private int stockId;

        public Form7(string productName, int stockId)
        {
            InitializeComponent();
            this.productName = productName;
            this.stockId = stockId;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label3.Text = productName; // 상품명 표시
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string memberName = txtMemberName.Text;
            int saleQuantity;

            if (string.IsNullOrWhiteSpace(memberName))
            {
                MessageBox.Show("회원 이름을 입력하세요.");
                return;
            }

            if (!int.TryParse(txtSaleQuantity.Text, out saleQuantity) || saleQuantity <= 0)
            {
                MessageBox.Show("판매 수량은 0보다 큰 숫자여야 합니다.");
                return;
            }

            using (var connection = new OracleConnection("Your Connection String"))
            {
                connection.Open();

                // 회원 ID 및 카드 번호 조회
                string memberQuery = "SELECT member_id, card_number FROM member WHERE name = :name";
                OracleCommand memberCmd = new OracleCommand(memberQuery, connection);
                memberCmd.Parameters.Add(new OracleParameter(":name", memberName));

                OracleDataReader reader = memberCmd.ExecuteReader();
                if (reader.Read())
                {
                    int memberId = reader.GetInt32(0);
                    string cardNumber = reader.GetString(1);

                    // 판매 기록 삽입
                    string salesInsertQuery = @"
                    INSERT INTO sales_history (sales_id, sale_time, quantity, total_sales_amount, stock_id, member_id)
                    VALUES (sales_seq.NEXTVAL, SYSDATE, :quantity, :totalSalesAmount, :stockId, :memberId)";

                    OracleCommand salesCmd = new OracleCommand(salesInsertQuery, connection);
                    salesCmd.Parameters.Add(new OracleParameter(":quantity", saleQuantity));
                    salesCmd.Parameters.Add(new OracleParameter(":totalSalesAmount", saleQuantity * 1000)); // 단가 1000 가정
                    salesCmd.Parameters.Add(new OracleParameter(":stockId", stockId));
                    salesCmd.Parameters.Add(new OracleParameter(":memberId", memberId));

                    int rowsAffected = salesCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"판매가 완료되었습니다.\n회원 카드 번호: {cardNumber}");
                    }
                }
                else
                {
                    MessageBox.Show("입력한 회원 이름을 찾을 수 없습니다.");
                }
            }

            this.Close(); // 판매 창 닫기
        }
    }
}

