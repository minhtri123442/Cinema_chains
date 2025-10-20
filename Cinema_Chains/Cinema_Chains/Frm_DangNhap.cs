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
using BUL;
using DTO;

namespace Cinema_Chains
{
    public partial class Frm_DangNhap : Form
    {
        private readonly BUS_NhanVien busNV = new BUS_NhanVien();
        public Frm_DangNhap()
        {
            InitializeComponent();
        }

        private void Frm_DangNhap_Load(object sender, EventArgs e)
        {
            SetPlaceholder();
            this.ActiveControl = label1;
            txt_EmailDangNhap.Focus();
            txt_EmailDangNhap.MaxLength = 30;
            txt_MKDangNhap.MaxLength = 20;
            txt_EmailDangNhap.TextChanged += txt_EmailDangNhap_TextChanged;
            txt_MKDangNhap.TextChanged += txt_MKDangNhap_TextChanged;

            lbLoiEmail.Visible = false;
            lbLoiMK.Visible = false;
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

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {

            if(txt_EmailDangNhap.Text == "admin" && txt_MKDangNhap.Text == "123456")
            {
                Frm_GiaoDienAdmin frm = new Frm_GiaoDienAdmin();
                frm.ShowDialog();
                this.Close();
            }

            string email = txt_EmailDangNhap.Text.Trim();
            string matKhau = txt_MKDangNhap.Text.Trim();

            // Nếu trống -> báo lỗi (chỉ khi nhấn nút)
            if (string.IsNullOrEmpty(email))
            {
                lbLoiEmail.Text = "Vui lòng nhập email!";
                lbLoiEmail.Visible = true;
            }
            if (string.IsNullOrEmpty(matKhau))
            {
                lbLoiMK.Text = "Vui lòng nhập mật khẩu!";
                lbLoiMK.Visible = true;
            }
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
                return;

            // Kiểm tra email + mật khẩu hợp lệ
            if (!KiemTraEmailHopLe(email))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!KiemTraMatKhauHopLe(matKhau))
            {
                MessageBox.Show("Mật khẩu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DTO_NhanVien nv = busNV.DangNhap(email, matKhau);
            if (nv != null)
            {
                // Nếu đăng nhập đúng
                MessageBox.Show($"Đăng nhập thành công!\nXin chào {nv.HoTen} ({nv.ChucVu}) - {nv.TenRap}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ẩn form đăng nhập
                this.Hide();

                // Mở form chính (và truyền thông tin nhân viên đăng nhập)
                Frm_GiaoDienKhachHang f = new Frm_GiaoDienKhachHang(nv);
                f.ShowDialog();

                // Khi form chính tắt, thoát luôn chương trình
                this.Close();
            }
            else if (txt_EmailDangNhap.Text == "admin" && txt_MKDangNhap.Text == "123456")
            {
                Frm_GiaoDienAdmin frm1 = new Frm_GiaoDienAdmin();
                frm1.Show(this);
            }
            else
            {
                MessageBox.Show("Email hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool KiemTraEmailHopLe(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            if (email.Length < 5 || email.Length > 30) return false;

            // Bắt buộc có dạng tên@gmail.com
            if (!email.EndsWith("@gmail.com")) return false;

            // Lấy phần tên trước @
            string namePart = email.Substring(0, email.IndexOf("@"));

            // Không được có dấu, khoảng trắng, ký tự đặc biệt
            foreach (char c in namePart)
            {
                if (!char.IsLetterOrDigit(c)) return false;
            }

            return true;
        }

        private bool KiemTraMatKhauHopLe(string matKhau)
        {
            if (string.IsNullOrWhiteSpace(matKhau)) return false;
            if (matKhau.Length < 8 || matKhau.Length > 20) return false;

            // Không được chứa dấu cách
            if (matKhau.Contains(" ")) return false;

            // Phải có ít nhất 1 chữ hoa
            bool coChuHoa = matKhau.Any(char.IsUpper);

            // Phải có ít nhất 1 ký tự đặc biệt
            bool coKyTuDacBiet = matKhau.Any(ch => !char.IsLetterOrDigit(ch));

            // Không được chỉ toàn số
            bool chiToanSo = matKhau.All(char.IsDigit);

            // Không được chỉ toàn ký tự đặc biệt
            bool chiToanKyTuDacBiet = matKhau.All(ch => !char.IsLetterOrDigit(ch));

            if (!coChuHoa || !coKyTuDacBiet || chiToanSo || chiToanKyTuDacBiet)
                return false;

            return true;
        }


        private void txt_EmailDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                if (txt_EmailDangNhap.Text.Length == 0)
                {
                    MessageBox.Show("Không được nhập dấu cách ở đầu!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;
                    return;
                }

                // Chặn 2 dấu cách liên tiếp
                if (txt_EmailDangNhap.Text.EndsWith(" "))
                {
                    MessageBox.Show("Không được nhập 2 dấu cách liên tiếp!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;
                    return;
                }
            }

        }

        private void txt_MKDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                MessageBox.Show("Mật khẩu không được chứa dấu cách!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true; // Chặn ký tự cách
            }
        }

        private void txt_EmailDangNhap_TextChanged(object sender, EventArgs e)
        {
            string email = txt_EmailDangNhap.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                lbLoiEmail.Visible = false;
                return;
            }

            if (email.StartsWith(" ") || email.EndsWith(" "))
            {
                lbLoiEmail.Text = "Không được có khoảng trắng ở đầu hoặc cuối!";
                lbLoiEmail.Visible = true;
                return;
            }

            if (email.Contains("  "))
            {
                lbLoiEmail.Text = "Không được có 2 dấu cách liên tiếp!";
                lbLoiEmail.Visible = true;
                return;
            }

            if (!KiemTraEmailHopLe(email))
            {
                lbLoiEmail.Text = "Email không hợp lệ!";
                lbLoiEmail.Visible = true;
                return;
            }

            lbLoiEmail.Visible = false;
        }

        private void txt_MKDangNhap_TextChanged(object sender, EventArgs e)
        {
            string mk = txt_MKDangNhap.Text.Trim();

            if (string.IsNullOrEmpty(mk))
            {
                lbLoiMK.Visible = false;
                return;
            }

            if (mk.StartsWith(" ") || mk.EndsWith(" "))
            {
                lbLoiMK.Text = "Không được có khoảng trắng ở đầu hoặc cuối!";
                lbLoiMK.Visible = true;
                return;
            }

            if (mk.Contains(" "))
            {
                lbLoiMK.Text = "Mật khẩu không được chứa dấu cách!";
                lbLoiMK.Visible = true;
                return;
            }

            if (!KiemTraMatKhauHopLe(mk))
            {
                lbLoiMK.Text = "Mật khẩu 8–20 ký tự, có chữ hoa & ký tự đặc biệt!";
                lbLoiMK.Visible = true;
                return;
            }

            lbLoiMK.Visible = false;
        }
    }
}
