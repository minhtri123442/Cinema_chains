using BUL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Chains
{
    public partial class Frm_NhaCungCap : Form
    {
        private readonly BUL_NhaCungCap bul = new BUL_NhaCungCap();
        private readonly DAL_NhaCungCap dal = new DAL_NhaCungCap();
        private string action = "";
        public Frm_NhaCungCap()
        {
            InitializeComponent();
            // Giới hạn 30 ký tự mỗi TextBox
            txtTenNCC.MaxLength = 100;
            txtDiaChi.MaxLength = 200;
            txtDienThoai.MaxLength = 20;
            txtEmail.MaxLength = 100;
            SetEnableTextBox(false);
            HienThiDanhSach();

        }
        private void HienThiDanhSach()
        {
            dgvNhaCC.DataSource = bul.LayDanhSachNCC()
                .Select(x => new
                {
                    x.MaNCC,
                    x.TenNCC,
                    x.DiaChi,
                    x.DienThoai,
                    x.Email
                }).ToList();

        }
        private void LamMoi()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtTenNCC.Focus();
            action = "";
            SetEnableTextBox(false);
        }

        private void SetEnableTextBox(bool enable)
        {
            txtTenNCC.Enabled = enable;
            txtDiaChi.Enabled = enable;
            txtDienThoai.Enabled = enable;
            txtEmail.Enabled = enable;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LamMoi();
            action = "them";
            SetEnableTextBox(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để sửa!");
                return;
            }
            action = "sua";
            SetEnableTextBox(true);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DTO_NhaCungCap ncc = new DTO_NhaCungCap
            {
                MaNCC = string.IsNullOrEmpty(txtMaNCC.Text) ? 0 : int.Parse(txtMaNCC.Text),
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChi.Text,
                DienThoai = txtDienThoai.Text,
                Email = txtEmail.Text
            };

            // ====== 🔹 Kiểm tra khoảng trắng không hợp lệ ======
            // Hàm cục bộ để kiểm tra từng chuỗi
            bool CoKhoangTrangSai(string text) =>
                text.StartsWith(" ") || text.EndsWith(" ") || text.Contains("  ");

            if (CoKhoangTrangSai(ncc.TenNCC) || CoKhoangTrangSai(ncc.DiaChi) ||
                CoKhoangTrangSai(ncc.DienThoai) || CoKhoangTrangSai(ncc.Email))
            {
                MessageBox.Show("Không được có khoảng trắng ở đầu/cuối hoặc 2 khoảng trắng liền kề!");
                return;
            }

            // Trim lại các giá trị hợp lệ
            ncc.TenNCC = ncc.TenNCC.Trim();
            ncc.DiaChi = ncc.DiaChi.Trim();
            ncc.DienThoai = ncc.DienThoai.Trim();
            ncc.Email = ncc.Email.Trim();

            // ====== 1️⃣ Kiểm tra tên nhà cung cấp ======
            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!");
                return;
            }

            if (!Regex.IsMatch(ncc.TenNCC, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên nhà cung cấp không được chứa số hoặc ký tự đặc biệt!");
                return;
            }

            // ====== 2️⃣ Kiểm tra định dạng số điện thoại ======
            if (!Regex.IsMatch(ncc.DienThoai, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! (Phải có 10 chữ số và bắt đầu bằng 0)");
                return;
            }

            // ====== 3️⃣ Kiểm tra định dạng email ======
            if (!Regex.IsMatch(ncc.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!");
                return;
            }

            // ====== 4️⃣ Kiểm tra trùng email ======
            if (dal.KiemTraEmailTonTai(ncc.Email, ncc.MaNCC))
            {
                MessageBox.Show("Email này đã tồn tại trong hệ thống!");
                return;
            }

            // ====== 5️⃣ Thực hiện thêm hoặc sửa ======
            bool result = false;
            if (action == "them")
                result = bul.ThemNCC(ncc);
            else if (action == "sua")
                result = bul.SuaNCC(ncc);

            if (result)
            {
                MessageBox.Show("Thực hiện thành công!");
                HienThiDanhSach();
                LamMoi();
            }
            else
                MessageBox.Show("Thao tác thất bại!");
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa!");
                return;
            }

            int MaNCC = int.Parse(txtMaNCC.Text);

            if (bul.KiemTraNCCCoPhieuNhap(MaNCC))
            {
                MessageBox.Show("Không thể xóa! Nhà cung cấp này đã có phiếu nhập hàng.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int maNCC = int.Parse(txtMaNCC.Text);
                if (bul.XoaNCC(maNCC))
                {
                    MessageBox.Show("Xóa thành công!");
                    HienThiDanhSach();
                    LamMoi();
                }
                else
                    MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            HienThiDanhSach();
        }

        private void dgvNhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNCC.Text = dgvNhaCC.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = dgvNhaCC.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();
                txtDiaChi.Text = dgvNhaCC.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                txtDienThoai.Text = dgvNhaCC.Rows[e.RowIndex].Cells["DienThoai"].Value.ToString();
                txtEmail.Text = dgvNhaCC.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            }
            SetEnableTextBox(false);
        }
    }
}
