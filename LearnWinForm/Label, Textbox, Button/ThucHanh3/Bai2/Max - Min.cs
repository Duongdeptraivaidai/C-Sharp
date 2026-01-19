using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void btnTim_Click(object sender, EventArgs e)
        {

            string a = txtA.Text;
            string b = txtB.Text;

            if (a == "" || b == "") MessageBox.Show("Dữ liệu không được để trống vui lòng nhập dữ liệu!");
            else
            {
                double s1 = double.Parse(a);
                double s2 = double.Parse(b);
                if (s1 > s2)
                {
                    txtLN.Text = s1.ToString();
                    txtLN.Text = s2.ToString();
                }
                else {
                    txtNN.Text = s1.ToString();
                    txtLN.Text = s2.ToString();
                }
            }
        }

        private void txtLN_TextChanged(object sender, EventArgs e)
        {
            txtLN.Enabled = false;
        }

        private void txtNN_TextChanged(object sender, EventArgs e)
        {
            txtNN.Enabled = false;
        }
    }
}
