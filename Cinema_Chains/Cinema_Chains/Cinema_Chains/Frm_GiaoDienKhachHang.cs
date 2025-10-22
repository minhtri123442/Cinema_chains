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
    public partial class Frm_GiaoDienKhachHang : Form
    {
        public Frm_GiaoDienKhachHang()
        {
            InitializeComponent();
            
        }

        private void OpenChildForm(Form childForm)
        {
            panelMain.Controls.Clear();

            childForm.TopLevel = false;                           
            childForm.FormBorderStyle = FormBorderStyle.None;     
            childForm.Dock = DockStyle.Fill;                    

            // Thêm vào panel
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void Frm_GiaoDienKhachHang_Load(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void LoadMovies()
        {
            // Danh sách demo phim (thay bằng dữ liệu DB sau)
            var danhSachPhim = new List<Phim>()
            {
                new Phim(){ TenPhim="Inception", HinhAnh=Properties.Resources.P08 },
                new Phim(){ TenPhim="Titanic", HinhAnh=Properties.Resources.P09 },
                new Phim(){ TenPhim="The Matrix", HinhAnh=Properties.Resources.P10 },
                new Phim(){ TenPhim="Your Name", HinhAnh=Properties.Resources.P11 },
                new Phim(){ TenPhim="Inception", HinhAnh=Properties.Resources.P08 },
                new Phim(){ TenPhim="Titanic", HinhAnh=Properties.Resources.P09 },
                new Phim(){ TenPhim="The Matrix", HinhAnh=Properties.Resources.P10 },
                new Phim(){ TenPhim="Your Name", HinhAnh=Properties.Resources.P11 },
                new Phim(){ TenPhim="Inception", HinhAnh=Properties.Resources.P08 },
                new Phim(){ TenPhim="Titanic", HinhAnh=Properties.Resources.P09 },
                new Phim(){ TenPhim="The Matrix", HinhAnh=Properties.Resources.P10 },
                new Phim(){ TenPhim="Your Name", HinhAnh=Properties.Resources.P11 },
                new Phim(){ TenPhim="Inception", HinhAnh=Properties.Resources.P08 },
                new Phim(){ TenPhim="Titanic", HinhAnh=Properties.Resources.P09 },
                new Phim(){ TenPhim="The Matrix", HinhAnh=Properties.Resources.P10 },
                new Phim(){ TenPhim="Your Name", HinhAnh=Properties.Resources.P11 },
                new Phim(){ TenPhim="Inception", HinhAnh=Properties.Resources.P08 },
                new Phim(){ TenPhim="Titanic", HinhAnh=Properties.Resources.P09 },
                new Phim(){ TenPhim="The Matrix", HinhAnh=Properties.Resources.P10 },
                new Phim(){ TenPhim="Your Name", HinhAnh=Properties.Resources.P11 },
                new Phim(){ TenPhim="Inception", HinhAnh=Properties.Resources.P08 },
                new Phim(){ TenPhim="Titanic", HinhAnh=Properties.Resources.P09 },
                new Phim(){ TenPhim="The Matrix", HinhAnh=Properties.Resources.P10 },
                new Phim(){ TenPhim="Your Name", HinhAnh=Properties.Resources.P11 },
                new Phim(){ TenPhim="Inception", HinhAnh=Properties.Resources.P08 },
                new Phim(){ TenPhim="Titanic", HinhAnh=Properties.Resources.P09 },
                new Phim(){ TenPhim="The Matrix", HinhAnh=Properties.Resources.P10 },
                new Phim(){ TenPhim="Your Name", HinhAnh=Properties.Resources.P11 },
                new Phim(){ TenPhim="Inception", HinhAnh=Properties.Resources.P08 },
                new Phim(){ TenPhim="Titanic", HinhAnh=Properties.Resources.P09 },
                new Phim(){ TenPhim="The Matrix", HinhAnh=Properties.Resources.P10 },
                new Phim(){ TenPhim="Your Name", HinhAnh=Properties.Resources.P11 },
                new Phim(){ TenPhim="Inception", HinhAnh=Properties.Resources.P08 },
                new Phim(){ TenPhim="Titanic", HinhAnh=Properties.Resources.P09 },
                new Phim(){ TenPhim="The Matrix", HinhAnh=Properties.Resources.P10 },
                new Phim(){ TenPhim="Your Name", HinhAnh=Properties.Resources.P11 }
            };

            flowLayoutPanel1.Controls.Clear();

            foreach (var phim in danhSachPhim)
            {
                Panel item = new Panel();
                item.Width = 150;
                item.Height = 230;
                item.Margin = new Padding(20);
                item.BackColor = Color.WhiteSmoke;

                PictureBox pic = new PictureBox();
                pic.Image = phim.HinhAnh;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Width = 150;
                pic.Height = 200;
                pic.Cursor = Cursors.Hand;

                Label lbl = new Label();
                lbl.Text = phim.TenPhim;
                lbl.Dock = DockStyle.Bottom;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                pic.Click += (s, e) =>
                {
                    OpenChildForm(new Frm_ThongTinChiTietPhim());
                };

                item.Controls.Add(pic);
                item.Controls.Add(lbl);

                flowLayoutPanel1.Controls.Add(item);
            }
        }

        public class Phim
        {
            public string TenPhim { get; set; }
            public Image HinhAnh { get; set; }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            // Thêm flowLayoutPanel vào panelMain
            panelMain.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(255, 224, 192);


            LoadMovies();
        }

        private void btnDoAn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_DoAnNuocUong());
        }

        private void btnLSDatVe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_LichSuDatVe());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
