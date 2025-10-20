using BUL;
using DTO;
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
using System.Text.RegularExpressions;

namespace Cinema_Chains
{
    public partial class Frm_QuanLyPhim : Form
    {
        private BUL_TheLoai bulTheLoai = new BUL_TheLoai();
        private BUL_Phim bulPhim = new BUL_Phim();
        private BUL_NhaPhanPhoi bulNPP = new BUL_NhaPhanPhoi();
        string action = "";
        public Frm_QuanLyPhim()
        {
            InitializeComponent();
        }
        private void Frm_QuanLyPhim_Load(object sender, EventArgs e)
        {
            HienThiDS();
            HienThiCheckedListBoxTheLoai();
            LoadDanhSachPhim();
            LoadNhaPhanPhoi();
            SetTextBoxMaxLength();
            SetEnableTextBoxTL(false);
            EnableTextBoxPhim(false);
            txtMaTL.Enabled = false;
            txtMaPhim.Enabled = false;

        }

        private List<string> KiemTraLoiTen(string ten, string loai)
        {
            List<string> loi = new List<string>();

            if (string.IsNullOrWhiteSpace(ten))
            {
                loi.Add($"Vui lòng nhập {loai}!");
                return loi;
            }

            if (ten.StartsWith(" ") || ten.EndsWith(" "))
                loi.Add($"{loai} không được có khoảng trắng ở đầu hoặc cuối!");

            if (ten.Contains("  "))
                loi.Add($"{loai} không được có 2 khoảng trắng liên tiếp!");

            // Cho phép chữ cái (có dấu), chữ số, khoảng trắng và 2 ký tự ! ?
            if (!Regex.IsMatch(ten, @"^[A-Za-zÀ-ỹ0-9\s!?,.]+$"))
                loi.Add($"{loai} chỉ được chứa chữ cái, chữ số và các ký tự đặc biệt '!' hoặc '?'!");

            return loi;
        }

        private void SetTextBoxMaxLength()
        {
            // Bảng Thể loại
            // 
            txtTenTL.MaxLength = 100;

            // Bảng Phim
            txtTenPhim.MaxLength = 200;
            txtHinhAnh.MaxLength = 100;
        }

        private void HienThiDS()
        {
            dgvTheLoai.DataSource = bulTheLoai.LayDanhSachTheLoai();
            dgvTheLoai.Columns["MaTheLoai"].HeaderText = "Mã thể loại";
            dgvTheLoai.Columns["TenTheLoai"].HeaderText = "Tên thể loại";
        }
        private void SetEnableTextBoxTL(bool enable)
        {
            txtTenTL.Enabled = enable;
        }

