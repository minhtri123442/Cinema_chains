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
using BUL;
using DAL;
using DTO;

namespace Cinema_Chains
{
    public partial class Frm_Combo : Form
    {
        public Frm_Combo()
        {
            InitializeComponent();
        }
        private string currentAction = "";
        private string currentActionDetail = "";
        private bul_MatHang bulMatHang = new bul_MatHang();
        private readonly BUL_Combo bulCombo = new BUL_Combo();
        private readonly BUL_ChiTietCombo bulCTCombo = new BUL_ChiTietCombo();

        private void ClearComboDetail()
        {
            txtMaCTCombo.Text = string.Empty;
            cboMaHang.SelectedIndex = 0;
            txtSoLuong.Text = string.Empty;
            txtMaCTCombo.Enabled = cboMaHang.Enabled = txtSoLuong.Enabled = btnXacNhanChiTiet.Enabled = false;
            btnThemChiTiet.BackColor = btnSuaChiTiet.BackColor = Color.White;
            btnThemChiTiet.Enabled = btnSuaChiTiet.Enabled = true;
        }

        private void ClearCombo()
        {
            dgvChiTietCombo.DataSource = null;
            ClearComboDetail();
            txtMaCombo.Text = string.Empty;
            txtTenCombo.Text = string.Empty;
            txtGia.Text = string.Empty;
            txtMoTa.Text = string.Empty;
            txtHinhAnh.Text = string.Empty;
            picAnhCombo.Image = null;
            btnChonAnh.Enabled = false;
            txtTenCombo.Enabled = txtGia.Enabled = txtMoTa.Enabled = btnXacNhan.Enabled = false;
            btnThem.BackColor = btnSua.BackColor = Color.White;
            btnThem.Enabled = btnSua.Enabled = true;
        }
        private void HienThiDanhSachCombo()
        {
            LoadComboBoxMatHang();
            dgvDSCombo.DataSource = bulCombo.LayDanhSachCombo();
            dgvDSCombo.Columns["MaCombo"].Visible = false;
            dgvDSCombo.Columns["TrangThai"].Visible = false;
        }

        private void LoadComboBoxMatHang()
        {
            var danhSach = bulMatHang.LayDanhSachMatHang()
                .Where(h => h.LoaiHang != "Vật tư")
                .Select(h => new
                {
                    MaHang = h.MaHang,
                    HienThi = $"{h.MaHang} - {h.TenHang} ({h.GiaBan:N0}₫)"
                })
                .ToList();

            cboMaHang.DataSource = danhSach;
            cboMaHang.DisplayMember = "HienThi";
            cboMaHang.ValueMember = "MaHang";
        }
        private void Frm_Combo_Load(object sender, EventArgs e)
        {
            HienThiDanhSachCombo();
            ClearCombo();
        }

        private void dgvDSCombo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearComboDetail();
            int dong = e.RowIndex;
            if (dong >= 0)
            {
                txtMaCombo.Text = dgvDSCombo.Rows[dong].Cells[0].Value.ToString();
                if (txtMaCombo != null)
                {
                    txtTenCombo.Text = dgvDSCombo.Rows[dong].Cells[1].Value.ToString();
                    txtGia.Text = dgvDSCombo.Rows[dong].Cells[2].Value.ToString();
                    txtMoTa.Text = dgvDSCombo.Rows[dong].Cells[3].Value.ToString();
                    
                    dgvChiTietCombo.DataSource = bulCTCombo.LayChiTietTheoMaCombo(int.Parse(txtMaCombo.Text));
                    
                    dgvChiTietCombo.Columns["MaChiTietCombo"].Visible = false;
                    dgvChiTietCombo.Columns["MaCombo"].Visible = false;
                    dgvChiTietCombo.Columns["MaHang"].Visible = false;

                    dgvChiTietCombo.Columns["TenHang"].DisplayIndex = 0;
                    dgvChiTietCombo.Columns["SoLuong"].DisplayIndex = 1;


                    var cellValue = dgvDSCombo.Rows[e.RowIndex].Cells["HinhAnh"].Value;

                    if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
                    {
                        txtHinhAnh.Text = cellValue.ToString();

                        string duongDanAnh = Path.Combine(Application.StartupPath, "Image", "Combo", txtHinhAnh.Text);
                        if (File.Exists(duongDanAnh))
                        {
                            if (picAnhCombo.Image != null)
                            {
                                picAnhCombo.Image.Dispose();
                                picAnhCombo.Image = null;
                            }

                            picAnhCombo.Image = Image.FromFile(duongDanAnh);
                        }
                        else
                        {
                            picAnhCombo.Image = null;
                        }
                    }
                    else
                    {
                        txtHinhAnh.Text = string.Empty;
                        picAnhCombo.Image = null;
                    }

                }
            }
        }

