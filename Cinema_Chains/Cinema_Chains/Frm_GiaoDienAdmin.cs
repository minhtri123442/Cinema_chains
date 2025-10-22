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
    public partial class Frm_GiaoDienAdmin : Form
    {
        public Frm_GiaoDienAdmin()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            // Xóa control cũ trong panel
            panelMain.Controls.Clear();

            // Cấu hình form con
            childForm.TopLevel = false;         // Form con không phải cửa sổ độc lập
            childForm.FormBorderStyle = FormBorderStyle.None;  // Bỏ viền
            childForm.Dock = DockStyle.Fill;    // Lấp đầy panel

            // Thêm vào panel
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnQuanLyPhim_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_QuanLyPhim());
        }

        private void Frm_GiaoDienAdmin_Load(object sender, EventArgs e)
        {

        }


        private void btnQuanLyMatHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_QuanLyMatHang());
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_NhapHang());
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_QuanLyRap_Phong());
        }


        private void btnHoaDonVe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_QuanLyHoaDonVe());

        }

        private void btnHDDoAn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_QuanLyFoods_Drinks());

        }

        private void btnQLLichChieu_Click(object sender, EventArgs e)
        {

            OpenChildForm(new Frm_QuanLyLichChieu());
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_KhachHang());

        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_NhanVien());

        }

        private void btnQLKhuyenMai_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_QuanLyKhuyenMai());

        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_HopDongLD());
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_ChamCong());
        }

        private void btnBangLuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_BangLuong());

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnNPP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_NhaPhanPhoi());
        }

        private void btnPPPHIM_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_PhanPhoiPhim());

        }

        private void btnGiayPhep_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_QuanLyGiayPhep());
        }

        private void btnCombo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Combo());
        }
    }
}
