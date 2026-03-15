using System;
using System.Data;
using System.Data.SqlClient;

namespace QLShopQuanAo.Services
{
    public class OrderService
    {
        string connectionString = @"Data Source=DESKTOP-10UJ2O8\SQLEXPRESS;Initial Catalog=QLShopQuanAo;Integrated Security=True";

        public bool ProcessPayment(int maNV, int maKH, DataTable gioHang, out string message)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Lưu Hóa Đơn
                    string sqlHD = "INSERT INTO HoaDon (NgayLap, MaNV, MaKH, TongTien) VALUES (GETDATE(), @MaNV, @MaKH, @Tong); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans);
                    cmdHD.Parameters.AddWithValue("@MaNV", maNV);
                    cmdHD.Parameters.AddWithValue("@MaKH", maKH);

                    decimal tong = 0;
                    foreach (DataRow r in gioHang.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);
                    cmdHD.Parameters.AddWithValue("@Tong", tong);

                    int maHD = Convert.ToInt32(cmdHD.ExecuteScalar());

                    // 2. Lưu Chi Tiết & Trừ Kho
                    foreach (DataRow row in gioHang.Rows)
                    {
                        SqlCommand cmdCT = new SqlCommand("INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SL, @Gia)", conn, trans);
                        cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                        cmdCT.Parameters.AddWithValue("@MaSP", row["MaSP"]);
                        cmdCT.Parameters.AddWithValue("@SL", row["SoLuong"]);
                        cmdCT.Parameters.AddWithValue("@Gia", row["DonGia"]);
                        cmdCT.ExecuteNonQuery();

                        SqlCommand cmdUp = new SqlCommand("UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL WHERE MaSP = @MaSP", conn, trans);
                        cmdUp.Parameters.AddWithValue("@SL", row["SoLuong"]);
                        cmdUp.Parameters.AddWithValue("@MaSP", row["MaSP"]);
                        cmdUp.ExecuteNonQuery();
                    }

                    trans.Commit();
                    message = "Thành công!";
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    message = ex.Message;
                    return false;
                }
            }
        }
    }
}