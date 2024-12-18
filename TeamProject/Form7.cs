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
    public partial class Form7 : Form
    {
        private string selectedProductName; // 선택한 상품 이름
        private int stockId; // 재고 ID
        private DBClass db;

        public Form7(string productName, int stockId)
        {
            InitializeComponent();
            selectedProductName = productName;
            this.stockId = stockId;
            db = new DBClass();
            db.DB_Open();
            label3.Text = selectedProductName; // 상품 이름 레이블에 설정
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string memberName = txtMemberName.Text.Trim();
                int saleQuantity = int.Parse(txtSaleQuantity.Text.Trim());

                if (string.IsNullOrWhiteSpace(memberName))
                {
                    MessageBox.Show("회원 이름을 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (saleQuantity <= 0)
                {
                    MessageBox.Show("판매 수량은 0보다 커야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int memberId = GetOrAddMemberId(memberName);

                if (!UpdateStockQuantity(stockId, saleQuantity))
                {
                    MessageBox.Show("재고가 부족합니다.", "재고 부족", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. 판매 내역 저장
                AddSaleHistory(stockId, memberId, saleQuantity);

                // 4. 보고서 창 업데이트
                UpdateReport(stockId, saleQuantity);

                MessageBox.Show("판매 완료되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 부모 폼 새로고침 및 폼 닫기
                if (Owner is Form8 parentForm)
                {
                    parentForm.LoadStockData();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"판매 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 보고서 업데이트 메서드
        private void UpdateReport(int stockId, int saleQuantity)
        {
            try
            {
                // DBClass 사용
                db.DB_Open();

                // `registration` 테이블에서 상품 정보 가져오기
                string query = @"
            SELECT 
                r.product_name,
                r.category,
                (r.registration_price * :saleQuantity) AS totalAmount
            FROM 
                stock s
            JOIN 
                registration r ON s.registration_id = r.registration_id
            WHERE 
                s.stock_id = :stockId";

                using (OracleCommand cmd = new OracleCommand(query, db.Connection))
                {
                    cmd.Parameters.Add(new OracleParameter("saleQuantity", saleQuantity));
                    cmd.Parameters.Add(new OracleParameter("stockId", stockId));

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["product_name"].ToString();
                            string category = reader["category"].ToString();
                            decimal totalAmount = Convert.ToDecimal(reader["totalAmount"]);

                            // 보고서 테이블에 추가
                            db.UpdateReport(stockId, saleQuantity, category, productName, totalAmount);

                            // 보고서 창(Form6) 갱신
                            보고서 reportForm = Application.OpenForms.OfType<보고서>().FirstOrDefault();
                            if (reportForm != null)
                            {
                                reportForm.RefreshReport();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"보고서 업데이트 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.DB_Close();
            }
        }

        private int GetOrAddMemberId(string memberName)
        {
            try
            {
                string selectQuery = "SELECT member_id FROM member WHERE name = :memberName";
                using (OracleCommand cmd = new OracleCommand(selectQuery, db.Connection))
                {
                    cmd.Parameters.Add(new OracleParameter("memberName", memberName));
                    object result = cmd.ExecuteScalar();

                    if (result != null) return Convert.ToInt32(result);

                    // 회원이 없으면 추가
                    string insertQuery = "INSERT INTO member (member_id, name, card_number) VALUES (member_seq.NEXTVAL, :memberName, '0000000000000000')";
                    using (OracleCommand insertCmd = new OracleCommand(insertQuery, db.Connection))
                    {
                        insertCmd.Parameters.Add(new OracleParameter("memberName", memberName));
                        insertCmd.ExecuteNonQuery();
                    }

                    // 추가된 회원 ID 반환
                    string getIdQuery = "SELECT member_seq.CURRVAL FROM DUAL";
                    using (OracleCommand getIdCmd = new OracleCommand(getIdQuery, db.Connection))
                    {
                        object newId = getIdCmd.ExecuteScalar();
                        return Convert.ToInt32(newId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"회원 처리 중 오류 발생: {ex.Message}");
            }
        }
        private bool UpdateStockQuantity(int stockId, int saleQuantity)
        {
            try
            {
                string checkQuery = "SELECT stock_quantity FROM stock WHERE stock_id = :stockId";
                using (OracleCommand checkCmd = new OracleCommand(checkQuery, db.Connection))
                {
                    checkCmd.Parameters.Add(new OracleParameter("stockId", stockId));
                    int currentStock = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (currentStock < saleQuantity) return false; // 재고 부족

                    // 재고 업데이트
                    string updateQuery = "UPDATE stock SET stock_quantity = stock_quantity - :saleQuantity WHERE stock_id = :stockId";
                    using (OracleCommand updateCmd = new OracleCommand(updateQuery, db.Connection))
                    {
                        updateCmd.Parameters.Add(new OracleParameter("saleQuantity", saleQuantity));
                        updateCmd.Parameters.Add(new OracleParameter("stockId", stockId));
                        updateCmd.ExecuteNonQuery();
                    }
                }

                // 재고 업데이트 후 0인 항목 삭제
                db.DeleteOutOfStockItems();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"재고 업데이트 중 오류 발생: {ex.Message}");
            }
        }

        private void AddSaleHistory(int stockId, int memberId, int saleQuantity)
        {
            try
            {
                // 데이터베이스 연결 확인 및 열기
                if (db.Connection.State != ConnectionState.Open)
                {
                    db.DB_Open();
                }

                // 판매 내역 저장
                string query = @"
            INSERT INTO sales_history (sales_id, sale_time, quantity, stock_id, member_id)
            VALUES (sales_seq.NEXTVAL, :saleTime, :quantity, :stockId, :memberId)";
                using (OracleCommand cmd = new OracleCommand(query, db.Connection))
                {
                    cmd.Parameters.Add(new OracleParameter("saleTime", DateTime.Now));
                    cmd.Parameters.Add(new OracleParameter("quantity", saleQuantity));
                    cmd.Parameters.Add(new OracleParameter("stockId", stockId));
                    cmd.Parameters.Add(new OracleParameter("memberId", memberId));
                    cmd.ExecuteNonQuery();
                }

                // 보고서 업데이트를 위한 상품 정보 가져오기
                string productQuery = @"
            SELECT 
                r.product_name, 
                r.category, 
                r.registration_price * :saleQuantity AS totalAmount
            FROM 
                stock s
            JOIN 
                registration r ON s.registration_id = r.registration_id
            WHERE 
                s.stock_id = :stockId";

                using (OracleCommand productCmd = new OracleCommand(productQuery, db.Connection))
                {
                    productCmd.Parameters.Add(new OracleParameter("saleQuantity", saleQuantity));
                    productCmd.Parameters.Add(new OracleParameter("stockId", stockId));

                    using (OracleDataReader reader = productCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["product_name"].ToString();
                            string category = reader["category"].ToString();
                            decimal totalAmount = Convert.ToDecimal(reader["totalAmount"]);

                            // 보고서 업데이트
                            db.UpdateReport(stockId, saleQuantity, category, productName, totalAmount);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"판매 기록 저장 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 데이터베이스 연결 닫기
                db.DB_Close();
            }
        }

    }
}

