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

        public void LoadRegistrationData(string filterQuery = "")
        {
            try
            {
                db.DeleteOutOfStockItems(); // 재고 0인 상품 삭제
                DataTable registrationData = db.GetRegistrationData(filterQuery);

                if (registrationData == null || registrationData.Rows.Count == 0)
                {
                    MessageBox.Show("등록된 상품이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    상품관리.DataSource = registrationData; // DataGridView에 데이터 바인딩
                    상품관리.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // 열을 화면에 꽉 차게 설정
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 로드 중 오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            int storeOwnerId = 1; // 현재 점주 ID
            Form2 form2 = new Form2(storeOwnerId);
            form2.Owner = this; // Form2에 부모 폼으로 Form3 설정
            form2.FormClosed += (s, e) => LoadRegistrationData(); // 폼 닫힌 후 데이터 갱신
            form2.ShowDialog(); // Modal로 Form2 열기
        }


        private void OpenForm2ForEdit()
        {
            if (상품관리.SelectedRows.Count > 0)
            {
                if (상품관리.SelectedRows.Count > 0)
                {
                    try
                    {
                        // 선택된 행의 등록 ID 가져오기
                        int registrationId = Convert.ToInt32(상품관리.SelectedRows[0].Cells["등록ID"].Value);

                        // 연결 확인 및 열기
                        if (db.Connection.State != ConnectionState.Open)
                        {
                            db.Connection.Open();
                        }

                        // 수정창 호출
                        수정창 editForm = new 수정창(registrationId);
                        editForm.Owner = this; // Form3을 부모 폼으로 설정
                        editForm.FormClosed += (s, e) => LoadRegistrationData(); // 폼 닫힌 후 데이터 새로고침
                        editForm.ShowDialog(); // 수정창 열기
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"수정 작업 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("수정할 상품을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void OpenForm4ForEdit()
        {
            if (상품관리.SelectedRows.Count > 0)
            {
                int registrationId = Convert.ToInt32(상품관리.SelectedRows[0].Cells["등록ID"].Value);
                수정창 editForm = new 수정창(registrationId);
                editForm.Owner = this;
                editForm.FormClosed += (s, e) => LoadRegistrationData();
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("수정할 상품을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteSelectedRegistration()
        {
            if (상품관리.SelectedRows.Count > 0)
            {
                try
                {
                    // 데이터베이스 연결 열기
                    if (db.Connection.State != ConnectionState.Open)
                    {
                        db.DB_Open();
                    }

                    // 선택된 행의 등록 ID 가져오기
                    int registrationId = Convert.ToInt32(상품관리.SelectedRows[0].Cells["등록ID"].Value);

                    // 판매 내역에 해당 상품이 있는지 확인
                    string checkSalesQuery = @"
                SELECT COUNT(*)
                FROM sales_history sh
                JOIN stock s ON sh.stock_id = s.stock_id
                WHERE s.registration_id = :registrationId";

                    using (OracleCommand cmd = new OracleCommand(checkSalesQuery, db.Connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("registrationId", registrationId));

                        object result = cmd.ExecuteScalar();

                        if (result != null && Convert.ToInt32(result) > 0)
                        {
                            // 판매 내역에 해당 상품이 존재하면 삭제 불가
                            MessageBox.Show("이 상품은 판매 내역에 존재하여 삭제할 수 없습니다.", "삭제 불가", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 삭제 확인 메시지
                    if (MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // 재고 테이블에서 삭제
                        string deleteStockQuery = "DELETE FROM stock WHERE registration_id = :registrationId";
                        using (OracleCommand deleteStockCmd = new OracleCommand(deleteStockQuery, db.Connection))
                        {
                            deleteStockCmd.Parameters.Add(new OracleParameter("registrationId", registrationId));
                            deleteStockCmd.ExecuteNonQuery();
                        }

                        // 등록 테이블에서 삭제
                        string deleteRegistrationQuery = "DELETE FROM registration WHERE registration_id = :registrationId";
                        using (OracleCommand deleteRegistrationCmd = new OracleCommand(deleteRegistrationQuery, db.Connection))
                        {
                            deleteRegistrationCmd.Parameters.Add(new OracleParameter("registrationId", registrationId));
                            deleteRegistrationCmd.ExecuteNonQuery();
                        }

                        // 삭제 후 데이터 새로고침
                        LoadRegistrationData();
                        MessageBox.Show("상품이 성공적으로 삭제되었습니다.", "삭제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"삭제 작업 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // 데이터베이스 연결 닫기
                    if (db.Connection.State == ConnectionState.Open)
                    {
                        db.DB_Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("삭제할 상품을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Sale_text_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show(); // 재고 테이블 표시 폼 열기

            this.Hide();
        }
    }
}