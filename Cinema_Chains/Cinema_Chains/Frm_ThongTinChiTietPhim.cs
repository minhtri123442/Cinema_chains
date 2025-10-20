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
    public partial class Frm_ThongTinChiTietPhim : Form
    {
        public Frm_ThongTinChiTietPhim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Frm_ThongTinChiTietPhim_Load(object sender, EventArgs e)
        {

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

        private void btnBinhLuan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_BinhLuan());
        }

        private void btnLichChieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_HienThiLichChieu());
        }
    }
}
