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
    }
}
