using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;

namespace TeamProject
{
    public partial class Form1 : Form
    {
        private DBClass db;

        public Form1()
        {
            InitializeComponent();
            db = new DBClass();
            db.DB_Open(); // 데이터베이스 연결 및 테이블 불러오기
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string storeOwnerId = id_text.Text; // 아이디 입력란
            string password = password_text.Text; // 비밀번호 입력란

            if (db.ValidateStoreOwner(storeOwnerId, password))
            {
                // 로그인 성공 - Form3으로 이동
                상품재고관리 inventoryForm = new 상품재고관리();
                inventoryForm.Show();
                this.Hide(); // 현재 폼 숨기기
            }
            else
            {
                // 로그인 실패 - 오류 메시지 표시
                MessageBox.Show("아이디 또는 비밀번호가 잘못되었습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}