using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUS_NhanVien
    {
        private readonly DAL_NhanVien dal = new DAL_NhanVien();

        // Lấy danh sách rạp
        public List<DTO_Rap> LayDanhSachRap()
        {
            return dal.LayDanhSachRap();
        }

        // Đăng nhập
        public DTO_NhanVien DangNhap(string email, string matKhau)
        {
            return dal.DangNhap(email, matKhau);
        }

        // Lấy nhân viên theo mã
        public DTO_NhanVien LayNhanVienTheoMa(int maNV)
        {
            return dal.LayNhanVienTheoMa(maNV);
        }
    }
}
