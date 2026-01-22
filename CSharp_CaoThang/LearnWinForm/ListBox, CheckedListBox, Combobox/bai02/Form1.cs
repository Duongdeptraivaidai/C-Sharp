using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ba02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui long nhap Ho ten!","Thong bao",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (cboChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui long chon Chuc vu!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return;
            }
            if (cboPhongBan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui long chon Phong ban!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhongBan.Focus();
                return;
            }
            string fullname = $"({cboChucVu.SelectedItem}) " +$"{txtName.Text.Trim()}";
            if(cboPhongBan.SelectedItem.ToString()=="Nghien Cuu")
            {
                lstNghienCuu.Items.Add(fullname);
            }
            else
            {
                lstQuanLy.Items.Add(fullname);
            }
            txtName.Clear();
            cboChucVu.SelectedIndex = -1;
            cboPhongBan.SelectedIndex = -1;
            txtName.Focus();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                                         "Xác nhận",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            if(lstNghienCuu.SelectedIndex != -1) {
                string item  = lstNghienCuu.SelectedItem.ToString(); 
                if(item.Contains("(Truong phong)")) 
                {
                    item = item.Replace("(Truong phong)", "(Nhan vien)");
                }
                lstQuanLy.Items.Add(item);
                lstNghienCuu.Items.RemoveAt(lstNghienCuu.SelectedIndex);
            }
        }

        private void btnToRightAll_Click(object sender, EventArgs e)
        {
            while (lstNghienCuu.Items.Count > 0)
            {
                string item = lstNghienCuu.Items[0].ToString();
                if (item.Contains("(Truong phong)"))
                    item = item.Replace("(Truong phong)", "(Nhan vien)");

                lstQuanLy.Items.Add(item);
                lstNghienCuu.Items.RemoveAt(0);
            }
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            if( lstQuanLy.SelectedIndex != -1)
            {
                string item = lstQuanLy.SelectedItem.ToString();
                if (item.Contains("(Nhan vien)"))
                {
                    item = item.Replace("(Nhan vien)", "(Truong phong)");
                }
                lstNghienCuu.Items.Add(item); 
                lstQuanLy.Items.RemoveAt(lstQuanLy.SelectedIndex);
            }
        }

        private void btnToLeftAll_Click(object sender, EventArgs e)
        {
            while (lstQuanLy.Items.Count > 0)
            {
                string item = lstQuanLy.Items[0].ToString();
                if (item.Contains("(Nhan vien)"))
                    item = item.Replace("(Nhan vien)", "(Truong phong)");

                lstNghienCuu.Items.Add(item);
                lstQuanLy.Items.RemoveAt(0);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstNghienCuu.SelectedIndex != -1)
            {
                lstNghienCuu.Items.RemoveAt(lstNghienCuu.SelectedIndex);
            }
            else if(lstQuanLy.SelectedIndex!=-1)
            {
                lstQuanLy.Items.RemoveAt(lstQuanLy.SelectedIndex);
            }
        }

        private void lstNghienCuu_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ListBox lb = (ListBox)sender;
            string text = lb.Items[e.Index].ToString();

            // Vẽ nền cho dòng (khi được chọn hoặc không)
            e.DrawBackground();

            // Logic doi mau: Truong phong mau do, Nhan vien mau xanh
            Brush myBrush = Brushes.Black; // Mac dinh la den

            if (text.Contains("(Truong phong)"))
            {
                myBrush = Brushes.Red; // Truong phong mau do
            }
            else if (text.Contains("(Nhan vien)"))
            {
                myBrush = Brushes.Blue; // Nhân viên mau xanh
            }

            // Tien hanh ve du lieu
            e.Graphics.DrawString(text, e.Font, myBrush, e.Bounds);

            // Ve khung bao quanh ne dong do duoc chon
            e.DrawFocusRectangle();
        }

        private void lstQuanLy_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ListBox lb = (ListBox)sender;
            string text = lb.Items[e.Index].ToString();

            // Ve nen cho dong
            e.DrawBackground();

            // Logic đổi màu: Trưởng phòng màu đỏ, Nhân viên màu xanh
            Brush myBrush = Brushes.Black; // Mặc định đen

            if (text.Contains("(Truong phong)"))
            {
                myBrush = Brushes.Red; // Trưởng phòng rực rỡ
            }
            else if (text.Contains("(Nhan vien)"))
            {
                myBrush = Brushes.Blue; // Nhân viên chuyên nghiệp
            }

            // Tiến hành vẽ chữ lên dòng đó
            e.Graphics.DrawString(text, e.Font, myBrush, e.Bounds);

            // Vẽ khung bao quanh nếu dòng đó đang được chọn
            e.DrawFocusRectangle();
        }
    }
}
