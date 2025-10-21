using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_Phim
    {
        private readonly DAL_Phim dalPhim = new DAL_Phim();

        // ==========================
        // Lấy danh sách phim
        // ==========================
        public List<DTO_Phim> LayDanhSachPhim()
        {
            return dalPhim.LayDanhSachPhim();
        }

        // ==========================
        // Lấy danh sách thể loại của 1 phim
        // ==========================
        public List<int> LayMaTheLoaiTheoPhim(int maPhim)
        {
            return dalPhim.LayMaTheLoaiTheoPhim(maPhim);
        }

        // ==========================
        // Lấy danh sách thể loại
        // ==========================
        public List<TheLoai> LayDanhSachTheLoai()
        {
            return dalPhim.LayDanhSachTheLoai();
        }

        // ==========================
        // Thêm phim + danh sách thể loại
        // ==========================
        public bool ThemPhim(DTO_Phim phim, List<int> dsTheLoai)
        {
            if (phim == null || string.IsNullOrWhiteSpace(phim.TenPhim))
                return false;
            return dalPhim.ThemPhim(phim, dsTheLoai);
        }

        // ==========================
        // Sửa phim + danh sách thể loại
        // ==========================
        public bool SuaPhim(DTO_Phim phim, List<int> dsTheLoai)
        {
            if (phim == null || phim.MaPhim <= 0)
                return false;
            return dalPhim.SuaPhim(phim, dsTheLoai);
        }

        // ==========================
        // Xóa phim
        // ==========================
        public bool XoaPhim(int maPhim)
        {
            if (maPhim <= 0)
                return false;
            return dalPhim.XoaPhim(maPhim);
        }

        // ==========================
        // Tìm kiếm phim
        // ==========================
        public List<DTO_Phim> TimKiemPhim(string tuKhoa)
        {
            return dalPhim.TimKiemPhim(tuKhoa);
        }
    }
}

