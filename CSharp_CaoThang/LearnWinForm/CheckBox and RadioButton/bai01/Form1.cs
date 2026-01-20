using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            chkMovie.Checked = false;
            chkMusic.Checked = false;
            chkFootball.Checked = false;
            chkReadBook.Checked = false;
            txtName.Focus();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string a = txtName.Text;
            string sothich = " ";
            if (a == "") MessageBox.Show("Vui long nhap du lieu(khong duoc de trong).");
            else
            {
                if (chkReadBook.Checked) { sothich += "\n -Đọc sách"; }
                if (chkMovie.Checked) { sothich += "\n -Xem phim"; }
                if (chkMusic.Checked) { sothich += "\n -Nghe nhạc"; }
                if (chkFootball.Checked) { sothich += "\n -Đá bóng"; }
                MessageBox.Show($"Họ tên: {a} \nSở thích: {sothich}");
            }
          
        }
    }
}
