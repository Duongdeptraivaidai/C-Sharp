using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.') == false) return;
            if (e.KeyChar == '-' && ((TextBox)sender).Text.Contains('-') == false) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.') == false) return;
            if (e.KeyChar == '-' && ((TextBox)sender).Text.Contains('-') == false) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            string a = txtA.Text;
            string b = txtB.Text;

            if (a == "" || b == "") MessageBox.Show("Dữ liệu không được để trống vui lòng nhập dữ liệu!");
            else
            {
                double s1 = double.Parse(a);
                double s2 = double.Parse(b);
                double tong = s1 + s2;
                double hieu = s1 - s2;
                double tich = s1 * s2;
                double thuong = s1 / s2;
                txtTong.Text = tong.ToString();
                txtHieu.Text = hieu.ToString();
                txtTich.Text = tich.ToString();
                if (s2 == 0)
                {
                    txtThuong.Text = $"Khong chia duoc cho 0 nen ket qua bang {s1} ";
                    txtThuong.ForeColor = Color.Red;
                }
                else
                {
                    txtThuong.Text = thuong.ToString();
                    txtThuong.ForeColor = Color.DarkBlue;
                }
                
                
            }
        }
    }
}
