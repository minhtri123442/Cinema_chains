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
    public partial class Frm_PhanPhoiPhim : Form
    {
        public Frm_PhanPhoiPhim()
        {
            InitializeComponent();
        }

        private void Frm_PhanPhoiPhim_Load(object sender, EventArgs e)
        {

            LockInput();
        }

        private void LoadData()
        {
            dgvPhanPhoiPhim.DataSource = bulPhanPhoiPhim.GetAll();
        }

        private void LoadPhim()
        {
            var dsPhim = bulPhim.LayDanhSachPhim();
            cboPhim.DataSource = dsPhim;
            cboPhim.DisplayMember = "TenPhim";
            cboPhim.ValueMember = "MaPhim";
        }

        private void LoadRap()
        {
            var dsRap = bulRap.LayDanhSachRap();
            cboRap.DataSource = dsRap;
            cboRap.DisplayMember = "TenRap";
            cboRap.ValueMember = "MaRap";
        }

        private void LockInput()
        {
            cboPhim.Enabled = false;
            cboRap.Enabled = false;
            dtpNgayBatDau.Enabled = false;
            dtpNgayKetThuc.Enabled = false;

            btnXacNhan.Enabled = false;
        }

        private void UnlockInput()
        {
            cboPhim.Enabled = true;
            cboRap.Enabled = true;
            dtpNgayBatDau.Enabled = true;
            dtpNgayKetThuc.Enabled = true;

            btnXacNhan.Enabled = true;
        }

        private void ClearInput()
        {
            cboPhim.SelectedIndex = -1;
            cboRap.SelectedIndex = -1;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
        }

        private DTO_PhanPhoiPhim GetInput()
        {
            try
            {
                var phimSelected = cboPhim.SelectedValue;
                var rapSelected = cboRap.SelectedValue;

                if (phimSelected == null || Convert.ToInt32(phimSelected) <= 0)
                {
                    MessageBox.Show("Vui lòng chọn phim.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPhim.Focus();
                    return null;
                }
                if (rapSelected == null || Convert.ToInt32(rapSelected) <= 0)
                {
                    MessageBox.Show("Vui lòng chọn rạp.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboRap.Focus();
                    return null;
                }

                DateTime ngayBD = dtpNgayBatDau.Value.Date;
                DateTime? ngayKT = dtpNgayKetThuc.Value.Date;

                if (ngayKT.HasValue && ngayKT < ngayBD)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpNgayKetThuc.Focus();
                    return null;
                }

                int maPhanPhoi = 0;
                if (dgvPhanPhoiPhim.SelectedRows.Count > 0)
                {
                    maPhanPhoi = Convert.ToInt32(dgvPhanPhoiPhim.SelectedRows[0].Cells["maPhanPhoi"].Value);
                }


                return new DTO_PhanPhoiPhim(
                    maPhanPhoi,
                    (int)cboPhim.SelectedValue,
                    (int)cboRap.SelectedValue,
                    ngayBD,
                    ngayKT
                );
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng dữ liệu!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dgvPhanPhoiPhim.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            int maPhim = (int)dgvPhanPhoiPhim.SelectedRows[0].Cells["maPhim"].Value;
            int maRap = (int)dgvPhanPhoiPhim.SelectedRows[0].Cells["maRap"].Value;

            if (MessageBox.Show("Bạn có chắc muốn xóa phân phối phim này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (bulPhanPhoiPhim.Delete(maPhim, maRap))
                    MessageBox.Show("Xóa thành công!");
                else
                    MessageBox.Show("Xóa thất bại!");
                LoadData();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var pp = GetInput();
            if (pp == null) return;

            if (action == "add")
            {
                if (bulPhanPhoiPhim.Insert(pp))
                    MessageBox.Show("Thêm phân phối phim thành công!");
                else
                    MessageBox.Show("Thêm thất bại!");
            }
            else if (action == "edit")
            {
                if (bulPhanPhoiPhim.Update(pp))
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

        private void dgvPhanPhoiPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            dgvPhanPhoiPhim.Rows[e.RowIndex].Selected = true;
            var row = dgvPhanPhoiPhim.Rows[e.RowIndex];

            try
            {
                cboPhim.SelectedValue = Convert.ToInt32(row.Cells["maPhim"].Value);
                cboRap.SelectedValue = Convert.ToInt32(row.Cells["maRap"].Value);
                dtpNgayBatDau.Value = Convert.ToDateTime(row.Cells["ngayBatDau"].Value);
                dtpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["ngayKetThuc"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể hiển thị dữ liệu: " + ex.Message);
            }
        }
    }
}