        private string duongDanAnhTam = ""; // giữ ảnh được chọn tạm
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Chọn ảnh phim";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                duongDanAnhTam = openFileDialog.FileName; // lưu lại đường dẫn gốc
                txtHinhAnh.Text = Path.GetFileName(duongDanAnhTam);
                picHinhAnh.Image = Image.FromFile(duongDanAnhTam);
            }

        }

        private void btnThemTL_Click(object sender, EventArgs e)
        {
            action = "them";
            txtMaTL.Clear();
            txtTenTL.Clear();
            txtTenTL.Focus();
            SetEnableTextBoxTL(true);

        }

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaTL.Text = dgvTheLoai.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenTL.Text = dgvTheLoai.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            SetEnableTextBoxTL(false);
        }

        private void btnSuaTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTL.Text))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần chỉnh sửa!");
                return;
            }
            action = "sua";
            SetEnableTextBoxTL(true);

        }

        private void btnXoaTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTL.Text))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần xóa!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa thể loại này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (bulTheLoai.XoaTheLoai(int.Parse(txtMaTL.Text)))
                {
                    MessageBox.Show("Xóa thành công!");
                    txtMaTL.Clear();
                    txtTenTL.Clear();
                    HienThiDS();
                    HienThiCheckedListBoxTheLoai();

                }
                else
                    MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnXacNhanTL_Click(object sender, EventArgs e)
        {
            var loi = KiemTraLoiTen(txtTenTL.Text, "Tên thể loại");

            if (loi.Count > 0)
            {
                MessageBox.Show(string.Join("\n", loi), "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuẩn hóa lại tên (bỏ khoảng trắng dư)
            string tenChuan = Regex.Replace(txtTenTL.Text.Trim(), @"\s+", " ");

            DTO_TheLoai tl = new DTO_TheLoai
            {
                MaTheLoai = string.IsNullOrEmpty(txtMaTL.Text) ? 0 : int.Parse(txtMaTL.Text),
                TenTheLoai = tenChuan
            };

            bool kq = false;
            if (action == "them")
                kq = bulTheLoai.ThemTheLoai(tl);
            else if (action == "sua")
                kq = bulTheLoai.SuaTheLoai(tl);

            if (kq)
            {
                MessageBox.Show("Thực hiện thành công!");
                HienThiDS();
                HienThiCheckedListBoxTheLoai();
                action = "";
                SetEnableTextBoxTL(false);
                txtMaTL.Clear();
                txtTenTL.Clear();
            }
            else
                MessageBox.Show("Thực hiện thất bại!");
        }

        private void btnLamMoiTL_Click(object sender, EventArgs e)
        {
            txtMaTL.Clear();
            txtTenTL.Clear();
            action = "";
            HienThiDS();
            HienThiCheckedListBoxTheLoai();
            SetEnableTextBoxTL(false);
        }

        //hiển thị checkListBox thể loại
        private void HienThiCheckedListBoxTheLoai()
        {
            CheckLBTheLoai.Items.Clear(); // Xóa danh sách cũ

            var dsTheLoai = bulTheLoai.LayDanhSachTheLoai();

            foreach (var tl in dsTheLoai)
            {
                int index = CheckLBTheLoai.Items.Add(tl.TenTheLoai);
                CheckLBTheLoai.Items[index] = tl;
            }

            CheckLBTheLoai.DisplayMember = "TenTheLoai";
        }




        //================== Phần quản lý phim =================//
        string actionPhim = "";

        private void LoadNhaPhanPhoi()
        {
            var dsNPP = bulNPP.LayDanhSachNhaPhanPhoi();
            cboNhaPhanPhoi.DataSource = dsNPP;
            cboNhaPhanPhoi.DisplayMember = "TenNPP";
            cboNhaPhanPhoi.ValueMember = "MaNPP";
        }

        //làm mới các thông tin phim
        private void ClearThongTinPhim()
        {
            txtMaPhim.Clear();
            txtTenPhim.Clear();
            txtThoiLuong.Clear();
            txtHinhAnh.Clear();
            picHinhAnh.Image = null;
            cboNhaPhanPhoi.SelectedIndex = -1;

            for (int i = 0; i < CheckLBTheLoai.Items.Count; i++)
                CheckLBTheLoai.SetItemChecked(i, false);
        }


        // bật/tắt các textbox phim
        private void EnableTextBoxPhim(bool enable)
        {
            txtTenPhim.Enabled = enable;
            txtThoiLuong.Enabled = enable;
            txtHinhAnh.Enabled = enable;
            CheckLBTheLoai.Enabled = enable;
            cboNhaPhanPhoi.Enabled = enable;
            btnChonAnh.Enabled = enable;
        }


        //hiện các thể loại đã chọn(dấu tích)
        private List<int> LayDanhSachTheLoaiDaChon()
        {
            List<int> ds = new List<int>();
            foreach (var item in CheckLBTheLoai.CheckedItems)
            {
                DTO_TheLoai tl = (DTO_TheLoai)item;
                ds.Add(tl.MaTheLoai);
            }
            return ds;
        }

        private void LoadDanhSachPhim()
        {
            dgvPhim.DataSource = bulPhim.LayDanhSachPhim();
        }


        private void dgvPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
    {
                var row = dgvPhim.Rows[e.RowIndex];

                txtMaPhim.Text = row.Cells["MaPhim"].Value.ToString();
                txtTenPhim.Text = row.Cells["TenPhim"].Value.ToString();
                txtThoiLuong.Text = row.Cells["ThoiLuong"].Value.ToString();
                txtHinhAnh.Text = row.Cells["HinhAnh"].Value.ToString();
                // Chọn nhà phân phối tương ứng
                if (row.Cells["MaNPP"].Value != null)
                {
                    cboNhaPhanPhoi.SelectedValue = row.Cells["MaNPP"].Value;
                }



                // Hiển thị hình ảnh (nếu có file)
                string duongDanAnh = Path.Combine(Application.StartupPath, "Images", txtHinhAnh.Text);
                if (File.Exists(duongDanAnh))
                    picHinhAnh.Image = Image.FromFile(duongDanAnh);
                else
                    picHinhAnh.Image = null;

                // Bỏ chọn toàn bộ thể loại
                for (int i = 0; i < CheckLBTheLoai.Items.Count; i++)
                    CheckLBTheLoai.SetItemChecked(i, false);

                // Lấy danh sách thể loại của phim
                int maPhim = Convert.ToInt32(txtMaPhim.Text);
                List<int> listMaTL = bulPhim.LayMaTheLoaiTheoPhim(maPhim);

                // Tích chọn các thể loại thuộc phim
                foreach (int maTL in listMaTL)
                {
                    for (int i = 0; i < CheckLBTheLoai.Items.Count; i++)
                    {
                        var item = (DTO_TheLoai)CheckLBTheLoai.Items[i];
                        if (item.MaTheLoai == maTL)
                            CheckLBTheLoai.SetItemChecked(i, true);
                    }
                }

                EnableTextBoxPhim(false);
            }
        }
        //nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            actionPhim = "them";
            ClearThongTinPhim();
            EnableTextBoxPhim(true);
            txtTenPhim.Focus();
        }
        //nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhim.Text))
            {
                MessageBox.Show("Vui lòng chọn phim cần chỉnh sửa!");
                return;
            }
            actionPhim = "sua";
            EnableTextBoxPhim(true);
        }
        //nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhim.Text))
            {
                MessageBox.Show("Vui lòng chọn phim cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa phim này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int maPhim = int.Parse(txtMaPhim.Text);
                if (bulPhim.XoaPhim(maPhim))
                {
                    MessageBox.Show("Xóa phim thành công!");
                    LoadDanhSachPhim();
                    ClearThongTinPhim();
                }
                else
                    MessageBox.Show("Xóa phim thất bại!");
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            List<string> loi = new List<string>();

            // Kiểm tra tên phim
            loi.AddRange(KiemTraLoiTen(txtTenPhim.Text, "Tên phim"));

            // Kiểm tra thời lượng
            if (string.IsNullOrWhiteSpace(txtThoiLuong.Text))
                loi.Add("Vui lòng nhập thời lượng phim!");
            else if (!int.TryParse(txtThoiLuong.Text, out int thoiLuong) || thoiLuong <= 0)
                loi.Add("Thời lượng phim phải là số nguyên dương!");

            // Kiểm tra nhà phân phối
            if (cboNhaPhanPhoi.SelectedIndex == -1)
                loi.Add("Vui lòng chọn nhà phân phối!");
            // Kiểm tra ảnh
            if (string.IsNullOrWhiteSpace(txtHinhAnh.Text))
                loi.Add("Vui lòng chọn hình ảnh cho phim!");

            if (loi.Count > 0)
            {
                MessageBox.Show(string.Join("\n", loi), "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // in hoa tên phim, không có khoảng trắng dư
            string tenPhimChuan = Regex.Replace(txtTenPhim.Text.Trim(), @"\s+", " ").ToUpper();

            // Sao chép ảnh khi xác nhận
            string folderImages = Path.Combine(Application.StartupPath, "Image", "Phim");
            if (!Directory.Exists(folderImages))
                Directory.CreateDirectory(folderImages);

            string tenFile = txtHinhAnh.Text;
            string destPath = Path.Combine(folderImages, tenFile);

            // Nếu người dùng có chọn ảnh mới
            if (!string.IsNullOrEmpty(duongDanAnhTam))
            {
                // nếu trong file có ảnh trùng tên thì ghi đè
                try
                {
                    File.Copy(duongDanAnhTam, destPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message);
                    return;
                }
            }


            DTO_Phim phim = new DTO_Phim
            {
                MaPhim = string.IsNullOrEmpty(txtMaPhim.Text) ? 0 : int.Parse(txtMaPhim.Text),
                TenPhim = tenPhimChuan,
                ThoiLuong = int.Parse(txtThoiLuong.Text),
                HinhAnh = txtHinhAnh.Text,
                MaNPP = Convert.ToInt32(cboNhaPhanPhoi.SelectedValue)
            };

            bool kq = false;

            if (actionPhim == "them")
                kq = bulPhim.ThemPhim(phim, LayDanhSachTheLoaiDaChon());
            else if (actionPhim == "sua")
                kq = bulPhim.SuaPhim(phim, LayDanhSachTheLoaiDaChon());

            if (kq)
            {
                duongDanAnhTam = "";
                MessageBox.Show("Thực hiện thành công!");
                LoadDanhSachPhim();
                ClearThongTinPhim();
                EnableTextBoxPhim(false);
                actionPhim = "";
            }
            else
                MessageBox.Show("Thực hiện thất bại!");
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            ClearThongTinPhim();
            EnableTextBoxPhim(false);
        }
    }
}
    

