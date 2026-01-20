using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private double giaiPTBacNhat(double a, double b)
        {
            if (a == 0)
            {
                if(b == 0)
                    throw new ArgumentException("Phương trình vô số nghiệm.");
                else
                    throw new ArgumentException("Phương trình vô nghiệm.");
            }
            else {       
                return -b / a;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtEqual.Clear();
            txtA.Focus();
        }

        private void btnGPT_Click(object sender, EventArgs e)
        {
            string a = txtA.Text;
            string b = txtB.Text;

            if (a == "" || b == "") MessageBox.Show("Vui lòng nhập du lieu (khong duoc de trong!).");
            else
            {
                double s1 = double.Parse(a);
                double s2 = double.Parse(b);
                txtEqual.Text = giaiPTBacNhat(s1, s2).ToString();

            }
        }
    }
}

