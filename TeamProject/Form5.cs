﻿using System;
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
