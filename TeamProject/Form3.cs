﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace TeamProject
{
    public partial class 상품재고관리 : Form
    {
        private DBClass db;
        private HashSet<string> alertedProducts; // 알림이 표시된 상품 추적

        public 상품재고관리()
        {
            InitializeComponent();
            db = new DBClass();
            db.DB_Open(); // 데이터베이스 연결
            alertedProducts = new HashSet<string>(); // 알림 상태 초기화
            LoadRegistrationData(); // 초기 데이터 로드
            InitializeSearchFilters(); // 검색 필터 초기화
            InitializeContextMenu(); // ContextMenuStrip 초기화

            상품관리.AllowUserToAddRows = false; // 추가 행 제거
            // 폼 로드 후 알림 확인
            this.Shown += (s, e) => CheckAlerts();
            상품관리.Sorted += (s, e) => CheckAlerts(onlyColor: true);

            ResetMenuColors();
            Pmanage_text.ForeColor = Color.Blue;
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

                    // 색상 다시 적용
                    CheckAlerts(onlyColor: true); // 알림 없이 색상만 적용
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 로드 중 오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool alertsShown = true; // 알림이 이미 떴는지 확인하는 변수
        private void CheckAlerts(bool onlyColor = false)
        {
            try
            {
                foreach (DataGridViewRow row in 상품관리.Rows)
                {
                    if (row.Cells["수량"].Value == DBNull.Value || row.Cells["유통기한"].Value == DBNull.Value)
                        continue; // 값이 NULL이면 다음 행으로 이동

                    int stockQuantity = Convert.ToInt32(row.Cells["수량"].Value);
                    DateTime expirationDate = Convert.ToDateTime(row.Cells["유통기한"].Value);
                    int minStock = 15; // 최소 재고 15로 고정


                    // 색상 초기화
                    row.Cells["수량"].Style.BackColor = Color.White;
                    row.Cells["유통기한"].Style.BackColor = Color.White;

                    // 재고 부족
                    if (stockQuantity < minStock)
                    {
                        row.Cells["수량"].Style.BackColor = Color.LightPink;

                        if (!alertsShown && !onlyColor) // 알림이 표시되지 않았고, 색상만 적용 모드가 아닌 경우
                        {
                            MessageBox.Show($"{row.Cells["상품명"].Value}의 재고가 부족합니다.", "재고 부족 알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // 유통기한 임박
                    if ((expirationDate - DateTime.Now).Days <= 3)
                    {
                        row.Cells["유통기한"].Style.BackColor = Color.LightYellow;

                        if (!alertsShown && !onlyColor) // 알림이 표시되지 않았고, 색상만 적용 모드가 아닌 경우
                        {
                            MessageBox.Show($"{row.Cells["상품명"].Value}의 유통기한이 임박했습니다.", "유통기한 알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // 알림이 모두 끝난 후, 알림 표시를 비활성화
                if (!onlyColor)
                {
                    alertsShown = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"알림 확인 중 오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                filterQuery += $" AND r.expiration_date BETWEEN TO_DATE('{시작날짜.Value:yyyy-MM-dd}', 'YYYY-MM-DD') AND TO_DATE('{종료날짜.Value:yyyy-MM-dd}', 'YYYY-MM-DD')";
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

            ResetMenuColors();
            Sale_text.ForeColor = Color.Blue;

            Form5 form5 = new Form5();
            form5.Show(); // 재고 테이블 표시 폼 열기

            this.Hide();
        }

        private void Report_text_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            Report_text.ForeColor = Color.Blue;
            보고서 form6 = new 보고서();
            form6.Show(); // 재고 테이블 표시 폼 열기

            this.Hide();
        }
        private void ResetMenuColors()
        {
            Sale_text.ForeColor = Color.Black;
            Pmanage_text.ForeColor = Color.Black;
            Report_text.ForeColor = Color.Black;
        }

        private void 상품재고관리_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // 데이터베이스 연결 닫기 (필요한 경우)
                db.DB_Close();

                // 모든 리소스 해제 후 애플리케이션 종료
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"프로그램 종료 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 상품재고관리_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 상품재고관리_Shown(object sender, EventArgs e)
        {
            // 처음 실행 시 알림 확인
            if (!alertsShown)
            {
                CheckAlerts(); // 창이 표시된 후 알림을 실행
            }
        }

        private void Pmanage_text_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            Pmanage_text.ForeColor = Color.Blue;
        }
    }
}