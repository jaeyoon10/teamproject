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
        public 보고서()
        {
            InitializeComponent();
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
    }
}
