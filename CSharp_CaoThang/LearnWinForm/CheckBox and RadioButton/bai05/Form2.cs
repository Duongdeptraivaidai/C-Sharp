using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai02
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_Infor.Clear();
            chk_BoldStyle.Checked = false;
            chk_ItalicStyle.Checked = false;
            chk_UnderlineStyle.Checked = false;
            txt_Infor.Focus();
        }

        private void btn_ChangeStyle_Click(object sender, EventArgs e)
        {
            FontStyle style = FontStyle.Regular;
            string a = txt_Infor.Text;
            if (a == "") MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu.");
            else
            {
                if (chk_UnderlineStyle.Checked) style |= FontStyle.Underline;
                if (chk_BoldStyle.Checked)style |= FontStyle.Bold;
                if (chk_ItalicStyle.Checked) style |= FontStyle.Italic;
                txt_Infor.Font = new Font(txt_Infor.Font,style);
                

            }
        }
    }
}
