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
    public partial class 보고서 : Form
    {
        private DBClass dbClass;

        public 보고서()
        {
            InitializeComponent();
            dbClass = new DBClass(); // DBClass 객체 초기화
        }

        private void 출력_Click(object sender, EventArgs e)
        {
            // PrintPreviewDialog 설정
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int startX = 201; // 출력 시작 X 위치
            int startY = 62; // 출력 시작 Y 위치
            int offsetY = 30; // 각 행 간 간격
            Font font = new Font("Arial", 10);

            // DataGridView 헤더 출력
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                e.Graphics.DrawString(dataGridView1.Columns[i].HeaderText, font, Brushes.Black, startX + i * 120, startY);
            }
            startY += offsetY;

            // DataGridView 행 데이터 출력
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                DataGridViewRow dataRow = dataGridView1.Rows[row];
                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    string cellValue = dataRow.Cells[col].Value?.ToString() ?? "";
                    e.Graphics.DrawString(cellValue, font, Brushes.Black, startX + col * 120, startY);
                }
                startY += offsetY;
            }
        }

        private void Sale_text_Click(object sender, EventArgs e)
        {
            // Form5 인스턴스를 생성하고 보여줍니다.
            Form5 form5 = new Form5();

            form5.Show();

            // 현재 Form3을 숨기거나 닫습니다.
            this.Hide();
        }

        private void Pmanage_text_Click(object sender, EventArgs e)
        {
            // Form3 인스턴스를 생성하고 보여줍니다.
            상품재고관리 form3 = new 상품재고관리();

            form3.Show();

            // 현재 Form3을 숨기거나 닫습니다.
            this.Hide();
        }

        private void 조회_Click(object sender, EventArgs e)
        {
            try
            {
                // DBClass에서 보고서 데이터를 조회
                DataTable reportData = dbClass.GetReportData();

                // 데이터 확인용 디버깅 메시지
                MessageBox.Show($"조회된 데이터 행 수: {reportData.Rows.Count}");

                if (reportData.Rows.Count > 0)
                {
                    // DataGridView에 조회된 보고서 데이터 설정
                    dataGridView1.DataSource = reportData;

                    // 총 판매 수량 및 총 판매 금액 계산
                    int totalQuantity = 0;
                    decimal totalAmount = 0;

                    foreach (DataRow row in reportData.Rows)
                    {
                        // 각 데이터 행에서 판매 수량 및 금액 누적
                        totalQuantity += Convert.ToInt32(row["판매수량"]);
                        totalAmount += Convert.ToDecimal(row["판매금액"]);
                    }

                    // Label에 총 판매 수량과 총 판매 금액 표시
                    label1.Text = totalQuantity.ToString(); // 총 판매 수량
                    label2.Text = $"{totalAmount:C}"; // 총 판매 금액 (원화 형식)
                }
                else
                {
                    // 보고서 데이터가 없으면 0으로 표시
                    dataGridView1.DataSource = null; // DataGridView 초기화
                    label1.Text = "0"; // 총 판매 수량 0
                    label2.Text = "₩0"; // 총 판매 금액 0 (원화 형식)
                    MessageBox.Show("보고서 데이터가 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }
    }
}
