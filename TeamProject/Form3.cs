using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

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
            LoadRegistrationData(); // 초기 데이터 로드
            InitializeSearchFilters(); // 검색 필터 초기화
            InitializeContextMenu(); // ContextMenuStrip 초기화
        }

        private void LoadRegistrationData(string filterQuery = "")
        {
            DataTable registrationData = db.GetRegistrationData(filterQuery); // 필터 쿼리 적용
            상품관리.DataSource = registrationData; // DataGridView에 데이터 바인딩
        }
        private void InitializeSearchFilters()
        {
            // 카테고리 콤보박스 초기화
            카테고리.DataSource = new string[] { "전체", "음료", "스낵", "즉석식품", "유제품", "가공식품", "생활용품", "주류", "담배", "뷰티", "기타" };
            검색창.ForeColor = Color.Gray;
            검색창.Text = "검색어를 입력하세요";

            // 검색창 이벤트 핸들러 연결
            검색창.Enter += 검색창_Enter;
            검색창.Leave += 검색창_Leave;

            // 검색 버튼 클릭 이벤트 핸들러 연결
            검색버튼.Click += 검색버튼_Click;
        }

        private void 검색창_Enter(object sender, EventArgs e)
        {
            HandleSearchBoxEnter();
        }

        private void 검색창_Leave(object sender, EventArgs e)
        {
            HandleSearchBoxLeave();
        }

        private void 검색버튼_Click(object sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        private void HandleSearchBoxEnter()
        {
            if (검색창.Text == "검색어를 입력하세요")
            {
                검색창.Text = "";
                검색창.ForeColor = Color.Black;
            }
        }

        private void HandleSearchBoxLeave()
        {
            if (string.IsNullOrWhiteSpace(검색창.Text))
            {
                검색창.Text = "검색어를 입력하세요";
                검색창.ForeColor = Color.Gray;
            }
        }

        private void ApplySearchFilter()
        {
            string filterQuery = "WHERE 1=1";

            if (카테고리.SelectedItem.ToString() != "전체")
                filterQuery += $" AND r.category = '{카테고리.SelectedItem}'";

            if (!string.IsNullOrWhiteSpace(검색창.Text) && 검색창.Text != "검색어를 입력하세요")
                filterQuery += $" AND r.product_name LIKE '%{검색창.Text}%'";

            if (기간선택.Checked)
            {
                filterQuery += $" AND r.registration_date BETWEEN TO_DATE('{시작날짜.Value:yyyy-MM-dd}', 'YYYY-MM-DD') AND TO_DATE('{종료날짜.Value:yyyy-MM-dd}', 'YYYY-MM-DD')";
            }

            LoadRegistrationData(filterQuery);
        }

        private void InitializeContextMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem addItem = new ToolStripMenuItem("상품 추가");
            addItem.Click += (s, e) => OpenForm2ForAdd();

            ToolStripMenuItem editItem = new ToolStripMenuItem("상품 수정");
            editItem.Click += (s, e) => OpenForm2ForEdit();

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("상품 삭제");
            deleteItem.Click += (s, e) => DeleteSelectedRegistration();

            menu.Items.AddRange(new ToolStripItem[] { addItem, editItem, deleteItem });
            상품관리.ContextMenuStrip = menu; // DataGridView에 ContextMenuStrip 연결
        }

        private void OpenForm2ForAdd()
        {
            Form2 form2 = new Form2();
            form2.FormClosed += (s, e) => LoadRegistrationData(); // 폼 닫힌 후 데이터 갱신
            form2.ShowDialog();
        }


        private void OpenForm2ForEdit()
        {
            if (상품관리.SelectedRows.Count > 0)
            {
                int registrationId = Convert.ToInt32(상품관리.SelectedRows[0].Cells["등록ID"].Value);
                Form2 form2 = new Form2(registrationId);
                form2.FormClosed += (s, e) => LoadRegistrationData(); // 폼 닫힌 후 데이터 갱신
                form2.ShowDialog();
            }
        }



        private void DeleteSelectedRegistration()
        {
            if (상품관리.SelectedRows.Count > 0)
            {
                int registrationId = Convert.ToInt32(상품관리.SelectedRows[0].Cells["registration_id"].Value);
                if (MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string query = $"DELETE FROM registration WHERE registration_id = {registrationId}";
                        OracleCommand cmd = new OracleCommand(query, db.DBAdapter.SelectCommand.Connection);
                        cmd.ExecuteNonQuery();
                        LoadRegistrationData(); // 삭제 후 데이터 갱신
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("삭제 중 오류 발생: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void 재고버튼_Click(object sender, EventArgs e)
        {
            OpenForm8();
        }

        private void OpenForm8()
        {
            Form8 form8 = new Form8();
            form8.ShowDialog(); // 재고 테이블 표시 폼 열기
        }
    }
}