        private void dgvChiTietCombo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            if (dong >= 0)
            {
                txtMaCTCombo.Text = dgvChiTietCombo.Rows[dong].Cells[0].Value?.ToString();
                cboMaHang.SelectedValue = dgvChiTietCombo.Rows[dong].Cells[2].Value;
                txtSoLuong.Text = dgvChiTietCombo.Rows[dong].Cells[3].Value?.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "THEM";
            ClearCombo();

            txtTenCombo.Enabled = true;
            txtGia.Enabled = true;
            txtMoTa.Enabled = true;

            btnChonAnh.Enabled = true;
            btnXacNhan.Enabled = true;


            btnThem.BackColor = Color.LightGreen;
            btnSua.BackColor = Color.White; 
            btnThem.Enabled = false;
            btnSua.Enabled = true;



        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearCombo();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh cho combo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileNguon = openFileDialog.FileName;
                    string tenFileAnh = Path.GetFileName(fileNguon);
                    string thuMucDich = Path.Combine(Application.StartupPath, "Image", "Combo");
                    string duongDanDich = Path.Combine(thuMucDich, tenFileAnh);

                    if (!Directory.Exists(thuMucDich))
                        Directory.CreateDirectory(thuMucDich);

                    if (!File.Exists(duongDanDich))
                        File.Copy(fileNguon, duongDanDich, false);

                    txtHinhAnh.Text = tenFileAnh;

                    picAnhCombo.Image = Image.FromFile(duongDanDich);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtMaCombo.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn một combo để chỉnh sửa");
                return;
            }

            currentAction = "CHINHSUA";

            txtTenCombo.Enabled = true;
            txtGia.Enabled = true;
            txtMoTa.Enabled = true;

            btnChonAnh.Enabled = true;
            btnXacNhan.Enabled = true;

