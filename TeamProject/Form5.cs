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
    public partial class Form5 : Form
    {
        private DBClass db;

        public Form5()
        {
            InitializeComponent();
            db = new DBClass();
            LoadSalesHistory();
            판매내역.AllowUserToAddRows = false; // 추가 행 제거
        }

        private void LoadSalesHistory()
        {
            try
            {
                string query = @"
            SELECT 
                sh.sales_id AS 판매ID,
                sh.sale_time AS 판매시간,
                sh.quantity AS 판매수량,
                m.name AS 회원명,
                s.product_name AS 상품명  -- 삭제된 상품 이름 그대로 표시
            FROM 
                sales_history sh
            LEFT JOIN member m ON sh.member_id = m.member_id
            LEFT JOIN stock st ON sh.stock_id = st.stock_id
            LEFT JOIN registration s ON st.registration_id = s.registration_id
            WHERE s.product_name IS NOT NULL";  // 상품명이 NULL인 경우는 제외

                DataTable salesHistoryData = new DataTable();
                using (OracleDataAdapter adapter = new OracleDataAdapter(query, db.Connection))
                {
                    adapter.Fill(salesHistoryData);
                }

                판매내역.DataSource = salesHistoryData; // Form5의 그리드뷰에 바인딩
                판매내역.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // 열을 화면에 꽉 차게 설정
            }
            catch (Exception ex)
            {
                MessageBox.Show($"판매 내역 로드 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 검색버튼_Click(object sender, EventArgs e)
        {
            string keyword = 검색창.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword) || keyword == "검색어를 입력하세요")
            {
                MessageBox.Show("검색어를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"
        SELECT 
            sh.sales_id AS 판매ID,
            sh.sale_time AS 판매시간,
            sh.quantity AS 판매수량,
            m.name AS 회원명,
            s.product_name AS 상품명
        FROM 
            sales_history sh
        LEFT JOIN member m ON sh.member_id = m.member_id
        LEFT JOIN stock st ON sh.stock_id = st.stock_id
        LEFT JOIN registration s ON st.registration_id = s.registration_id
        WHERE s.product_name IS NOT NULL
        AND (sh.sales_id LIKE :keyword
             OR m.name LIKE :keyword
             OR s.product_name LIKE :keyword)";

                DataTable salesHistoryData = new DataTable();
                using (OracleCommand cmd = new OracleCommand(query, db.Connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":keyword", $"%{keyword}%"));
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(salesHistoryData);
                    }
                }

                판매내역.DataSource = salesHistoryData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"검색 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

