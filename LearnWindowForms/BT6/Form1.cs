using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT6
{
    public partial class Form1 : Form
    {
        private string giaiPTBacHai(double a, double b, double c)
        {
            if (a == 0)
            {
                if (b == 0) return (c == 0) ? "Vô số nghiệm" : "Vô nghiệm";
                return "x = " + (-c / b).ToString("0.##");
            }

            double delta = b * b - 4 * a * c;
            if (delta < 0) return "Vô nghiệm";
            if (delta == 0) return "x1 = x2 = " + (-b / (2 * a)).ToString("0.##");

            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return $"x1 = {x1:0.##}, x2 = {x2:0.##}";
        }
        public Form1()
        {
            InitializeComponent();
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

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.') == false) return;
            if (e.KeyChar == '-' && ((TextBox)sender).Text.Contains('-') == false) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void btnGPT_Click(object sender, EventArgs e)
        {
            string a = txtA.Text;
            string b = txtB.Text;
            string c = txtC.Text;

            if (a == "" || b == "") MessageBox.Show("Vui lòng nhập du lieu (khong duoc de trong!).");
            else
            {
                double s1 = double.Parse(a);
                double s2 = double.Parse(b);
                double s3 = double.Parse(c);
                txtEqual.Text = giaiPTBacHai(s1, s2, s3).ToString();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            txtEqual.Clear();
            txtA.Focus();
        }
    }
}
