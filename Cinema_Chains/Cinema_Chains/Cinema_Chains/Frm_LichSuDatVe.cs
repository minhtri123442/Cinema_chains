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
    public partial class Frm_LichSuDatVe : Form
    {
        public Frm_LichSuDatVe()
        {
            InitializeComponent();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            Frm_ChiTietLSDatVe frm = new Frm_ChiTietLSDatVe();
            frm.ShowDialog();
        }
    }
}
