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
    }
}
