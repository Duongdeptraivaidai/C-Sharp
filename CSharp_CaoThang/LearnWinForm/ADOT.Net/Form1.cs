using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project1
{
    public partial class Form1 : Form
    {
        // 1. Nên để chuỗi kết nối ở một nơi duy nhất để dễ quản lý
        string connectionStr = "Data Source=F71-27;Integrated Security=true;Initial Catalog=QLSINHVIEN";

        public Form1()
        {
            InitializeComponent();
            loadDSSV();
        }

        // The function upload to ListView
        public void loadDSSV()
        {
            listView1.Items.Clear(); // Xóa dữ liệu cũ trước khi nạp mới
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM SINHVIEN";
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Create new column with ID (first column)
                        ListViewItem item = new ListViewItem(reader[0].ToString());

                        // Add the remaining columns: MSSV, LastName, FirstName, Class, Address...
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            item.SubItems.Add(reader[i].ToString());
                        }
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
                    string query = "INSERT INTO SINHVIEN (MSSV, HoTen, Lop, DiaChi, TrangThai, NgaySinh) " +
                                   "VALUES (@MSSV, @HoTen, @Lop, @DiaChi, @TrangThai, @NgaySinh)";

                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("@MSSV", txtID.Text);
                    command.Parameters.AddWithValue("@HoTen", txtLastName.Text);
                    command.Parameters.AddWithValue("@Lop", txtClass.Text);
                    command.Parameters.AddWithValue("@DiaChi", txtAddress.Text);
                    command.Parameters.AddWithValue("@TrangThai", chkState.Checked ? 1 : 0);
                    command.Parameters.AddWithValue("@NgaySinh", dtpDate.Value);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm sinh viên thành công!");
                        loadDSSV();
                    }
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

        private void btnQuality_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM SINHVIEN";
                SqlCommand cmd = new SqlCommand(query, conn);
                object count = cmd.ExecuteScalar(); // Give back a only value 
                MessageBox.Show("Tổng số sinh viên: " + count.ToString());
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Check if the user has selected an item in the ListView
            if (listView1.SelectedItems.Count > 0)
            {
                // Ask for confirmation before deleting
                DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn xóa sinh viên này?", "Thông báo", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    // Get the ID (first column) of the selected row
                    string studentID = listView1.SelectedItems[0].Text;

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionStr))
                        {
                            conn.Open();
                            // SQL Command to delete based on the Primary Key
                            string query = "DELETE FROM SINHVIEN WHERE MSSV = @MSSV";

                            SqlCommand command = new SqlCommand(query, conn);
                            command.Parameters.AddWithValue("@MSSV", studentID);

                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Xóa thành công sinh viên!");
                                loadDSSV(); // Refresh the ListView to show updated data
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi trong khi xóa: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Đầu tiên xin hãy chọn sinh viên danh sách!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Hãy chọn 1 sinh viên để sửa.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    conn.Open();
                    // Update the record where the MSSV matches
                    string query = "UPDATE SINHVIEN SET HoTen = @HoTen, Lop = @Lop, " +
                                   "DiaChi = @DiaChi, TrangThai = @TrangThai, NgaySinh = @NgaySinh " +
                                   "WHERE MSSV = @MSSV";

                    SqlCommand command = new SqlCommand(query, conn);

                    // Add parameters to prevent SQL Injection
                    command.Parameters.AddWithValue("@MSSV", txtID.Text);
                    command.Parameters.AddWithValue("@HoTen", txtLastName.Text);
                    command.Parameters.AddWithValue("@Lop", txtClass.Text);
                    command.Parameters.AddWithValue("@DiaChi", txtAddress.Text);
                    command.Parameters.AddWithValue("@TrangThai", chkState.Checked ? 1 : 0);
                    command.Parameters.AddWithValue("@NgaySinh", dtpDate.Value);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật thành công sinh viên!");
                        loadDSSV(); // Refresh the display
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại: " + ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Get the selected row
                ListViewItem item = listView1.SelectedItems[0];

                // Map the sub-items back to the input fields
                txtID.Text = item.SubItems[1].Text;
                txtLastName.Text = item.SubItems[2].Text;
                txtFirstName.Text = item.SubItems[3].Text;
                txtClass.Text = item.SubItems[4].Text;
                txtAddress.Text = item.SubItems[5].Text;

                // Handle the CheckBox (assuming "Đang học" is a string "1" or "True")
                chkState.Checked = item.SubItems[6].Text == "1" || item.SubItems[6].Text == "True";

                // Handle the Date (Parse the string back to DateTime)
                DateTime dt;
                if (DateTime.TryParse(item.SubItems[7].Text, out dt))
                {
                    dtpDate.Value = dt;
                }
            }
        }
    }
}