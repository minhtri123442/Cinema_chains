using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Chains
{
    public partial class Frm_QuanLyPhim : Form
    {
        public Frm_QuanLyPhim()
        {
            InitializeComponent();
        }

        private void dgvDSPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Chọn hình ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị ảnh lên PictureBox
                picHinhAnh.Image = Image.FromFile(openFileDialog.FileName);

                // Lấy tên file (không kèm đường dẫn)
                string tenFile = Path.GetFileName(openFileDialog.FileName);
                txtHinhAnh.Text = tenFile;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
