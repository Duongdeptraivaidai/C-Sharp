using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBox2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Please pick your picture!";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //get path Project foldr (file.exe in folder).
                        string getPath = Application.StartupPath;
                        //create "Images" folder if it not exitsts yet.
                        string createFolderPath = Path.Combine(getPath, "Images");
                        if (!Directory.Exists(createFolderPath))
                        {
                            Directory.CreateDirectory(createFolderPath);
                        }
                        //Prepare the destination path for copying.
                        string fileName = Path.GetFileName(openFileDialog.FileName);
                        string desPath = Path.Combine(createFolderPath, fileName);

                        //Copy the file to the  Images folder (true to overwrite if the name same) 
                        File.Copy(openFileDialog.FileName, desPath, true);

                        //Show the picture from new path
                        pb_PictureInfor.Image = new Bitmap(desPath);
                        pb_PictureInfor.SizeMode = PictureBoxSizeMode.Zoom;
                        MessageBox.Show("Image saved to folder!" + createFolderPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An Error occurred!: " + ex.Message);
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_PhoneNumber_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_Address_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            //Get data from Controls
            string name = txt_Name.Text.Trim();
            string date = dateTimePicker1.Value.ToString("dd/MM/yyyy HH:mm");
            string phone = txt_PhoneNumber.Text.Trim();
            string address = txt_Address.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui long nhap Ho ten!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Name.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(phone)&&(phone.Length < 10 || phone.Length > 11))
            {
                MessageBox.Show("Vui long nhap So dien thoai. So dien thoai phai tu 10-11 so", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_PhoneNumber.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_Address.Text))
            {   
                MessageBox.Show("Vui long nhap Dia chi!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Address.Focus();
                return;
            }
            

            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(date);
            item.SubItems.Add(phone);
            item.SubItems.Add(address);
            listView1.Items.Add(item);
            txt_Name.Clear();
            txt_PhoneNumber.Clear();
            txt_Address.Clear();
            txt_Name.Focus();


        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                }
            }
        }

        private void txt_PhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Fix_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // 1. Kiểm tra điều kiện SĐT trước khi cho sửa
                if (txt_PhoneNumber.Text.Length < 10 || txt_PhoneNumber.Text.Length > 11)
                {
                    MessageBox.Show("SĐT phải từ 10-11 số!");
                    return;
                }

                // 2. Cập nhật dòng đang chọn bằng dữ liệu mới từ các ô nhập
                ListViewItem item = listView1.SelectedItems[0];
                item.SubItems[0].Text = txt_Name.Text;
                item.SubItems[1].Text = txt_PhoneNumber.Text;
                item.SubItems[2].Text = dtpDeadline.Value.ToString("dd/MM/yyyy");

                MessageBox.Show("Đã cập nhật thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách trước khi sửa!");
            }
        }
    }
}
