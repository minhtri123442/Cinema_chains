using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
            public int MaNV { get; set; }
            public string HoTen { get; set; }
            public string ChucVu { get; set; }
            public string DienThoai { get; set; }
            public string Email { get; set; }
            public string MatKhau { get; set; }
            public string TrangThai { get; set; }
            public int? MaRap { get; set; }
            public string TenRap { get; set; }


        //constructor không tham số
        public DTO_NhanVien() { }
            //constructor đầy đủ tham số
            public DTO_NhanVien(int maNV, string hoTen, string chucVu, string dienThoai,
                                string email, string matKhau, string trangThai, int maRap)
            {
                MaNV = maNV;
                HoTen = hoTen;
                ChucVu = chucVu;
                DienThoai = dienThoai;
                Email = email;
                MatKhau = matKhau;
                TrangThai = trangThai;
                MaRap = maRap;
            }
    }
}
