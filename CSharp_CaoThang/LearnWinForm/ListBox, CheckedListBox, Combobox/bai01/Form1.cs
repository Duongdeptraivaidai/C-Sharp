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

        private void btnAddName_Click(object sender, EventArgs e)
        {   //Neu (SelectedIndex == -1) nghia la nguoi dung chua chon gi ca
            if (cboTitle.SelectedIndex == -1) //Kiem tra nguoi dung da chon gi chua
            {
                MessageBox.Show("Vui long chon Title!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTitle.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                //Kiem tra nhap lieu co bi bo trong khong
            {
                MessageBox.Show("Vui long nhap First name!", "Thong bao", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return; //return se dung ham lai ngay khi phat hien du lieu trong
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Vui long nhap Last name!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }
            //Lay ra danh sach nguoi dung da chon trong ComboBox (vd: Mr)
            string fullname = $"{cboTitle.SelectedItem}." +
                $" {txtFirstName.Text.Trim()}" + $" {txtLastName.Text.Trim()}";
            namesListBox.Items.Add(fullname);
            txtFirstName.Clear();
            txtLastName.Clear();
            cboTitle.SelectedIndex = -1;//Tra ve trang thai o trong de nhap lai
            txtFirstName.Focus();
        }

         private void btn_Close_Click(object sender, EventArgs e)
         {
             var result = MessageBox.Show("Bạn chắc chắn muốn thoát chương trình chứ?","Thông báo",
                 MessageBoxButtons.YesNo,MessageBoxIcon.Question);
             if (result==DialogResult.Yes)
             {
                 this.Close();
             }
         }
    }
}

