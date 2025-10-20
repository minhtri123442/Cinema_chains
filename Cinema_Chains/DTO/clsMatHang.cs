using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsMatHang
    {
        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public string LoaiHang { get; set; }
        public string DonViNhap { get; set; }
        public string DonViBan { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public string GhiChu { get; set; }
        public string HinhAnh { get; set; }

        public clsMatHang() { }

        public clsMatHang(int maHang, string tenHang, string loaiHang, string donViNhap,
                          string donViBan, decimal giaNhap, decimal giaBan,
                          string ghiChu, string hinhAnh)
        {
            MaHang = maHang;
            TenHang = tenHang;
            LoaiHang = loaiHang;
            DonViNhap = donViNhap;
            DonViBan = donViBan;
            GiaNhap = giaNhap;
            GiaBan = giaBan;
            GhiChu = ghiChu;
            HinhAnh = hinhAnh;
        }
    }
}
