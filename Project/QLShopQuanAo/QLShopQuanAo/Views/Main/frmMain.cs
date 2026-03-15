using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using QLShopQuanAo.Views.Main.Order;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace QLShopQuanAo.Views.Main
{
    public partial class frmMain : Form
    {
        public int MaNV_DangNhap { get; set; }
        string connectionString = @"Data Source=DESKTOP-10UJ2O8\SQLEXPRESS;Initial Catalog=QLShopQuanAo;Integrated Security=True";
        DataTable cartTable = new DataTable();

        string staffImageFolder = Path.Combine(Application.StartupPath, "Images", "Staff");
        string productImageFolder = Path.Combine(Application.StartupPath, "Images", "Products");
        string currentFileName = "";

        int selectedMaNCC = -1;

        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadComboBoxLoaiSP();
            LoadDataNhanVien();
            LoadDataSanPham();
            LoadDataKhachHang();
            SetupCartTable();
            LoadDataSanPhamChoBanHang();
            LoadComboBoxKhachHang();
            LoadDataChoNhapHang();

            HienThiTenNhanVien();

            ShowPage(pnHome);
        }

        //Điều hướng
        private void ShowPage(Panel targetPanel)
        {
            pnHome.Visible = pnStaff.Visible = pnProduct.Visible =
            pnCustomer.Visible = pnOrderProduct.Visible = pnInformationProduct.Visible = false;

            targetPanel.Visible = true;
            targetPanel.Dock = DockStyle.Fill;
        }
        private void btnHome_Click(object sender, EventArgs e) => ShowPage(pnHome);
        private void btnStaff_Click(object sender, EventArgs e) => ShowPage(pnStaff);
        private void btnProduct_Click(object sender, EventArgs e) => ShowPage(pnProduct);
        private void btnCustomer_Click(object sender, EventArgs e) => ShowPage(pnCustomer);
        private void btnBill_Click(object sender, EventArgs e) => ShowPage(pnOrderProduct);
        private void btnInsertProduct_Click(object sender, EventArgs e) => ShowPage(pnInformationProduct);

        // Kiểm tra định dạng Email
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Kiểm tra định dạng Số điện thoại (Việt Nam)
        private bool IsValidPhone(string phone)
        {
            string phonePattern = @"^0\d{9}$";
            return Regex.IsMatch(phone, phonePattern);
        }



        //Nút đăng xuất
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo",

                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Form frm = Application.OpenForms["frmLogin"];
                if (frm != null)
                {
                    frm.Show();
                    this.Close();
                }
            }
        }







        //TRANG NHÂN VIÊN
        private void LoadDataNhanVien()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaNV AS 'Mã NV', TenNV AS 'Tên NV', GioiTinh AS 'Giới Tính', NgaySinh AS 'Ngày Sinh', SDT AS 'SĐT', Email, ChucVu AS 'Chức Vụ', TrangThai as 'Trạng Thái', HinhAnh as 'Hình Ảnh' FROM NhanVien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvStaff.DataSource = dataTable;
                    dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.ToString());

                }
            }
        }
     
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtIDStaff.Clear();
            txtNameStaff.Clear();
            txtEmailStaff.Clear();
            txtPhoneNumberStaff.Clear();
            cboPositionStaff.SelectedIndex = -1;
            dtpDateStaff.Value = DateTime.Now;
            picAvatarStaff.Image?.Dispose();
            picAvatarStaff.Image = null;
            currentFileName = "";
            txtNameStaff.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtNameStaff.Text.Trim();
            string email = txtEmailStaff.Text.Trim();
            string phone = txtPhoneNumberStaff.Text.Trim();
            string sex = cboSexStaff.Text;
            string position = cboPositionStaff.Text;
            DateTime date = dtpDateStaff.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập Tên NV!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameStaff.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailStaff.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumberStaff.Focus();
                return;
            }

            if (cboPositionStaff.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Chức vụ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPositionStaff.Focus();
                return;
            }

            if (cboSexStaff.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSexStaff.Focus();
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không đúng định dạng (Ví dụ: abc@gmail.com)!", "Lỗi định dạng");
                txtEmailStaff.Focus();
                return;
            }

            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Số điện thoại phải 10 số và bắt đầu bằng số 0!", "Lỗi định dạng");
                txtPhoneNumberStaff.Focus();
                return;
            }

            string query = "INSERT INTO NhanVien (TenNV, GioiTinh, NgaySinh, SDT, Email, ChucVu, HinhAnh) " +
                   "VALUES (@Ten, @GioiTinh, @NgaySinh, @SDT, @Email, @ChucVu, @HinhAnh)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ten", name);
                    cmd.Parameters.AddWithValue("@GioiTinh", sex);
                    cmd.Parameters.AddWithValue("@NgaySinh", date);
                    cmd.Parameters.AddWithValue("@SDT", phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@ChucVu", position);
                    cmd.Parameters.AddWithValue("@HinhAnh", currentFileName);

                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Thêm nhân viên mới thành công!", "Thành công");
                        LoadDataNhanVien();
                        btnReset_Click(sender, e);
                        currentFileName = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
            }
        }
       
        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDStaff.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa từ bảng dữ liệu!", "Thông báo");
                return;
            }
            string name = txtNameStaff.Text.Trim();
            string email = txtEmailStaff.Text.Trim();
            string phone = txtPhoneNumberStaff.Text.Trim();

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không đúng định dạng (Ví dụ: abc@gmail.com)!", "Lỗi định dạng");
                txtEmailStaff.Focus();
                return;
            }

            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Số điện thoại phải có 10 số và bắt đầu bằng số 0!", "Lỗi định dạng");
                txtPhoneNumberStaff.Focus();
                return;
            }
            string query = "UPDATE NhanVien SET TenNV = @Ten, GioiTinh = @Gioi, NgaySinh = @Ngay, " +
                   "SDT = @SDT, Email = @Email, ChucVu = @ChucVu, HinhAnh = @HinhAnh WHERE MaNV = @Ma";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    //Dùng Mã nhân viên (ID) để check đúng nv cần sửa không
                    cmd.Parameters.AddWithValue("@Ma", txtIDStaff.Text);
                    cmd.Parameters.AddWithValue("@Ten", name);
                    cmd.Parameters.AddWithValue("@Gioi", cboSexStaff.Text);
                    cmd.Parameters.AddWithValue("@Ngay", dtpDateStaff.Value);
                    cmd.Parameters.AddWithValue("@SDT", phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@ChucVu", cboPositionStaff.Text);
                    cmd.Parameters.AddWithValue("@HinhAnh", currentFileName);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thành công");
                        //Load lại bảng dữ liệu
                        LoadDataNhanVien();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại đang được click
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
                //Thêm dữ liệu đươc click vào TexBox..
                txtIDStaff.Text = row.Cells["Mã NV"].Value.ToString();
                txtNameStaff.Text = row.Cells["Tên NV"].Value.ToString();
                cboSexStaff.Text = row.Cells["Giới Tính"].Value.ToString();
                dtpDateStaff.Value = Convert.ToDateTime(row.Cells["Ngày Sinh"].Value);
                txtPhoneNumberStaff.Text = row.Cells["SĐT"].Value.ToString();
                txtEmailStaff.Text = row.Cells["Email"].Value.ToString();
                cboPositionStaff.Text = row.Cells["Chức Vụ"].Value.ToString();

                picAvatarStaff.Image?.Dispose();
                picAvatarStaff.Image = null;

                if (row.Cells["Hình Ảnh"].Value != DBNull.Value)
                {
                    string fileName = row.Cells["Hình Ảnh"].Value.ToString();
                    currentFileName = fileName;
                    string fullPath = Path.Combine(staffImageFolder, fileName);
                    if (File.Exists(fullPath))
                    {
                        byte[] imageBytes = File.ReadAllBytes(fullPath);
                        using (var ms = new MemoryStream(File.ReadAllBytes(fullPath)))
                        {
                            picAvatarStaff.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy file tại: " + fullPath);
                    }
                }
            }
        }

        private void btnRemoveStaff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDStaff.Text))

            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)

            {
                string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                string fileNameToDelete = currentFileName;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaNV", txtIDStaff.Text);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            if (!string.IsNullOrEmpty(fileNameToDelete))
                            {
                                string fullPath = Path.Combine(staffImageFolder, fileNameToDelete);
                                if (File.Exists(fullPath)) File.Delete(fullPath);
                            }
                            MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo");
                            LoadDataNhanVien();
                            btnReset_Click(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Lỗi này hay xảy ra nếu nhân viên này đang có hóa đơn (khóa ngoại)
                        MessageBox.Show("Không thể xóa nhân viên này vì có dữ liệu liên quan! (Lỗi: " + ex.Message + ")");
                    }
                }
            }
        }

        private void FilterNhanVien()
        {
            string nameKey = txtSearchNameStaff.Text.Trim();
            string posKey = cboSearchPositionStaff.Text;
            string query = "SELECT MaNV AS 'Mã NV', TenNV AS 'Tên NV', GioiTinh AS 'Giới Tính', " +
                           "NgaySinh AS 'Ngày Sinh', SDT AS 'SĐT', Email, ChucVu AS 'Chức Vụ', " +
                           "TrangThai as 'Trạng Thái', HinhAnh FROM NhanVien WHERE (TenNV LIKE @Ten)";

            if (posKey != "Tất cả" && !string.IsNullOrEmpty(posKey))
            {
                query += " AND ChucVu = @ChucVu";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ten", "%" + nameKey + "%");

                    if (posKey != "Tất cả" && !string.IsNullOrEmpty(posKey))
                    {
                        cmd.Parameters.AddWithValue("@ChucVu", posKey);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvStaff.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lọc: " + ex.Message);
                }
            }
        }
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {

            FilterNhanVien();
        }

        private void cboSearchPosition_SelectedIndexChanged(object sender, EventArgs e)

        {
            FilterNhanVien();
        }

        private void btnUpLoadAvatar_Click(object sender, EventArgs e)

        {

            picAvatar_Click(sender, e);

        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picAvatarStaff.Image?.Dispose();
                    byte[] imageBytes = File.ReadAllBytes(ofd.FileName);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        picAvatarStaff.Image = Image.FromStream(ms);
                    }
                    picAvatarStaff.SizeMode = PictureBoxSizeMode.StretchImage;
                    currentFileName = Guid.NewGuid() + Path.GetExtension(ofd.FileName);
                    if (!Directory.Exists(staffImageFolder)) Directory.CreateDirectory(staffImageFolder);
                    string destPath = Path.Combine(staffImageFolder, currentFileName);
                    File.Copy(ofd.FileName, destPath, true);
                }
            }
        }

        private void btnApplyStaff_Click(object sender, EventArgs e)
        {
            FilterNhanVien();
        }

        private void btnClearStaff_Click(object sender, EventArgs e)
        {
            txtSearchNameStaff.Clear();
            LoadDataKhachHang();
        }

        private void btnUpLoadAvatarStaff_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.png; *.jpeg)|*.jpg;*.png;*.jpeg";
                ofd.Title = "Chọn ảnh nhân viên";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Hiện thị lên pictureBox
                        picAvatarStaff.Image?.Dispose(); //Giải phóng ảnh cũ
                        byte[] imageBytes = File.ReadAllBytes(ofd.FileName);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            picAvatarStaff.Image = Image.FromStream(ms);
                        }
                        picAvatarStaff.SizeMode = PictureBoxSizeMode.StretchImage;

                        //Tạo tên file duy nhất bằng Guid để không bao giờ bị trùng
                        currentFileName = Guid.NewGuid().ToString() + Path.GetExtension(ofd.FileName);

                        //Kiểm tra và Tự động tạo thư mục nếu chưa có (Tránh lỗi không tìm thấy đường dẫn)
                        if (!Directory.Exists(staffImageFolder))
                        {
                            Directory.CreateDirectory(staffImageFolder);
                        }

                        //Copy file từ máy vào thư mục dự án 
                        string destPath = Path.Combine(staffImageFolder, currentFileName);
                        File.Copy(ofd.FileName, destPath, true);

                        MessageBox.Show("Đã tải và tạo file ảnh thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xử lý ảnh: " + ex.Message);
                    }
                }
            }
        }






        //TRANG KHÁCH HÀNG
        private void LoadDataKhachHang()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaKH AS 'Mã KH', TenKH AS 'Tên KH', GioiTinh AS 'Giới Tính', " +
                                   "SDT AS 'SĐT', Email, DiaChi AS 'Địa Chỉ', NgayDK AS 'Ngày Đăng Ký' FROM KhachHang";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCustomer.DataSource = dt;

                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải khách hàng: " + ex.Message); }
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO KhachHang (TenKH, GioiTinh, SDT, Email, DiaChi, NgayDK) " +
                   "VALUES (@Ten, @Gioi, @SDT, @Email, @Dia, @Ngay)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (!IsValidEmail(txtEmailCustomer.Text))
                {

                    MessageBox.Show("Email không đúng định dạng (Ví dụ: abc@gmail.com)!", "Lỗi định dạng");

                    txtEmailCustomer.Focus();
                    return;
                }

                if (!IsValidPhone(txtPhoneNumberCustomer.Text))
                {
                    MessageBox.Show("Số điện thoại phải 10 số và bắt đầu bằng số 0!", "Lỗi định dạng");
                    txtPhoneNumberCustomer.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNameCustomer.Text))
                {
                    MessageBox.Show("Vui lòng nhập Tên KH!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNameCustomer.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAddressCustomer.Text))
                {
                    MessageBox.Show("Vui lòng nhập Địa chỉ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddressCustomer.Focus();
                    return;
                }

                if (cboSexCustomer.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSexCustomer.Focus();
                    return;
                }

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ten", txtNameCustomer.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gioi", cboSexCustomer.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtPhoneNumberCustomer.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmailCustomer.Text.Trim());
                    cmd.Parameters.AddWithValue("@Dia", txtAddressCustomer.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ngay", dtpRegistrationDateCustomer.Value);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm khách hàng thành công!");
                        LoadDataKhachHang();
                    }
                }
                catch (SqlException ex)
                {
                    // Lỗi 2627 là lỗi trùng khóa Unique (Số điện thoại)
                    if (ex.Number == 2627) MessageBox.Show("Số điện thoại này đã được đăng ký!");
                    else MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];
                txtIDCustomer.Text = row.Cells["Mã KH"].Value.ToString();
                txtNameCustomer.Text = row.Cells["Tên KH"].Value.ToString();
                cboSexCustomer.Text = row.Cells["Giới Tính"].Value.ToString();
                txtPhoneNumberCustomer.Text = row.Cells["SĐT"].Value.ToString();
                txtEmailCustomer.Text = row.Cells["Email"].Value.ToString();
                txtAddressCustomer.Text = row.Cells["Địa Chỉ"].Value.ToString();
                dtpRegistrationDateCustomer.Value = Convert.ToDateTime(row.Cells["Ngày Đăng Ký"].Value);
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDCustomer.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ bảng!", "Thông báo");
                return;
            }

            string query = "UPDATE KhachHang SET TenKH = @Ten, GioiTinh = @Gioi, SDT = @SDT, " +
                           "Email = @Email, DiaChi = @Dia, NgayDK = @Ngay WHERE MaKH = @Ma";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ma", txtIDCustomer.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtNameCustomer.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gioi", cboSexCustomer.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtPhoneNumberCustomer.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmailCustomer.Text.Trim());
                    cmd.Parameters.AddWithValue("@Dia", txtAddressCustomer.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ngay", dtpRegistrationDateCustomer.Value);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thành công");
                        LoadDataKhachHang();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }
        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDCustomer.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                string query = "DELETE FROM KhachHang WHERE MaKH = @Ma";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Ma", txtIDCustomer.Text);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã xóa khách hàng!");
                            LoadDataKhachHang();
                            btnResetCustomer_Click(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xóa khách hàng này vì đã có lịch sử mua hàng! (Lỗi: " + ex.Message + ")");
                    }
                }
            }
        }

        private void btnResetCustomer_Click(object sender, EventArgs e)
        {

            txtIDCustomer.Clear();
            txtNameCustomer.Clear();
            txtPhoneNumberCustomer.Clear();
            txtEmailCustomer.Clear();
            txtAddressCustomer.Clear();
            cboSexCustomer.SelectedIndex = -1;
            dtpRegistrationDateCustomer.Value = DateTime.Now;
            txtNameCustomer.Focus();
        }

        private void FilterKhachHang()
        {
            string nameKey = txtSearchNameCustomer.Text.Trim();

            string query = "SELECT MaKH AS 'Mã KH', TenKH AS 'Tên KH', GioiTinh AS 'Giới Tính', " +
                           "SDT AS 'SĐT', Email, DiaChi AS 'Địa Chỉ', NgayDK AS 'Ngày Đăng Ký' " +
                           "FROM KhachHang WHERE TenKH LIKE @Ten";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ten", "%" + nameKey + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCustomer.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lọc: " + ex.Message);
                }
            }
        }
        private void btnApplyCustomer_Click(object sender, EventArgs e)
        {
            FilterKhachHang();
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            txtSearchNameCustomer.Clear();
            FilterKhachHang();
        }









        //TRANG SẢN PHẨM
        private void LoadDataSanPham()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT s.MaSP AS 'Mã SP', s.TenSP AS 'Tên SP', l.TenLoaiSP AS 'Loại SP', 
                             s.SoLuongTon AS 'Số lượng', s.DVT, s.GiaBan AS 'Đơn giá', s.TrangThai, s.HinhAnh
                             FROM SanPham s 
                             INNER JOIN LoaiSP l ON s.MaLoai = l.MaLoai";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvProduct.DataSource = dt;

                    if (dgvProduct.Columns.Contains("HinhAnh"))
                    {
                        dgvProduct.Columns["HinhAnh"].Visible = false;
                    }
                    dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];

                txtIDProduct.Text = row.Cells["Mã SP"].Value.ToString();
                txtNameProduct.Text = row.Cells["Tên SP"].Value.ToString();
                txtQuantityProduct.Text = row.Cells["Số lượng"].Value.ToString();
                txtUnitProduct.Text = row.Cells["DVT"].Value.ToString();
                txtPriceProduct.Text = row.Cells["Đơn giá"].Value.ToString();
                cboTypeProduct.Text = row.Cells["Loại SP"].Value.ToString();
                picAvatarProduct.Image?.Dispose();
                picAvatarProduct.Image = null;
                currentFileName = "";

                if (row.Cells["HinhAnh"].Value != DBNull.Value && !string.IsNullOrEmpty(row.Cells["HinhAnh"].Value.ToString()))
                {
                    string fileName = row.Cells["HinhAnh"].Value.ToString();
                    currentFileName = fileName;
                    string fullPath = Path.Combine(productImageFolder, fileName);

                    if (File.Exists(fullPath))
                    {
                        using (var ms = new MemoryStream(File.ReadAllBytes(fullPath)))
                        {
                            picAvatarProduct.Image = Image.FromStream(ms);
                        }
                        picAvatarProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDProduct.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
                return;
            }

            string query = "UPDATE SanPham SET TenSP=@Ten, MaLoai=@MaLoai, DVT=@DVT, " +
                           "SoLuongTon=@SL, GiaBan=@Gia, HinhAnh=@Hinh WHERE MaSP=@Ma";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ma", txtIDProduct.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtNameProduct.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaLoai", cboTypeProduct.SelectedValue);
                    cmd.Parameters.AddWithValue("@DVT", txtUnitProduct.Text.Trim());
                    cmd.Parameters.AddWithValue("@SL", txtQuantityProduct.Text);
                    cmd.Parameters.AddWithValue("@Gia", txtPriceProduct.Text);
                    cmd.Parameters.AddWithValue("@Hinh", currentFileName);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công!");
                        LoadDataSanPham();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi cập nhật SP: " + ex.Message); }
            }
        }

        private void FilterSanPham()
        {
            string nameKey = txtSearchNameProduct.Text.Trim();
            int maLoai = 0;
            if (cboSearchTypeProduct.SelectedValue != null)
            {
                int.TryParse(cboSearchTypeProduct.SelectedValue.ToString(), out maLoai);
            }
            string query = @"SELECT s.MaSP AS 'Mã SP', s.TenSP AS 'Tên SP', l.TenLoaiSP AS 'Loại SP', 
                     s.SoLuongTon AS 'Số lượng', s.DVT, s.GiaBan AS 'Đơn giá', s.TrangThai, s.HinhAnh
                     FROM SanPham s 
                     INNER JOIN LoaiSP l ON s.MaLoai = l.MaLoai
                     WHERE s.TenSP LIKE @Ten";
            if (maLoai > 0)
            {
                query += " AND s.MaLoai = @MaLoai";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ten", "%" + nameKey + "%");
                    
                    if (maLoai > 0) cmd.Parameters.AddWithValue("@MaLoai", maLoai);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvProduct.DataSource = dt;
                    
                    if (dgvProduct.Columns.Contains("HinhAnh")) dgvProduct.Columns["HinhAnh"].Visible = false;
                }
                catch (Exception) { }
            }
        }

        private void btnDiscontinuedProduct_Click(object sender, EventArgs e)
        {
            UpdateProductStatus("Ngừng kinh doanh", "Sản phẩm đã ngừng kinh doanh!");
        }

        private void btnResumedProduct_Click(object sender, EventArgs e)
        {
            UpdateProductStatus("Đang kinh doanh", "Sản phẩm đã được mở bán lại!");
        }

        private void UpdateProductStatus(string status, string message)
        {
            if (string.IsNullOrEmpty(txtIDProduct.Text))
            {
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE SanPham SET TrangThai = @Status WHERE MaSP = @Ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Ma", txtIDProduct.Text);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(message);
                    LoadDataSanPham();
                }
            }
        }

        private void btnResetProduct_Click(object sender, EventArgs e)
        {
            txtIDProduct.Clear();
            txtNameProduct.Clear();
            txtQuantityProduct.Clear();
            txtUnitProduct.Clear();
            txtPriceProduct.Clear();
            cboTypeProduct.SelectedIndex = -1;
            picAvatarProduct.Image?.Dispose();
            picAvatarProduct.Image = null;
            currentFileName = "";
            txtNameProduct.Focus();
        }

        private void btnUploadAvatarProduct_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picAvatarProduct.Image?.Dispose();

                    byte[] imageBytes = File.ReadAllBytes(ofd.FileName);

                    using (var ms = new MemoryStream(imageBytes))
                    {
                        picAvatarProduct.Image = Image.FromStream(ms);
                    }
                    picAvatarProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    currentFileName = Guid.NewGuid() + Path.GetExtension(ofd.FileName);

                    if (!Directory.Exists(productImageFolder)) Directory.CreateDirectory(productImageFolder);

                    string destPath = Path.Combine(productImageFolder, currentFileName);
                    File.Copy(ofd.FileName, destPath, true);

                }

            }

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameProduct.Text) || cboTypeProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm và chọn loại hàng!", "Thông báo");
                return;
            }

            string query = "INSERT INTO SanPham (TenSP, MaLoai, DVT, SoLuongTon, GiaBan, HinhAnh, TrangThai) " +
                           "VALUES (@Ten, @MaLoai, @DVT, @SL, @Gia, @Hinh, @TrangThai)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ten", txtNameProduct.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaLoai", cboTypeProduct.SelectedValue);
                    cmd.Parameters.AddWithValue("@DVT", txtUnitProduct.Text.Trim());
                    cmd.Parameters.AddWithValue("@SL", string.IsNullOrEmpty(txtQuantityProduct.Text) ? 0 : int.Parse(txtQuantityProduct.Text));
                    cmd.Parameters.AddWithValue("@Gia", string.IsNullOrEmpty(txtPriceProduct.Text) ? 0 : decimal.Parse(txtPriceProduct.Text));
                    cmd.Parameters.AddWithValue("@Hinh", string.IsNullOrEmpty(currentFileName) ? (object)DBNull.Value : currentFileName);
                    cmd.Parameters.AddWithValue("@TrangThai", "Đang kinh doanh");
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo");
                        LoadDataSanPham();
                        btnResetProduct_Click(sender, e);
                        currentFileName = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
                }
            }
        }

        private void LoadComboBoxLoaiSP()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT MaLoai, TenLoaiSP FROM LoaiSP", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboTypeProduct.DataSource = dt;
                    cboTypeProduct.DisplayMember = "TenLoaiSP";
                    cboTypeProduct.ValueMember = "MaLoai";
                    cboTypeProduct.SelectedIndex = -1;

                    DataTable dtSearch = dt.Copy();
                    DataRow dr = dtSearch.NewRow();
                    dr["MaLoai"] = 0;
                    dr["TenLoaiSP"] = "--- Tất cả loại ---";
                    dtSearch.Rows.InsertAt(dr, 0);

                    DataTable dtOrder = dt.Copy();
                    DataRow drdiagResult = dtOrder.NewRow();
                    drdiagResult["MaLoai"] = 0;
                    drdiagResult["TenLoaiSP"] = "--- Tất cả loại ---";
                    dtOrder.Rows.InsertAt(drdiagResult, 0);
                    cboSearchOrderProductType.DataSource = dtOrder;
                    cboSearchOrderProductType.DisplayMember = "TenLoaiSP";
                    cboSearchOrderProductType.ValueMember = "MaLoai";
                    cboSearchOrderProductType.SelectedIndex = 0;

                    cboSearchTypeProduct.DataSource = dtSearch;
                    cboSearchTypeProduct.DisplayMember = "TenLoaiSP";
                    cboSearchTypeProduct.ValueMember = "MaLoai";
                    cboSearchTypeProduct.SelectedIndex = 0;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi nạp loại SP: " + ex.Message); }
            }
        }

        private void btnApplyProduct_Click(object sender, EventArgs e)
        {
            FilterSanPham();
        }

        private void btnClearProduct_Click(object sender, EventArgs e)
        {
            FilterSanPham();

        }




        //TRANG ORDER SẢN PHẨM
        private void SetupCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("MaSP", typeof(int));
            cartTable.Columns.Add("TenSP", typeof(string));
            cartTable.Columns.Add("SoLuong", typeof(int));
            cartTable.Columns.Add("DonGia", typeof(decimal));
            cartTable.Columns.Add("ThanhTien", typeof(decimal), "SoLuong * DonGia");
            dgvCart.DataSource = cartTable;
            dgvCart.Columns["MaSP"].HeaderText = "Mã SP";
            dgvCart.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvCart.Columns["SoLuong"].HeaderText = "SL";
            dgvCart.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvCart.Columns["ThanhTien"].HeaderText = "Thành Tiền";
        }
        private void LoadDataSanPhamChoBanHang()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT MaSP AS 'Mã SP', TenSP AS 'Tên SP', GiaBan AS 'Đơn giá', SoLuongTon AS 'Số lượng' 
                         FROM SanPham WHERE TrangThai = N'Đang kinh doanh'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvProductsOrder.DataSource = dt;
            }
        }

        private void TinhTongTien()
        {
            decimal tongCong = 0;
            foreach (DataRow row in cartTable.Rows)
            {
                tongCong += Convert.ToDecimal(row["ThanhTien"]);
            }
            lblTotalAmount.Text = tongCong.ToString("N0") + " VNĐ";
            lblTotalAmount.ForeColor = Color.Red;
            lblTotalAmount.Font = new Font(lblTotalAmount.Font, FontStyle.Bold);
        }

        private void FilterOrderProduct()
        {
            string nameKey = txtSearchOrderProductName.Text.Trim();
            string maLoai = cboSearchOrderProductType.SelectedValue?.ToString();
            string query = @"SELECT MaSP AS 'Mã SP', TenSP AS 'Tên SP', GiaBan AS 'Đơn giá', SoLuongTon AS 'Số lượng'
                     FROM SanPham WHERE TenSP LIKE @Ten AND TrangThai = N'Đang kinh doanh'";

            if (cboSearchOrderProductType.SelectedIndex > 0)
                query += " AND MaLoai = @MaLoai";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten", "%" + nameKey + "%");
                if (cboSearchOrderProductType.SelectedIndex > 0) cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvProductsOrder.DataSource = dt;
            }
        }

        private void btnApplySearchOrderProduct_Click(object sender, EventArgs e)
        {
            FilterOrderProduct();
        }
        
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa toàn bộ giỏ hàng?", "Hủy đơn",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cartTable.Clear();
                TinhTongTien();
            }
        }

        private void LoadComboBoxKhachHang()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT MaKH, TenKH FROM KhachHang", conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboCustomerOrder.DataSource = dt;
                cboCustomerOrder.DisplayMember = "TenKH";
                cboCustomerOrder.ValueMember = "MaKH";
                cboCustomerOrder.SelectedIndex = -1;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra điều kiện trước khi mở bảng thanh toán
            if (cboCustomerOrder.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo");
                return;
            }
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo");
                return;
            }

            // 2. Khởi tạo Form Thanh toán (frmPayment)
            // Lưu ý: Đảm bảo namespace của frmPayment đã được using
            Order.frmPayment fPay = new Order.frmPayment();

            // 3. Truyền toàn bộ dữ liệu sang các biến public mà Đương vừa tạo
            fPay.MaKH_Nhan = Convert.ToInt32(cboCustomerOrder.SelectedValue);
            fPay.TenKH_Nhan = cboCustomerOrder.Text;
            fPay.MaNV_Nhan = this.MaNV_DangNhap; // Lấy mã NV đang đăng nhập ở frmMain
            fPay.GioHang_Nhan = this.cartTable;  // Truyền cái giỏ hàng ảo sang để trừ kho

            // Tính tổng tiền gửi qua
            decimal tong = 0;
            foreach (DataRow r in cartTable.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);
            fPay.TongTien_Nhan = tong;

            // 4. Hiển thị Form dưới dạng Dialog (Chặn thao tác bên dưới cho đến khi xong)
            if (fPay.ShowDialog() == DialogResult.OK)
            {
                // Nếu bên frmPayment bấm "Thanh toán thành công" (DialogResult.OK)
                // Thì ở đây ta xóa trắng giỏ hàng và load lại sản phẩm
                cartTable.Clear();
                TinhTongTien();
                LoadDataSanPhamChoBanHang();
                cboCustomerOrder.SelectedIndex = -1;
            }
        }
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (MessageBox.Show("Bạn muốn xóa món này khỏi giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cartTable.Rows.RemoveAt(e.RowIndex);
                    TinhTongTien();
                }
            }
        }

        private void btnApplySearchOrderProduct_Click_1(object sender, EventArgs e)
        {
            FilterOrderProduct();
        }

        private void btnRefreshSearchOrderProduct_Click(object sender, EventArgs e)
        {
            FilterOrderProduct();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProductsOrder.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo");
                return;
            }
            int maSP = Convert.ToInt32(dgvProductsOrder.CurrentRow.Cells["Mã SP"].Value);
            string tenSP = dgvProductsOrder.CurrentRow.Cells["Tên SP"].Value.ToString();
            decimal gia = Convert.ToDecimal(dgvProductsOrder.CurrentRow.Cells["Đơn giá"].Value);
            int soLuongMua = (int)nudQuantityOrder.Value;
            if (soLuongMua <= 0) { MessageBox.Show("Số lượng phải > 0"); return; }

            DialogResult dr = MessageBox.Show($"Thêm {soLuongMua} [{tenSP}] vào giỏ?", "Xác nhận",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                bool existed = false;
                foreach (DataRow row in cartTable.Rows)
                {
                    if ((int)row["MaSP"] == maSP)
                    {
                        row["SoLuong"] = (int)row["SoLuong"] + soLuongMua;
                        existed = true;
                        break;
                    }
                }
                if (!existed) cartTable.Rows.Add(maSP, tenSP, soLuongMua, gia);

                TinhTongTien();

                nudQuantityOrder.Value = 1;

            }
        }








        //TRANG NHẬP SẢN PHẨM
        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvProductList.Rows[e.RowIndex];
                txtImportProductID.Text = r.Cells["MaSP"].Value.ToString();
                txtImportProductName.Text = r.Cells["TenSP"].Value.ToString();
            }
        }

        private void dgvSupplierInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectedMaNCC = Convert.ToInt32(dgvSupplierInformation.Rows[e.RowIndex].Cells["MaNCC"].Value);
        }

        private void btnImportProduct_Click(object sender, EventArgs e)
        {
            if (selectedMaNCC == -1) { MessageBox.Show("Vui lòng chọn Nhà cung cấp!"); return; }
            if (string.IsNullOrEmpty(txtImportProductID.Text)) { MessageBox.Show("Vui lòng chọn sản phẩm!"); return; }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    //Tạo phiếu nhập
                    string sqlPN = "INSERT INTO PhieuNhap (NgayNhap, MaNV, MaNCC, TongTienNhap) VALUES (GETDATE(), @maNV, @maNCC, @tong); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdPN = new SqlCommand(sqlPN, conn, trans);
                    cmdPN.Parameters.AddWithValue("@maNV", MaNV_DangNhap);
                    cmdPN.Parameters.AddWithValue("@maNCC", selectedMaNCC);
                    decimal giaNhap = decimal.Parse(txtImportPrice.Text);
                    int slNhap = int.Parse(txtImportQuantity.Text);
                    cmdPN.Parameters.AddWithValue("@tong", giaNhap * slNhap);
                    int maPN = Convert.ToInt32(cmdPN.ExecuteScalar());

                    //Chi tiết phiếu nhập
                    string sqlCT = "INSERT INTO ChiTietPhieuNhap (MaPN, MaSP, SoLuongNhap, DonGiaNhap) VALUES (@maPN, @maSP, @sl, @gia)";
                    SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                    cmdCT.Parameters.AddWithValue("@maPN", maPN);
                    cmdCT.Parameters.AddWithValue("@maSP", txtImportProductID.Text);
                    cmdCT.Parameters.AddWithValue("@sl", slNhap);
                    cmdCT.Parameters.AddWithValue("@gia", giaNhap);
                    cmdCT.ExecuteNonQuery();

                    //Cộng số lượng nhập vào kho
                    string sqlUp = "UPDATE SanPham SET SoLuongTon = SoLuongTon + @sl WHERE MaSP = @maSP";
                    SqlCommand cmdUp = new SqlCommand(sqlUp, conn, trans);
                    cmdUp.Parameters.AddWithValue("@sl", slNhap);
                    cmdUp.Parameters.AddWithValue("@maSP", txtImportProductID.Text);
                    cmdUp.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Nhập kho thành công!");
                    LoadDataChoNhapHang();
                }
                catch (Exception ex) { trans.Rollback(); MessageBox.Show("Lỗi nhập hàng: " + ex.Message); }
            }
        }

        private void LoadDataChoNhapHang()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    //Load danh sách sản phẩm hiện có để nhân viên chọn nhập thêm
                    string sqlSP = "SELECT MaSP, TenSP, SoLuongTon, DVT FROM SanPham";
                    SqlDataAdapter daSP = new SqlDataAdapter(sqlSP, conn);
                    DataTable dtSP = new DataTable();
                    daSP.Fill(dtSP);
                    dgvProductList.DataSource = dtSP;

                    //Load danh sách Nhà Cung Cấp để biết nhập hàng từ ai
                    string sqlNCC = "SELECT MaNCC, TenNCC, DiaChi FROM NhaCungCap";
                    SqlDataAdapter daNCC = new SqlDataAdapter(sqlNCC, conn);
                    DataTable dtNCC = new DataTable();
                    daNCC.Fill(dtNCC);
                    dgvSupplierInformation.DataSource = dtNCC;

                    dgvProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvSupplierInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu nhập hàng: " + ex.Message);
                }
            }
        }












        //TRANG HOME
        private void HienThiTenNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT TenNV FROM NhanVien WHERE MaNV = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", MaNV_DangNhap);
                conn.Open();
                object result = cmd.ExecuteScalar();
                // lblStaffName là tên cái Label hiện tên NV của bạn
                if (result != null) lblStaffGreeting.Text = "NV: " + result.ToString();
            }
        }


    }
}

