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
        private Timer weeklyTimer; // 타이머 추가


        public 보고서()
        {
            InitializeComponent();
            dbClass = new DBClass(); // DBClass 객체 초기화
            SetupWeeklyTimer(); // 주간 보고서 초기화를 위한 타이머 설정
            LoadReportData();
        }
        private void LoadReportData(string category = null)
        {
            try
            {
                // 카테고리 필터 쿼리 생성
                string filterQuery = "";
                if (!string.IsNullOrEmpty(category) && category != "전체")
                {
                    filterQuery = $"WHERE category = '{category}'";
                }

                // 보고서 데이터 가져오기
                DataTable reportData = dbClass.GetReportData(filterQuery);
                dataGridView1.DataSource = reportData;

                // 총 판매 수량 및 총 판매 금액 계산
                int totalQuantity = 0;
                decimal totalAmount = 0;

                foreach (DataRow row in reportData.Rows)
                {
                    totalQuantity += Convert.ToInt32(row["총판매수량"]);
                    totalAmount += Convert.ToDecimal(row["총판매금액"]);
                }

                // 레이블 업데이트
                label1.Text = totalQuantity.ToString(); // 총 판매 수량
                label2.Text = $"{totalAmount:C}";       // 총 판매 금액 (원화 형식)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"보고서 데이터를 로드하는 중 오류 발생: {ex.Message}");
            }
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
            string categoryFilter = comboBox1.SelectedItem?.ToString();

            try
            {
                // DBClass에서 보고서 데이터 조회
                string filterQuery = categoryFilter != "전체" ? $"WHERE category = '{categoryFilter}'" : "";

                DataTable reportData = dbClass.GetReportData(filterQuery);

                if (reportData.Rows.Count > 0)
                {
                    dataGridView1.DataSource = reportData;

                    // 총 판매 수량 및 총 판매 금액 계산
                    int totalQuantity = reportData.AsEnumerable().Sum(row => row.Field<int>("total_quantity"));
                    decimal totalAmount = reportData.AsEnumerable().Sum(row => row.Field<decimal>("total_amount"));

                    // Label 업데이트
                    label1.Text = totalQuantity.ToString(); // 총 판매 수량
                    label2.Text = $"{totalAmount:C}"; // 총 판매 금액
                }
                else
                {
                    // 데이터가 없으면 초기화
                    dataGridView1.DataSource = null;
                    label1.Text = "0";
                    label2.Text = "₩0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"보고서 데이터를 불러오는 중 오류 발생: {ex.Message}");
            }
        }

        private void weekly_Click(object sender, EventArgs e)
        {
            try
            {
                // DBClass에서 지난주 보고서 데이터를 조회
                DataTable lastWeekData = dbClass.GetLastWeekReport();

                if (lastWeekData.Rows.Count > 0)
                {
                    // DataGridView에 조회된 데이터 설정
                    dataGridView1.DataSource = lastWeekData;
                }
                else
                {
                    MessageBox.Show("지난주 보고서 데이터가 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"지난주 보고서를 불러오는 중 오류 발생: {ex.Message}");
            }
        }
        private void SetupWeeklyTimer()
        {
            weeklyTimer = new Timer();
            weeklyTimer.Interval = 60000; // 1분 간격으로 체크

            weeklyTimer.Tick += (s, e) =>
            {
                DateTime now = DateTime.Now;
                // 일요일 23:59인지 확인
                if (now.DayOfWeek == DayOfWeek.Sunday && now.Hour == 23 && now.Minute == 59)
                {
                    dbClass.SaveWeeklyReport(); // 보고서 초기화 및 저장
                }
            };

            weeklyTimer.Start();
        }

        public void RefreshReport()
        {
            try
            {
                // DBClass에서 주간 보고서 데이터를 조회
                DataTable reportData = dbClass.GetReportData();

                if (reportData.Rows.Count > 0)
                {
                    // DataGridView에 조회된 보고서 데이터 설정
                    dataGridView1.DataSource = reportData;

                    // 총 판매 수량 및 총 판매 금액 계산
                    int totalQuantity = 0;
                    decimal totalAmount = 0;

                    foreach (DataRow row in reportData.Rows)
                    {
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
                MessageBox.Show($"보고서를 새로고침하는 중 오류 발생: {ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedCategory = comboBox1.SelectedItem?.ToString() ?? "전체";
                LoadReportData(selectedCategory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"카테고리 선택 중 오류 발생: {ex.Message}");
            }
        }
    }
}