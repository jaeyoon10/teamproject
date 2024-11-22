using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace TeamProject
{
    public partial class Form8 : Form
    {
        private DBClass db;

        public Form8()
        {
            InitializeComponent();
            db = new DBClass();
            db.DB_Open(); // 데이터베이스 연결
            LoadStockData(); // 재고 데이터 로드
        }


        private void LoadStockData()
        {
            try
            {
                // DB에서 재고 데이터 가져오기
                DataTable stockData = db.GetStockData();

                // DataGridView에 데이터 바인딩
                재고관리.DataSource = stockData;

                // DataGridView 설정
                재고관리.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                재고관리.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                재고관리.ReadOnly = true; // 읽기 전용 설정
            }
            catch (Exception ex)
            {
                MessageBox.Show("재고 데이터를 로드할 수 없습니다: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadStockData();
        }
       

        private void 판매_Click(object sender, EventArgs e)
        {
            if (재고관리.SelectedRows.Count == 0)
            {
                MessageBox.Show("판매할 상품를 선택하세요.");
                return;
            }

            // 선택된 행의 데이터 가져오기
            string productName = 재고관리.SelectedRows[0].Cells["product_name"].Value.ToString();
            int stockId = Convert.ToInt32(재고관리.SelectedRows[0].Cells["stock_id"].Value);

            // 판매 창 열기
            Form7 salesForm = new Form7(productName, stockId);
            salesForm.ShowDialog();

            // 재고 데이터 갱신
            LoadStockData();
        }
    }
}

