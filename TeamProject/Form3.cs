using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TeamProject
{
    public partial class 상품재고관리 : Form
    {
        private DBClass db;
        public 상품재고관리()
        {
            InitializeComponent();
            db = new DBClass();
            db.DB_Open(); // 데이터베이스 연결
            LoadStockData(); // 폼이 열릴 때 데이터 로드
            InitializeSearchFilters(); // 검색 필터 초기화
            InitializeContextMenu(); // ContextMenuStrip 초기화
        }

        private void LoadStockData(string filterQuery = "")
        {
            DataTable stockData = db.GetStockData(filterQuery); // 필터 쿼리 적용
            재고관리.DataSource = stockData; // DataGridView에 데이터 바인딩
        }

        private void InitializeSearchFilters()
        {
            // 카테고리 콤보박스 초기화
            카테고리.DataSource = new string[] { "전체", "음료", "스낵", "즉석식품", "유제품", "가공식품", "생활용품", "주류", "담배", "뷰티", "기타" };

            // 검색창 초기화
            검색창.ForeColor = Color.Gray;
            검색창.Text = "검색어를 입력하세요";

            검색창.Enter += (s, e) =>
            {
                if (검색창.Text == "검색어를 입력하세요")
                {
                    검색창.Text = "";
                    검색창.ForeColor = Color.Black;
                }
            };

            검색창.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(검색창.Text))
                {
                    검색창.Text = "검색어를 입력하세요";
                    검색창.ForeColor = Color.Gray;
                }
            };

            // 검색 버튼 클릭
            검색버튼.Click += (s, e) =>
            {
                string filterQuery = "WHERE 1=1";

                if (카테고리.SelectedItem.ToString() != "전체")
                    filterQuery += $" AND r.category = '{카테고리.SelectedItem}'";

                if (!string.IsNullOrWhiteSpace(검색창.Text) && 검색창.Text != "검색어를 입력하세요")
                    filterQuery += $" AND r.product_name LIKE '%{검색창.Text}%'";

                if (기간선택.Checked)
                    filterQuery += $" AND r.registration_date BETWEEN TO_DATE('{시작날짜.Value:yyyy-MM-dd}', 'YYYY-MM-DD') AND TO_DATE('{종료날짜.Value:yyyy-MM-dd}', 'YYYY-MM-DD')";

                LoadStockData(filterQuery);
            };
        }

        private void InitializeContextMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem addItem = new ToolStripMenuItem("상품 추가");
            addItem.Click += (s, e) =>
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
                LoadStockData(); // 추가 후 데이터 갱신
            };

            ToolStripMenuItem editItem = new ToolStripMenuItem("상품 수정");
            editItem.Click += (s, e) =>
            {
                if (재고관리.SelectedRows.Count > 0)
                {
                    int stockId = Convert.ToInt32(재고관리.SelectedRows[0].Cells["stock_id"].Value);
                    Form2 form2 = new Form2(stockId); // 수정 모드로 열기
                    form2.ShowDialog();
                    LoadStockData(); // 수정 후 데이터 갱신
                }
            };

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("상품 삭제");
            deleteItem.Click += (s, e) =>
            {
                if (재고관리.SelectedRows.Count > 0)
                {
                    int stockId = Convert.ToInt32(재고관리.SelectedRows[0].Cells["stock_id"].Value);
                    if (MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            string query = $"DELETE FROM stock WHERE stock_id = {stockId}";
                            OracleCommand cmd = new OracleCommand(query, db.DBAdapter.SelectCommand.Connection);
                            cmd.ExecuteNonQuery();
                            LoadStockData(); // 삭제 후 데이터 갱신
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("삭제 중 오류 발생: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };

            menu.Items.AddRange(new ToolStripItem[] { addItem, editItem, deleteItem });
            재고관리.ContextMenuStrip = menu; // DataGridView에 ContextMenuStrip 연결
        }

        private void 추가_Click(object sender, EventArgs e)
        {

        }
    }
}
