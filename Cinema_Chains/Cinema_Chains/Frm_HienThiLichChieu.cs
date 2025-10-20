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
    public partial class Frm_HienThiLichChieu : Form
    {
        public Frm_HienThiLichChieu()
        {
            InitializeComponent();
        }

        private void btnSuatChieu_Click(object sender, EventArgs e)
        {
            Frm_DatGhe frm = new Frm_DatGhe();
            frm.Show(this);
        }
    }
}
