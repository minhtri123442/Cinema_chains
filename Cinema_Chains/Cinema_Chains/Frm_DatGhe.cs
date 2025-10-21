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
    public partial class Frm_DatGhe : Form
    {
        public Frm_DatGhe()
        {
            InitializeComponent();
        }

        private void Frm_DatGhe_Load(object sender, EventArgs e)
        {
            TaoGheTuDong(86);
        }
        private void TaoGheTuDong(int tongSoGhe)
        {
            groupBoxGhe.Controls.Clear();

            int soCot = 10; 
            int soHang = (int)Math.Ceiling(tongSoGhe / (double)soCot);
            int khoangCach = 8;

            int maxButtonWidth = (groupBoxGhe.Width - (soCot + 1) * khoangCach) / soCot;
            int maxButtonHeight = (groupBoxGhe.Height - (soHang + 1) * khoangCach) / soHang;

            int buttonWidth = Math.Min(maxButtonWidth, 60);
            int buttonHeight = Math.Min(maxButtonHeight, (int)(buttonWidth * 0.7));

            if (buttonWidth < 35) buttonWidth = 35;
            if (buttonHeight < 25) buttonHeight = 25;

            int tongChieuRong = soCot * buttonWidth + (soCot - 1) * khoangCach;
            int tongChieuCao = soHang * buttonHeight + (soHang - 1) * khoangCach;

            int startLeft = (groupBoxGhe.Width - tongChieuRong) / 2;
            int startTop = (groupBoxGhe.Height - tongChieuCao) / 2;

            int gheDaTao = 0;

            for (int i = 0; i < soHang; i++)
            {
                char hang = (char)('A' + i);

                for (int j = 1; j <= soCot && gheDaTao < tongSoGhe; j++)
                {
                    gheDaTao++;

                    Button btnGhe = new Button();
                    btnGhe.Width = buttonWidth;
                    btnGhe.Height = buttonHeight;
                    btnGhe.Left = startLeft + (j - 1) * (buttonWidth + khoangCach);
                    btnGhe.Top = startTop + i * (buttonHeight + khoangCach);
                    btnGhe.Text = $"{hang}{j}";
                    btnGhe.Tag = $"{hang}{j}";
                    btnGhe.BackColor = Color.LightGray;
                    btnGhe.FlatStyle = FlatStyle.Flat;
                    btnGhe.Cursor = Cursors.Hand;
                    btnGhe.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    btnGhe.Click += BtnGhe_Click;

                    groupBoxGhe.Controls.Add(btnGhe);
                }
            }
        }


        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackColor == Color.LightGray)
            {
                // Chọn ghế
                btn.BackColor = Color.LightGreen;

                if (!txtGheDaChon.Text.Contains(btn.Text))
                {
                    if (string.IsNullOrWhiteSpace(txtGheDaChon.Text))
                        txtGheDaChon.Text = btn.Text;
                    else
                        txtGheDaChon.Text += ", " + btn.Text;
                }
            }
            else
            {
                // Bỏ chọn ghế
                btn.BackColor = Color.LightGray;

                var gheList = txtGheDaChon.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                gheList.Remove(btn.Text);
                txtGheDaChon.Text = string.Join(", ", gheList);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Xác nhận thanh toán", "Thông báo", MessageBoxButtons.OKCancel);
            if (d == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
