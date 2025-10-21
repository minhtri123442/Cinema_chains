using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Phim
    {
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();

        // ==============================
        // Lấy danh sách phim
        // ==============================
        public List<DTO_Phim> LayDanhSachPhim()
        {
            var ds = from p in db.Phims
                     join npp in db.NhaPhanPhois on p.MaNPP equals npp.MaNPP
                     select new DTO_Phim
                     {
                         MaPhim = p.MaPhim,
                         TenPhim = p.TenPhim,
                         ThoiLuong = p.ThoiLuong,
                         TrangThai = p.TrangThai,
                         HinhAnh = p.HinhAnh,
                         MoTa = p.MoTa,
                         MaNPP = npp.MaNPP
                     };
            return ds.ToList();
        }

        // ==============================
        // Lấy danh sách thể loại của 1 phim
        // ==============================
        public List<int> LayMaTheLoaiTheoPhim(int maPhim)
        {
            return db.Phim_TheLoais
                     .Where(pt => pt.MaPhim == maPhim)
                     .Select(pt => pt.MaTheLoai)
                     .ToList();
        }

        // ==============================
        // Lấy danh sách thể loại
        // ==============================
        public List<TheLoai> LayDanhSachTheLoai()
        {
            return db.TheLoais.ToList();
        }

        // ==============================
        // Thêm phim mới + thể loại
        // ==============================
        public bool ThemPhim(DTO_Phim p, List<int> theLoaiList)
        {
            try
            {
                var phim = new Phim
                {
                    TenPhim = p.TenPhim,
                    ThoiLuong = p.ThoiLuong,
                    TrangThai = p.TrangThai,
                    HinhAnh = p.HinhAnh,
                    MoTa = p.MoTa,
                    MaNPP = p.MaNPP
                };

                db.Phims.InsertOnSubmit(phim);
                db.SubmitChanges();

                // Sau khi thêm phim, thêm thể loại liên kết
                foreach (int maTL in theLoaiList)
                {
                    var pt = new Phim_TheLoai
                    {
                        MaPhim = phim.MaPhim,
                        MaTheLoai = maTL
                    };
                    db.Phim_TheLoais.InsertOnSubmit(pt);
                }

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm phim: " + ex.Message);
                return false;
            }
        }

        // ==============================
        // Sửa thông tin phim
        // ==============================
        public bool SuaPhim(DTO_Phim p, List<int> theLoaiList)
        {
            try
            {
                var phim = db.Phims.SingleOrDefault(x => x.MaPhim == p.MaPhim);
                if (phim == null) return false;

                phim.TenPhim = p.TenPhim;
                phim.ThoiLuong = p.ThoiLuong;
                phim.TrangThai = p.TrangThai;
                phim.HinhAnh = p.HinhAnh;
                phim.MoTa = p.MoTa;
                phim.MaNPP = p.MaNPP;

                // Cập nhật lại thể loại
                var oldList = db.Phim_TheLoais.Where(x => x.MaPhim == p.MaPhim);
                db.Phim_TheLoais.DeleteAllOnSubmit(oldList);
                db.SubmitChanges();

                foreach (int maTL in theLoaiList)
                {
                    var pt = new Phim_TheLoai
                    {
                        MaPhim = p.MaPhim,
                        MaTheLoai = maTL
                    };
                    db.Phim_TheLoais.InsertOnSubmit(pt);
                }

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi sửa phim: " + ex.Message);
                return false;
            }
        }

        // ==============================
        // Xóa phim
        // ==============================
        public bool XoaPhim(int maPhim)
        {
            try
            {
                var p = db.Phims.FirstOrDefault(x => x.MaPhim == maPhim);
                if (p == null) return false;

                // Xóa thể loại liên kết trước
                var theLoaiLienKet = db.Phim_TheLoais.Where(x => x.MaPhim == maPhim);
                db.Phim_TheLoais.DeleteAllOnSubmit(theLoaiLienKet);
                db.SubmitChanges();

                db.Phims.DeleteOnSubmit(p);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa phim: " + ex.Message);
                return false;
            }
        }

        // ==============================
        // Tìm kiếm phim
        // ==============================
        public List<DTO_Phim> TimKiemPhim(string tuKhoa)
        {
            var ds = from p in db.Phims
                     join npp in db.NhaPhanPhois on p.MaNPP equals npp.MaNPP
                     where p.TenPhim.Contains(tuKhoa)
                        || p.TrangThai.Contains(tuKhoa)
                        || npp.TenNPP.Contains(tuKhoa)
                     select new DTO_Phim
                     {
                         MaPhim = p.MaPhim,
                         TenPhim = p.TenPhim,
                         ThoiLuong = p.ThoiLuong,
                         TrangThai = p.TrangThai,
                         HinhAnh = p.HinhAnh,
                         MoTa = p.MoTa,
                         MaNPP = p.MaNPP
                     };
            return ds.ToList();
        }

        
    }
}
