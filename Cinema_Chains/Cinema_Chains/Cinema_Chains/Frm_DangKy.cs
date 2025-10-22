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
    public partial class Frm_DangKy : Form
    {
        public Frm_DangKy()
        {
            InitializeComponent();
        }

        private void btn_BackupLogin_Click(object sender, EventArgs e)
        {
            Frm_DangNhap frm = new Frm_DangNhap();
            Hide();
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
