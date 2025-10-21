using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Phim
    {
        public int MaPhim { get; set; }
        public string TenPhim { get; set; }
        public int? ThoiLuong { get; set; }
        public string TrangThai { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int MaNPP { get; set; }

        public DTO_Phim() { }

        public DTO_Phim(int maPhim, string tenPhim, int thoiLuong, string trangThai, string hinhAnh, string moTa, int maNPP)
        {
            MaPhim = maPhim;
            TenPhim = tenPhim;
            ThoiLuong = thoiLuong;
            TrangThai = trangThai;
            HinhAnh = hinhAnh;
            MoTa = moTa;
            MaNPP = maNPP;
        }

        public DTO_Phim(string tenPhim, int thoiLuong, string trangThai, string hinhAnh, string moTa, int maNPP)
        {
            TenPhim = tenPhim;
            ThoiLuong = thoiLuong;
            TrangThai = trangThai;
            HinhAnh = hinhAnh;
            MoTa = moTa;
            MaNPP = maNPP;
        }
    }
}
