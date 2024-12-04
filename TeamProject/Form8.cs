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
            LoadStockData();
        }


        public void LoadStockData()
        {
            try
            {
                db.DeleteOutOfStockItems(); // 재고 0인 상품 삭제

                string query = @"
            SELECT 
                s.stock_id AS 재고ID, 
                r.product_name AS 상품명, 
                r.category AS 카테고리, 
                s.stock_quantity AS 수량, 
                r.expiration_date AS 유통기한,
                r.remarks AS 비고
            FROM 
                stock s
            JOIN 
                registration r ON s.registration_id = r.registration_id";

                DataTable stockData = new DataTable();
                using (OracleDataAdapter adapter = new OracleDataAdapter(query, db.Connection))
                {
                    adapter.Fill(stockData);
                }

                재고관리.DataSource = stockData; // Form8의 재고 그리드뷰
            }
            catch (Exception ex)
            {
                MessageBox.Show($"재고 데이터를 로드하는 중 오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializeGridView()
        {
            재고관리.AutoGenerateColumns = true;
            재고관리.Columns["수량"].HeaderText = "수량";
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            LoadStockData();
        }


        private void 판매_Click(object sender, EventArgs e)
        {
            if (재고관리.SelectedRows.Count > 0)
            {
                string productName = 재고관리.SelectedRows[0].Cells["상품명"].Value.ToString();
                int stockId = Convert.ToInt32(재고관리.SelectedRows[0].Cells["재고ID"].Value);

                Form7 form7 = new Form7(productName, stockId);
                form7.ShowDialog();
            }
            else
            {
                MessageBox.Show("판매할 상품을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}