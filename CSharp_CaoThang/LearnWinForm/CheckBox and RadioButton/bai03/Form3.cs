using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if(e.KeyChar=='.'&&((TextBox)sender).Text.Contains('.')==false)return;
            if(e.KeyChar=='-'&&((TextBox)sender).Text.Contains('-')==false)return;
            if(e.KeyChar==(char)Keys.Back) return;
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

        private void btn_Result_Click(object sender, EventArgs e)
        {
            string a= txtA.Text;
            string b= txtB.Text;
            if (a == "" || b == "") MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu.");
            else
            {
                double s1 = double.Parse(a);
                double s2 = double.Parse(b);
                double ketQua = 0;
                if (rbtn_Plus.Checked){ ketQua=s1+ s2;}
                else if (rbnt_Minus.Checked){ ketQua = s1 - s2;}
                else if (rbtn_Mutiply.Checked){ketQua = s1 * s2; }
                else if (rbtn_Devide.Checked){
                    if(s2==0){MessageBox.Show("Không thể chia cho 0");}
                    else{ ketQua = s1 / s2;}
                }
                else {MessageBox.Show("Vui lòng chọn một phép tính.");}
                txt_Result.Text = ketQua.ToString();
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            rbnt_Minus.Checked = false;
            rbtn_Devide.Checked = false;
            rbtn_Mutiply.Checked = false;
            rbtn_Plus.Checked = false;
            txtA.Focus();
        }

    }
}
