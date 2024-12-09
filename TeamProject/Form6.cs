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
            dataGridView1.AllowUserToAddRows = false; // 추가 행 제거
        }
        private void LoadReportData(string category = null)
        {
            try
            {
                string filterQuery = "";

                if (!string.IsNullOrEmpty(category) && category != "전체")
                {
                    filterQuery = $"WHERE reg.category = '{category}'";
                }

                // 판매 데이터를 가져오는 메서드 호출
                DataTable reportData = dbClass.GetReportData(filterQuery);

                if (reportData == null || reportData.Rows.Count == 0)
                {
                    MessageBox.Show("보고서 데이터가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = reportData;

                // **열 크기를 화면에 맞게 자동 조정**
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoResizeColumns();

                UpdateTotalSummary(reportData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"보고서 데이터를 로드하는 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalSummary(DataTable reportData)
        {
            try
            {
                // 총 판매 수량 및 금액 계산
                int totalQuantity = reportData.AsEnumerable()
                    .Where(row => row["판매수량"] != DBNull.Value) // NULL 값 필터링
                    .Sum(row => Convert.ToInt32(row["판매수량"])); // 안전한 캐스팅

                decimal totalAmount = reportData.AsEnumerable()
                    .Where(row => row["판매금액"] != DBNull.Value) // NULL 값 필터링
                    .Sum(row => Convert.ToDecimal(row["판매금액"])); // 안전한 캐스팅

                // 레이블에 반영
                label1.Text = totalQuantity.ToString(); // 총 판매 수량
                label2.Text = $"{totalAmount:C}"; // 총 판매 금액 (원화 형식)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"요약 데이터를 계산하는 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 카테고리 선택 시 필터 적용
            string selectedCategory = comboBox1.SelectedItem?.ToString() ?? "전체";
            LoadReportData(selectedCategory);
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

        private void SetupWeeklyTimer()
        {
            weeklyTimer = new Timer { Interval = 60000 };

            weeklyTimer.Tick += (s, e) =>
            {
                DateTime now = DateTime.Now;
                if (now.DayOfWeek == DayOfWeek.Sunday && now.Hour == 23 && now.Minute == 59)
                {
                    dbClass.SaveWeeklyReport();
                }
            };

            weeklyTimer.Start();
        }

        public void RefreshReport()
        {
            try
            {
                // 전체 데이터 로드
                LoadReportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"보고서를 새로고침하는 중 오류 발생: {ex.Message}");
            }
        }

        private void 조회_Click(object sender, EventArgs e)
        {
            try
            {
                // 카테고리 필터링하여 데이터 로드
                string selectedCategory = comboBox1.SelectedItem?.ToString() ?? "전체";
                LoadReportData(selectedCategory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"조회 중 오류 발생: {ex.Message}");
            }
        }

        private void 출력_Click(object sender, EventArgs e)
        {
            try
            {
                // PrintPreviewDialog 설정
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"출력 중 오류 발생: {ex.Message}");
            }
        }

        private void buttonlastweek_Click(object sender, EventArgs e)
        {

        }

        private void 보고서_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}