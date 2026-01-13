using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT4
{
    public partial class Form1 : Form
    {
        private int timUCLN(int a, int b)
        {
            int x = (Int32)Math.Abs(a);
            int y = (Int32)Math.Abs(b);

            while (y != 0)
            {
                int r = x % y;
                x = y;
                y = r;
            }
            return x;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUCLN_Click(object sender, EventArgs e)
        {
            string a = txtA.Text;
            string b = txtB.Text;

            if (a == "" || b == "") MessageBox.Show("Vui lòng nhập du lieu (khong duoc de trong!).");
            else
            {
                int s1 = Int32.Parse(a);
                int s2 = Int32.Parse(b);
                txtEqual.Text = timUCLN(s1, s2).ToString();

            }
        }

        private void txtEqual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.') == false) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.') == false) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
