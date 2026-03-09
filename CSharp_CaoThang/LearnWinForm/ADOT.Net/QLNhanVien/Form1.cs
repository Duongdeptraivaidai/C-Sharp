using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2
{
    public partial class Form1 : Form
    {
        string connectionStr = "Data Source=F71-27;Integrated Security=true;Initial Catalog=QLNhanVien";
        string selectedFileName = ""; // Save Image's Name

        public Form1()
        {
            InitializeComponent();
        }

        public void loadDSNV()
        {
                listView1.Items.Clear();
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionStr))
                    {
                        conn.Open();
                        string query = "SELECT * FROM NhanVien";
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                        ListViewItem item = new ListViewItem(reader["MaNV"].ToString());
                        item.SubItems.Add(reader["HoTen"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy"));
                        item.SubItems.Add(reader["SDT"].ToString());
                        item.SubItems.Add(reader["DiaChi"].ToString());
                        item.SubItems.Add(reader["AvatarUrl"].ToString());

                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    conn.Open();
                    string query = "Insert into NhanVien(HoTen, NgaySinh,SDT,DiaChi,AvatarUrl)" +
                        "values(@hoten, @ngaysinh, @sdt, @diachi, @avatar)";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@hoten", txtName.Text);
                    command.Parameters.AddWithValue("@ngaysinh", dtpDate.Value);
                    command.Parameters.AddWithValue("@sdt", txtPhoneNumber.Text);
                    command.Parameters.AddWithValue("@diachi", txtAddress.Text);
                    command.Parameters.AddWithValue("@avatar", selectedFileName);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    loadDSNV();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Lỗi: Mã lớp này không tồn tại trong hệ thống. Vui lòng kiểm tra lại!");
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void btnUpLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read))
                {
                    pbLoadImage.Image = Image.FromStream(fs);
                }
                pbLoadImage.SizeMode = PictureBoxSizeMode.StretchImage;

                selectedFileName = Path.GetFileName(open.FileName);

                string folderPath = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                string destPath = Path.Combine(folderPath, selectedFileName);
                File.Copy(open.FileName, destPath, true);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }
            try
            {
                int maNV = Convert.ToInt32(listView1.SelectedItems[0].Text);

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    string sql = "UPDATE NhanVien SET HoTen=@hoten, NgaySinh=@ngaysinh, SDT=@sdt, " +
                                 "DiaChi=@diachi, AvatarUrl=@avatar WHERE MaNV=@manv";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@manv", maNV);
                    cmd.Parameters.AddWithValue("@hoten", txtName.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", dtpDate.Value);
                    cmd.Parameters.AddWithValue("@sdt", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@avatar", selectedFileName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    loadDSNV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDSNV();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int maNV = Convert.ToInt32(listView1.SelectedItems[0].Text);
                    using (SqlConnection conn = new SqlConnection(connectionStr))
                    {
                        string sql = "DELETE FROM NhanVien WHERE MaNV=@manv";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@manv", maNV);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        loadDSNV();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi khi xóa: " + ex.Message); }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtName.Text = item.SubItems[1].Text;
                dtpDate.Value = DateTime.ParseExact(item.SubItems[2].Text, "dd/MM/yyyy", null);
                txtPhoneNumber.Text = item.SubItems[3].Text;
                txtAddress.Text = item.SubItems[4].Text;
                selectedFileName = item.SubItems[5].Text;

                string imgPath = Path.Combine(Application.StartupPath, "Images", selectedFileName);
                if (File.Exists(imgPath))
                {
                    using (FileStream fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                    {
                        pbLoadImage.Image = Image.FromStream(fs);
                    }
                    pbLoadImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else { pbLoadImage.Image = null; }
            }
        }
    }
}
