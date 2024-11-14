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
    public partial class 상품재고관리 : Form
    {
        public 상품재고관리()
        {
            InitializeComponent();
        }

        private void 추가_Click(object sender, EventArgs e)
        {
            // Form2 인스턴스를 생성합니다.
            Form2 form2 = new Form2();

            // Form2를 보여줍니다.
            form2.Show();
        }
    }
}
