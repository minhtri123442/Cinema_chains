using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using DTO;

namespace Cinema_Chains
{
    public partial class Frm_QuanLyMatHang : Form
    {
        public Frm_QuanLyMatHang()
        {
            InitializeComponent();
        }
        private readonly bul_MatHang bul = new bul_MatHang();


        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }

        private void Frm_QuanLyMatHang_Load(object sender, EventArgs e)
        {
            dgvMatHang.DataSource = bul.LayDanhSachMatHang();
        }
    }
}
