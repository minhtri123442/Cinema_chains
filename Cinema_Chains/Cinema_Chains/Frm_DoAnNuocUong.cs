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
    public partial class Frm_DoAnNuocUong : Form
    {
        public Frm_DoAnNuocUong()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Xác nhận thanh toán", "Thông báo", MessageBoxButtons.OKCancel);
            if (d == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
