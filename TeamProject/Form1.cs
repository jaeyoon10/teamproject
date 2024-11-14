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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Form3 인스턴스를 생성합니다.
            상품재고관리 form3 = new 상품재고관리();

            // Form3를 보여줍니다.
            form3.Show();
            // Form1 숨기기
            this.Hide();
        }
    }
}
