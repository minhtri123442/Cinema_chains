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
    public partial class Frm_BinhLuan : Form
    {
        public Frm_BinhLuan()
        {
            InitializeComponent();
            cboRating.SelectedIndex = 0;
            AddComment("Nguyễn Văn A", "Phim rất hay, đáng xem!", 5);
            AddComment("Trần Thị B", "Âm thanh sống động, rạp đẹp.", 4);
            AddComment("Lê Văn C", "Giá vé hợp lý, dịch vụ tốt.", 3);
            AddComment("Nguyễn Văn A", "Phim rất hay, đáng xem!", 5);
            AddComment("Trần Thị B", "Âm thanh sống động, rạp đẹp.", 4);
            AddComment("Lê Văn C", "Giá vé hợp lý, dịch vụ tốt.", 3);
            AddComment("Nguyễn Văn A", "Phim rất hay, đáng xem!", 5);
            AddComment("Trần Thị B", "Âm thanh sống động, rạp đẹp.", 4);
            AddComment("Lê Văn C", "Giá vé hợp lý, dịch vụ tốt.", 3);
            AddComment("Nguyễn Văn A", "Phim rất hay, đáng xem!", 5);
            AddComment("Trần Thị B", "Âm thanh sống động, rạp đẹp.", 4);
            AddComment("Lê Văn C", "Giá vé hợp lý, dịch vụ tốt.", 3);
            AddComment("Nguyễn Văn A", "Phim rất hay, đáng xem!", 5);
            AddComment("Trần Thị B", "Âm thanh sống động, rạp đẹp.", 4);
            AddComment("Lê Văn C", "Giá vé hợp lý, dịch vụ tốt.", 3);
            AddComment("Nguyễn Văn A", "Phim rất hay, đáng xem!", 5);
            AddComment("Trần Thị B", "Âm thanh sống động, rạp đẹp.", 4);
            AddComment("Lê Văn C", "Giá vé hợp lý, dịch vụ tốt.", 3);
        }

        private void Frm_BinhLuan_Load(object sender, EventArgs e)
        {
            txtBinhLuan.Text = "Bình luận ...";
            txtBinhLuan.ForeColor = Color.Gray;
        }

        private void txtBinhLuan_Enter(object sender, EventArgs e)
        {
            if(txtBinhLuan.Text == "Bình luận ...")
            {
                txtBinhLuan.Text = "";
                txtBinhLuan.ForeColor = Color.Black;
            }
        }

        private void AddComment(string user, string text, int rating)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(flowLayoutPanel1.Width - 20, 0);

            // Tạo chuỗi sao
            string stars = new string('★', rating) + new string('☆', 5 - rating);

            lbl.Text = $"{user} ({stars}): {text}";
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lbl.BackColor = Color.LightGray;
            lbl.Padding = new Padding(5);
            lbl.Margin = new Padding(3);

            flowLayoutPanel1.Controls.Add(lbl);
        }
    }
}
