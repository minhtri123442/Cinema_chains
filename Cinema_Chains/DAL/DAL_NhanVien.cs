using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public class DAL_NhanVien
    {
        //private readonly Cinema_ChainsDataContext db = new Cinema_ChainsDataContext();
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();


        public List<DTO_Rap> LayDanhSachRap()
        {
            return (from r in db.Raps
                    select new DTO_Rap
                    {
                        MaRap = r.MaRap,
                        TenRap = r.TenRap,
                        DiaChi = r.DiaChi
                    }).ToList();
        }
        // Hàm kiểm tra đăng nhập
        public DTO_NhanVien DangNhap(string email, string matKhau)
        {
            var result = (from nv in db.NhanViens
                          join r in db.Raps on nv.MaRap equals r.MaRap
                          where nv.Email == email && nv.MatKhau == matKhau
                          select new DTO_NhanVien
                          {
                              MaNV = nv.MaNV,
                              HoTen = nv.HoTen,
                              ChucVu = nv.ChucVu,
                              DienThoai = nv.DienThoai,
                              Email = nv.Email,
                              MatKhau = nv.MatKhau,
                              TrangThai = nv.TrangThai,
                              MaRap = nv.MaRap,
                              TenRap = r.TenRap
                          }).FirstOrDefault();

            return result;

        }

        //lấy nhân viên theo mã
        public DTO_NhanVien LayNhanVienTheoMa(int maNV)
        {
            var nv = (from n in db.NhanViens
                      join r in db.Raps on n.MaRap equals r.MaRap
                      where n.MaNV == maNV
                      select new DTO_NhanVien
                      {
                          MaNV = n.MaNV,
                          HoTen = n.HoTen,
                          ChucVu = n.ChucVu,
                          DienThoai = n.DienThoai,
                          Email = n.Email,
                          MatKhau = n.MatKhau,
                          TrangThai = n.TrangThai,
                          MaRap = n.MaRap,
                          TenRap = r.TenRap
                      }).FirstOrDefault();

            return nv;
        }
    }
}

