﻿using Oracle.DataAccess.Client;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            InitializeSearchBox();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadSalesHistory();
        }
        private void LoadSalesHistory()
        {
            using (var connection = new OracleConnection("Your Connection String"))
            {
                connection.Open();
                string query = @"
                SELECT sh.sales_id, sh.sale_time, sh.quantity, sh.total_sales_amount, 
                       m.name AS member_name, m.card_number, r.product_name
                FROM sales_history sh
                JOIN stock s ON sh.stock_id = s.stock_id
                JOIN registration r ON s.registration_id = r.registration_id
                JOIN member m ON sh.member_id = m.member_id";

                OracleDataAdapter adapter = new OracleDataAdapter(query, connection);
                DataTable salesTable = new DataTable();
                adapter.Fill(salesTable);

                판매내역.DataSource = salesTable;
            }
        }
        private void InitializeSearchBox()
        {
            검색창.ForeColor = Color.Gray;
            검색창.Text = "검색어를 입력하세요";

            검색창.Enter += 검색창_Enter;
            검색창.Leave += 검색창_Leave;
        }

        private void 검색창_Enter(object sender, EventArgs e)
        {
            if (검색창.Text == "검색어를 입력하세요")
            {
                검색창.Text = "";
                검색창.ForeColor = Color.Black;
            }
        }

        private void 검색창_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(검색창.Text))
            {
                검색창.Text = "검색어를 입력하세요";
                검색창.ForeColor = Color.Gray;
            }
        }

        private void Sale_text_Click(object sender, EventArgs e)
        {

        }

        private void Pmanage_text_Click(object sender, EventArgs e)
        {
            // Form3 인스턴스를 생성하고 보여줍니다.
            상품재고관리 form3 = new 상품재고관리();
            
            form3.Show();

            // 현재 Form3을 숨기거나 닫습니다.
            this.Hide();
        }

        private void Report_text_Click(object sender, EventArgs e)
        {
            // Form6 인스턴스를 생성하고 보여줍니다.
            보고서 form6 = new 보고서();
            
            form6.Show();

            // 현재 Form5을 숨기거나 닫습니다.
            this.Hide();
        }

        private void Pregister_text_Click(object sender, EventArgs e)
        {
            // Form2 인스턴스를 생성합니다.
            Form2 form2 = new Form2();

            // Form2를 보여줍니다.
            form2.Show();
        }
    }
}
