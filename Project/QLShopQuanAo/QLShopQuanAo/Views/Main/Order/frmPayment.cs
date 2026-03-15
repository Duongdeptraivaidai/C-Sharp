using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using QLShopQuanAo.Services;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopQuanAo.Views.Main.Order
{
    public partial class frmPayment : Form
    {
        public int MaKH_Nhan { get; set; }
        public string TenKH_Nhan { get; set; }
        public decimal TongTien_Nhan { get; set; }  
        public int MaNV_Nhan { get; set; }
        public DataTable GioHang_Nhan { get; set; }
        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            txtIDCustomerPay.Text = MaKH_Nhan.ToString();
            txtNameCustomerPay.Text = TenKH_Nhan;
            lblCustomerTotalAmountPay.Text = TongTien_Nhan.ToString("N0") + " VNĐ";

            txtCustomerAmountTendered.Focus();
        }

        private void txtCustomerAmountTendered_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal khachTra = decimal.Parse(txtCustomerAmountTendered.Text);   
                lblCustomerChange.Text = (khachTra - TongTien_Nhan).ToString("N0") + " VNĐ";
            }
            catch { }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Xác nhận thanh toán hóa đơn này?", "Xác nhận",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Kiểm tra xem khách đã trả đủ tiền chưa (Tùy chọn)
                decimal khachTra = 0;
                decimal.TryParse(txtCustomerAmountTendered.Text, out khachTra);
                if (khachTra < TongTien_Nhan)
                {
                    MessageBox.Show("Tiền khách trả không đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //GỌI SERVICE ĐỂ LƯU VÀO SQL (Phần quan trọng nhất)
                OrderService service = new OrderService();
                string message = "";

                // Sử dụng hàm ProcessPayment trong OrderService.cs
                bool thanhCong = service.ProcessPayment(MaNV_Nhan, MaKH_Nhan, GioHang_Nhan, out message);

                if (thanhCong)
                {
                    MessageBox.Show("Thanh toán thành công và đã cập nhật kho hàng!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại: " + message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
