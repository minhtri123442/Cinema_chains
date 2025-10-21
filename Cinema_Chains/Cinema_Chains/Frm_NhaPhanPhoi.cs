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
    public partial class Frm_NhaPhanPhoi : Form
    {
        private BUL_NhaPhanPhoi bulNPP = new BUL_NhaPhanPhoi();
        private string action = "";
        public Frm_NhaPhanPhoi()
        {
            InitializeComponent();
        }

        private void Frm_NhaPhanPhoi_Load(object sender, EventArgs e)
        {
            LoadData();
            LockInput();
        }

        private void LoadData()
        {
            dgvNhaPhanPhoi.DataSource = bulNPP.LayDanhSachNhaPhanPhoi();
        }

        private void LockInput()
        {
            txtMaNPP.Enabled = false;
            txtTenNPP.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            
            btnXacNhan.Enabled = false;
        }

        private void UnlockInput()
        {
            txtMaNPP.Enabled = false;
            txtTenNPP.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;

            btnXacNhan.Enabled = true;
        }

        private void ClearInput()
        {
            txtMaNPP.Clear();
            txtTenNPP.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
        }

        private DTO_NhaPhanPhoi GetInput()
        {
            try
            {
                string ten = txtTenNPP.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string dienThoai = txtDienThoai.Text.Trim();

                // Regex kiểm tra ký tự hợp lệ
                System.Text.RegularExpressions.Regex regexChu = new System.Text.RegularExpressions.Regex(@"^[\p{L}\d\s\.,-]+$");
                System.Text.RegularExpressions.Regex regexSo = new System.Text.RegularExpressions.Regex(@"^[0-9]{9,11}$");

                // Kiểm tra rỗng
                if (string.IsNullOrWhiteSpace(ten))
                {
                    MessageBox.Show("Tên nhà phân phối không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNPP.Focus();
                    return null;
                }
                if (!regexChu.IsMatch(ten))
                {
                    MessageBox.Show("Tên nhà phân phối chứa ký tự không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNPP.Focus();
                    return null;
                }

                if (string.IsNullOrWhiteSpace(diaChi))
                {
                    MessageBox.Show("Địa chỉ không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return null;
                }
                if (!regexChu.IsMatch(diaChi))
                {
                    MessageBox.Show("Địa chỉ chứa ký tự không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return null;
                }

                if (string.IsNullOrWhiteSpace(dienThoai))
                {
                    MessageBox.Show("Số điện thoại không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDienThoai.Focus();
                    return null;
                }
                if (!regexSo.IsMatch(dienThoai))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ! (chỉ gồm 9–11 chữ số)", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDienThoai.Focus();
                    return null;
                }
                return new DTO_NhaPhanPhoi(
                    0,
                    txtTenNPP.Text,
                    txtDiaChi.Text,
                    txtDienThoai.Text
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
            if (dgvNhaPhanPhoi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            int ma = (int)dgvNhaPhanPhoi.SelectedRows[0].Cells["MaNPP"].Value;
            if (MessageBox.Show("Bạn có chắc muốn xóa lịch chiếu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (bulNPP.Delete(ma))
                    MessageBox.Show("Xóa thành công!");
                else
                    MessageBox.Show("Xóa thất bại!");
                LoadData();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var npp = GetInput();
            if (npp == null) return;

            if (action == "add")
            {
                if (bulNPP.Insert(npp))
                    MessageBox.Show("Thêm lịch chiếu thành công!");
                else
                    MessageBox.Show("Thêm thất bại!");
            }
            else if (action == "edit")
            {
                if (dgvNhaPhanPhoi.SelectedRows.Count > 0)
                    npp.MaNPP = (int)dgvNhaPhanPhoi.SelectedRows[0].Cells["MaNPP"].Value;

                if (bulNPP.Update(npp))
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

        private void dgvNhaPhanPhoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click vào tiêu đề cột thì bỏ qua
            if (e.RowIndex < 0)
                return;

            // Chọn nguyên dòng
            dgvNhaPhanPhoi.Rows[e.RowIndex].Selected = true;

            // Lấy dòng hiện tại
            var row = dgvNhaPhanPhoi.Rows[e.RowIndex];

            try
            {
                // Lấy dữ liệu và gán vào control
                txtMaNPP.Text = row.Cells["MaNPP"].Value.ToString();
                txtTenNPP.Text = row.Cells["TenNPP"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể hiển thị dữ liệu: " + ex.Message);
            }
        }
    }
}
