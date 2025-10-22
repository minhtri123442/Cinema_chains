using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Chains
{
    public partial class Frm_QuanLyLichChieu : Form
    {
        public Frm_QuanLyLichChieu()
        {
            InitializeComponent();
        }

        private void Frm_QuanLyLichChieu_Load(object sender, EventArgs e)
        {

        }
            LockInput();
        }

        private void LoadData()
        {
            dgvLichChieu.DataSource = bulLichChieu.GetAll();
        }

        private void LoadPhim()
        {
            var dsPhim = bulPhim.LayDanhSachPhim();
            cboPhim.DataSource = dsPhim;
            cboPhim.DisplayMember = "TenPhim";
            cboPhim.ValueMember = "MaPhim";
        }

        private void LoadPhong()
        {
            var dsPhong = bulPhong.GetAll();
            cboPhong.DataSource = dsPhong;
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
        }


        private void LockInput()
        {
            cboPhim.Enabled = false;
            cboPhong.Enabled = false;
            dtpNgayChieu.Enabled = false;
            dtpGioBatDau.Enabled = false;
            dtpGioKetThuc.Enabled = false;
            txtTrangThai.Enabled = false;
            txtGiaVe.Enabled = false;

            btnXacNhan.Enabled = false;
        }

        private void UnlockInput()
        {
            cboPhim.Enabled = true;
            cboPhong.Enabled = true;
            dtpNgayChieu.Enabled = true;
            dtpGioBatDau.Enabled = true;
            dtpGioKetThuc.Enabled = true;
            txtTrangThai.Enabled = true;
            txtGiaVe.Enabled = true;

            btnXacNhan.Enabled = true;
        }

        private void ClearInput()
        {
            cboPhim.SelectedIndex = -1;
            cboPhong.SelectedIndex = -1;
            txtTrangThai.Clear();
            txtGiaVe.Clear();
        }

        private DTO_LichChieu GetInput()
        {
            try
            {
                // Lấy và trim
                var phimSelected = cboPhim.SelectedValue;
                var phongSelected = cboPhong.SelectedValue;
                string trangThai = txtTrangThai.Text?.Trim() ?? "";
                string giaVeText = txtGiaVe.Text?.Trim() ?? "";

                // Regex: cho phép chữ (unicode), số, khoảng trắng, dấu .,,- (tuỳ bạn)
                Regex rText = new Regex(@"^[\p{L}\d\s\.,\-]+$");

                // Kiểm tra Selection của combobox
                if (phimSelected == null || Convert.ToInt32(phimSelected) <= 0)
                {
                    MessageBox.Show("Vui lòng chọn phim.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPhim.Focus();
                    return null;
                }
                if (phongSelected == null || Convert.ToInt32(phongSelected) <= 0)
                {
                    MessageBox.Show("Vui lòng chọn phòng.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPhong.Focus();
                    return null;
                }

                // Kiểm tra ngày giờ
                DateTime ngay = dtpNgayChieu.Value.Date;
                DateTime nowDate = DateTime.Now.Date;
                if (ngay < nowDate)
                {
                    var res = MessageBox.Show("Ngày chiếu đang chọn là quá khứ. Bạn có muốn tiếp tục?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                        dtpNgayChieu.Focus();
                        return null;
                    }
                }

                DateTime gioBD = dtpGioBatDau.Value;
                DateTime gioKT = dtpGioKetThuc.Value;
                // So sánh chỉ theo TimeOfDay nếu user dùng same datepicker cho both
                if (gioBD.TimeOfDay >= gioKT.TimeOfDay)
                {
                    MessageBox.Show("Giờ bắt đầu phải nhỏ hơn giờ kết thúc.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpGioBatDau.Focus();
                    return null;
                }

                // Kiểm tra trạng thái (không rỗng, không toàn khoảng trắng, không ký tự lạ)
                if (string.IsNullOrWhiteSpace(trangThai))
                {
                    MessageBox.Show("Trạng thái không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTrangThai.Focus();
                    return null;
                }
                if (!rText.IsMatch(trangThai))
                {
                    MessageBox.Show("Trạng thái chứa ký tự không hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTrangThai.Focus();
                    return null;
                }

                // Kiểm tra Giá vé (sử dụng TryParse an toàn)
                if (string.IsNullOrWhiteSpace(giaVeText))
                {
                    MessageBox.Show("Giá vé không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaVe.Focus();
                    return null;
                }

                // Thử parse theo culture hiện tại (cho phép dấu '.' hoặc ',')
                if (!decimal.TryParse(giaVeText, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal giaVe))
                {
                    // thử parse theo Invariant nếu người dùng dùng dấu chấm bất thường
                    if (!decimal.TryParse(giaVeText, NumberStyles.Number, CultureInfo.InvariantCulture, out giaVe))
                    {
                        MessageBox.Show("Giá vé phải là một số hợp lệ (ví dụ: 50000 hoặc 50.000).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtGiaVe.Focus();
                        return null;
                    }
                }

                if (giaVe < 0)
                {
                    MessageBox.Show("Giá vé phải lớn hơn hoặc bằng 0.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaVe.Focus();
                    return null;
                }

                return new DTO_LichChieu(
                    0,
                    (int)cboPhim.SelectedValue,
                    (int)cboPhong.SelectedValue,
                    dtpNgayChieu.Value,
                    dtpGioBatDau.Value,
                    dtpGioKetThuc.Value,
                    txtTrangThai.Text,
                    decimal.Parse(txtGiaVe.Text)
                );
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng dữ liệu!");
                return null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnlockInput();
            ClearInput();
            action = "add";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UnlockInput();
            action = "edit";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichChieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            int ma = (int)dgvLichChieu.SelectedRows[0].Cells["maLichChieu"].Value;
            if (MessageBox.Show("Bạn có chắc muốn xóa lịch chiếu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (bulLichChieu.Delete(ma))
                    MessageBox.Show("Xóa thành công!");
                else
                    MessageBox.Show("Xóa thất bại!");
                LoadData();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var lich = GetInput();
            if (lich == null) return;

            if (action == "add")
            {
                if (bulLichChieu.Insert(lich))
                    MessageBox.Show("Thêm lịch chiếu thành công!");
                else
                    MessageBox.Show("Thêm thất bại!");
            }
            else if (action == "edit")
            {
                if (dgvLichChieu.SelectedRows.Count > 0)
                    lich.maLichChieu = (int)dgvLichChieu.SelectedRows[0].Cells["maLichChieu"].Value;

                if (bulLichChieu.Update(lich))
                    MessageBox.Show("Cập nhật thành công!");
                else
                    MessageBox.Show("Cập nhật thất bại!");
            }

            action = "";
            LoadData();
            LockInput();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
            LockInput();
            action = "";
        }

        private void dgvLichChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click vào tiêu đề cột thì bỏ qua
            if (e.RowIndex < 0)
                return;

            // Chọn nguyên dòng
            dgvLichChieu.Rows[e.RowIndex].Selected = true;

            // Lấy dòng hiện tại
            var row = dgvLichChieu.Rows[e.RowIndex];

            try
            {
                // Lấy dữ liệu và gán vào control
                cboPhim.SelectedValue = Convert.ToInt32(row.Cells["MaPhim"].Value);
                cboPhong.SelectedValue = Convert.ToInt32(row.Cells["MaPhong"].Value);
                txtTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                dtpNgayChieu.Value = Convert.ToDateTime(row.Cells["NgayChieu"].Value);
                dtpGioBatDau.Value = Convert.ToDateTime(row.Cells["GioBatDau"].Value);
                dtpGioKetThuc.Value = Convert.ToDateTime(row.Cells["GioKetThuc"].Value);

                txtGiaVe.Text = row.Cells["GiaVe"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể hiển thị dữ liệu: " + ex.Message);
            }
        }
    }
    }
}
