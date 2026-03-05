using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Form1 : Form
    {
        // 1. Dùng Dictionary để quản lý mã code và nhóm nhân viên cho dễ mở rộng
        private readonly Dictionary<string, string> securityCodes = new Dictionary<string, string>
        {
            { "1645", "Technicians" }, { "1689", "Technicians" },
            { "8345", "Custodians" },
            { "9998", "Scientist" }, { "1006", "Scientist" }, { "1008", "Scientist" }
        };

        public Form1()
        {
            InitializeComponent();
            SetupNumberButtons();
        }

        // 2. Tự động gán sự kiện cho các nút số 0-9
        private void SetupNumberButtons()
        {
            foreach (Control c in this.Controls)
            {
                // Kiểm tra nếu là Button và Text chỉ là 1 ký tự số
                if (c is Button btn && btn.Text.Length == 1 && char.IsDigit(btn.Text[0]))
                {
                    btn.Click += NumberButton_Click;
                }
            }
        }

        // 3. Xử lý nhập số vào ô Security Code
        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && txt_SecurityCode.Text.Length < 4)
            {
                txt_SecurityCode.Text += btn.Text;
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_SecurityCode.Clear();
            txt_SecurityCode.BackColor = Color.White;
        }

        // 4. Logic kiểm tra mã và ghi log theo yêu cầu tài liệu
        private void btn_CheckCode_Click(object sender, EventArgs e)
        {
            string input = txt_SecurityCode.Text;
            string time = DateTime.Now.ToString("dd/MM/yyyy h:mm tt");
            string status;

            // Kiểm tra các trường hợp đặc biệt theo yêu cầu
            if (string.IsNullOrEmpty(input)) return;

            if (securityCodes.ContainsKey(input))
            {
                // Trạng thái Granted: Hiển thị nhóm nhân viên
                status = securityCodes[input];
                txt_SecurityCode.BackColor = Color.LightGreen;
            }
            else if (input.Length == 1)
            {
                // Nhấn 1 con số: Hiển thị Restricted Access
                status = "Restricted Access!";
                txt_SecurityCode.BackColor = Color.Orange;
            }
            else
            {
                // Sai mã: Hiển thị Access denied
                status = "Access denied";
                txt_SecurityCode.BackColor = Color.Salmon;
            }

            // Ghi nhật ký vào ListBox (Tin mới nhất lên đầu)
            lst_AccessLog.Items.Insert(0, $"{time}    {status}");

            // Tự động reset sau 1 giây để đón lượt nhập tiếp theo
            ResetAfterDelay();
        }

        private void ResetAfterDelay()
        {
            Timer timer = new Timer { Interval = 1000 };
            timer.Tick += (s, ev) => {
                txt_SecurityCode.Clear();
                txt_SecurityCode.BackColor = Color.White;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Chuyển ký tự hiển thị thành dấu *
            txt_SecurityCode.PasswordChar = '*';

            // Ngăn người dùng nhập từ bàn phím máy tính, chỉ cho phép bấm nút trên màn hình
            txt_SecurityCode.ReadOnly = true;
        }
    }
}