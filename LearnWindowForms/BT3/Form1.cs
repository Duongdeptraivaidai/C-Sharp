using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT3
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            string text1 = txtA.Text;
            string text2 = txtB.Text;

            if (text1 == "" || text2 == "") MessageBox.Show("Vui lòng nhập du lieu (khong duoc de trong!).");
            else
            {
                double s1 = double.Parse(text1);
                double s2 = double.Parse(text2);
                txtEqual.Text = (s1 + s2).ToString();

            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            string text1 = txtA.Text;
            string text2 = txtB.Text;

            if (text1 == "" || text2 == "") MessageBox.Show("Vui lòng nhập du lieu (khong duoc de trong!).");
            else
            {
                double s1 = double.Parse(text1);
                double s2 = double.Parse(text2);
                txtEqual.Text = (s1 - s2).ToString();
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            string text1 = txtA.Text;
            string text2 = txtB.Text;

            if (text1 == "" || text2 == "") MessageBox.Show("Vui lòng nhập du lieu (khong duoc de trong!).");
            else
            {
                double s1 = double.Parse(text1);
                double s2 = double.Parse(text2);
                txtEqual.Text = (s1 * s2).ToString();
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            string text1 = txtA.Text;
            string text2 = txtB.Text;

            if (text1 == "" || text2 == "") MessageBox.Show("Vui lòng nhập du lieu (khong duoc de trong!).");
            else
            {
                double s1 = double.Parse(text1);
                double s2 = double.Parse(text2);
                if (s2 == 0)
                {
                    MessageBox.Show("Số chia phải khác 0!");
                    txtB.Focus();
                }
                else
                {
                    txtEqual.Text = (s1 / s2).ToString();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtEqual.Clear();
            txtA.Focus(); 
        }

        private void txtEqual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.'&& ((TextBox)sender).Text.Contains('.')==false) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.')==false) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