            btnThem.BackColor = Color.White;
            btnSua.BackColor = Color.LightGreen;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (currentAction == "THEM")
            {
                if (string.IsNullOrWhiteSpace(txtTenCombo.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên combo.", "Thông báo");
                    return;
                }

                if (txtTenCombo.Text.Length > 100)
                {
                    MessageBox.Show("Tên combo không được quá 100 ký tự.", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtGia.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá tiền.", "Thông báo");
                    return;
                }

                if (!decimal.TryParse(txtGia.Text, out decimal gia))
                {
                    MessageBox.Show("Giá tiền phải là số hợp lệ.", "Thông báo");
                    return;
                }

                if (gia < 0)
                {
                    MessageBox.Show("Giá tiền không được nhỏ hơn 0.", "Thông báo");
                    return;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(txtMoTa.Text, @"[!@#$%^&*()?<>{}\|/]"))
                {
                    MessageBox.Show("Mô tả chứa ký tự không hợp lệ.", "Cảnh báo");
                    return;
                }

                if (txtMoTa.Text.Length > 255)
                {
                    MessageBox.Show("Mô tả không được quá 255 ký tự.", "Thông báo");
                    return;
                }

                if (txtHinhAnh.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng chọn ảnh.", "Thông báo");
                    return;
                }

                DTO_Combo combo = new DTO_Combo
                {
                    TenCombo = txtTenCombo.Text,
                    Gia = decimal.Parse(txtGia.Text),
                    MoTa = txtMoTa.Text,
                    HinhAnh = txtHinhAnh.Text,
                };

                if (bulCombo.ThemCombo(combo))
                {
                    MessageBox.Show("Thêm combo thành công!");
                    HienThiDanhSachCombo();
                    ClearCombo();
                }
                else
                {
                    MessageBox.Show("Thêm combo thất bại!");
                }
            }
            if (currentAction == "CHINHSUA")
            {

                if (string.IsNullOrWhiteSpace(txtTenCombo.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên combo.", "Thông báo");
                    return;
                }

                if (txtTenCombo.Text.Length > 100)
                {
                    MessageBox.Show("Tên combo không được quá 100 ký tự.", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtGia.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá tiền.", "Thông báo");
                    return;
                }

                if (!decimal.TryParse(txtGia.Text, out decimal gia))
                {
                    MessageBox.Show("Giá tiền phải là số hợp lệ.", "Thông báo");
                    return;
                }

                if (gia < 0)
                {
                    MessageBox.Show("Giá tiền không được nhỏ hơn 0.", "Thông báo");
                    return;
                }

                if (txtMoTa.Text.Length > 255)
                {
                    MessageBox.Show("Mô tả không được quá 255 ký tự.", "Thông báo");
                    return;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(txtMoTa.Text, @"[!@#$%^&*()?<>{}\|/]"))
                {
                    MessageBox.Show("Mô tả chứa ký tự không hợp lệ.", "Cảnh báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtHinhAnh.Text))
                {
                    MessageBox.Show("Vui lòng chọn ảnh.", "Thông báo");
                    return;
                }

                // Tạo DTO_Combo để cập nhật
                DTO_Combo combo = new DTO_Combo
                {
                    MaCombo = int.Parse(txtMaCombo.Text),
                    TenCombo = txtTenCombo.Text,
                    Gia = gia,
                    MoTa = txtMoTa.Text,
                    HinhAnh = txtHinhAnh.Text
                };

                // Gọi BUL để sửa combo
                if (bulCombo.SuaCombo(combo))
                {
                    MessageBox.Show("Cập nhật combo thành công!");
                    HienThiDanhSachCombo();
                    ClearCombo();
                }
                else
                {
                    MessageBox.Show("Cập nhật combo thất bại!");
                }
            }

            currentAction = string.Empty;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaCombo.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn combo cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                if (bulCombo.XoaCombo(int.Parse(txtMaCombo.Text)))
                {
                    MessageBox.Show("Xóa combo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachCombo();
                    ClearCombo();
                }
                else
                {
                    MessageBox.Show("Xóa combo thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            currentActionDetail = "THEM";   
            ClearComboDetail();

            cboMaHang.Enabled = true;
            txtSoLuong.Enabled = true;

            btnXacNhanChiTiet.Enabled = true;
            btnThemChiTiet.BackColor = Color.LightGreen;
            btnSuaChiTiet.BackColor = Color.White;
            btnThemChiTiet.Enabled = false;
            btnSuaChiTiet.Enabled = true;
        }

        private void btnLamMoiChiTiet_Click(object sender, EventArgs e)
        {
            ClearComboDetail();
        }

        private void btnSuaChiTiet_Click(object sender, EventArgs e)
        {
            if (txtMaCTCombo.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn một món ăn trong combo để chỉnh sửa");
                return;
            }

            currentActionDetail = "CHINHSUA";

            cboMaHang.Enabled = true;
            txtSoLuong.Enabled = true;

            btnXacNhanChiTiet.Enabled = true;
            btnThemChiTiet.BackColor = Color.White;
            btnSuaChiTiet.BackColor = Color.LightGreen;
            btnThemChiTiet.Enabled = true;
            btnSuaChiTiet.Enabled = false;
        }

        private void btnXacNhanChiTiet_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!");
                return;
            }

            if (cboMaHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng!");
                return;
            }

            int maCombo = int.Parse(txtMaCombo.Text);
            int maHang = (int)cboMaHang.SelectedValue;

            DTO_ChiTietCombo ct = new DTO_ChiTietCombo
            {
                MaCombo = maCombo,
                MaHang = maHang,
                SoLuong = soLuong
            };

            if (currentActionDetail == "THEM")
            {
                if (bulCTCombo.ThemChiTietCombo(ct))
                {
                    MessageBox.Show("Đã thêm chi tiết combo thành công!");
                    dgvChiTietCombo.DataSource = bulCTCombo.LayChiTietTheoMaCombo(int.Parse(txtMaCombo.Text));
                    ClearComboDetail();
                }
                else
                {
                    MessageBox.Show(" Thêm chi tiết combo thất bại!");
                }
            }


            if (currentActionDetail == "CHINHSUA")
            {
                ct.MaChiTietCombo = int.Parse(txtMaCTCombo.Text);

                if (bulCTCombo.SuaChiTietCombo(ct))
                {
                    MessageBox.Show("Cập nhật chi tiết combo thành công!");
                    dgvChiTietCombo.DataSource = bulCTCombo.LayChiTietTheoMaCombo(int.Parse(txtMaCombo.Text));
                    ClearComboDetail();
                }
                else
                {
                    MessageBox.Show("Cập nhật chi tiết combo thất bại!");
                }
            }

            currentActionDetail = string.Empty;
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCTCombo.Text))
            {
                MessageBox.Show("Vui lòng chọn chi tiết combo cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maChiTietCombo = int.Parse(txtMaCTCombo.Text);

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa chi tiết combo này không?",
                                          "Xác nhận",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool ketQua = bulCTCombo.XoaChiTietCombo(maChiTietCombo);

                if (ketQua)
                {
                    MessageBox.Show("Xóa chi tiết combo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvChiTietCombo.DataSource = bulCTCombo.LayChiTietTheoMaCombo(int.Parse(txtMaCombo.Text));
                    ClearComboDetail();
                }
                else
                {
                    MessageBox.Show("Không thể xóa chi tiết combo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
