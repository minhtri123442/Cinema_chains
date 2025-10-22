using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Chains
{
    public partial class Frm_DangNhap : Form
    {
        public Frm_DangNhap()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetPlaceholder();
            this.ActiveControl = label1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void SetPlaceholder()
        {
            txt_EmailDangNhap.Text = "Nhập gmail";
            txt_EmailDangNhap.ForeColor = Color.Gray;
            txt_MKDangNhap.Text = "Nhập mật khẩu";
            txt_MKDangNhap.ForeColor = Color.Gray;
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txt_EmailDangNhap.Text == "Nhập gmail")
            {
                txt_EmailDangNhap.Text = "";
                txt_EmailDangNhap.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_EmailDangNhap.Text))
            {
                txt_EmailDangNhap.Text = "Nhập gmail";
                txt_EmailDangNhap.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (txt_MKDangNhap.Text == "Nhập mật khẩu")
            {
                txt_MKDangNhap.Text = "";
                txt_MKDangNhap.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MKDangNhap.Text))
            {
                txt_MKDangNhap.Text = "Nhập mật khẩu";
                txt_MKDangNhap.ForeColor = Color.Gray;
            }
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            Frm_DangKy frm = new Frm_DangKy();
            frm.Show(this);
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if(txt_EmailDangNhap.Text == "admin" && txt_MKDangNhap.Text == "123456")
            {
                Frm_GiaoDienAdmin frm1 = new Frm_GiaoDienAdmin();
                frm1.Show(this);
            }
            else 
            {
                Frm_GiaoDienKhachHang frm = new Frm_GiaoDienKhachHang();
                frm.Show(this);
            } 
                
               
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_DangKy frm = new Frm_DangKy();
            frm.Show(this);
        }

        private void linklb_QuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // 🔹 Sinh mã ngẫu nhiên 6 chữ số
                Random random = new Random();
                int code = random.Next(100000, 999999);
                string verificationCode = code.ToString();

                // 🔹 Thông tin người gửi
                string from = "22211tt2704@mail.tdc.edu.vn"; // Gmail của bạn
                string appPassword = "ubvgchnfqutxnyba";   // Mật khẩu ứng dụng (16 ký tự)
                string to = txt_EmailDangNhap.Text.Trim(); // Gmail người nhận

                // 🔹 Tạo đối tượng MailMessage
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = "Mã xác nhận của bạn";
                mail.Body = $"Mã xác nhận của bạn là: {verificationCode}";
                mail.IsBodyHtml = false; // Đặt true nếu muốn nội dung có HTML

                // 🔹 Cấu hình SMTP Client
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(from, appPassword);
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(mail);
                }

                MessageBox.Show($"✅ Đã gửi mã xác nhận đến: {to}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi gửi mail: " + ex.Message, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
