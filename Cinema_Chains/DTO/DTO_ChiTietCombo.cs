using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietCombo
    {
        public int MaChiTietCombo { get; set; }
        public int MaCombo { get; set; }
        public int MaHang { get; set; }
        public int SoLuong { get; set; }

        public string TenHang { get; set; }

        public DTO_ChiTietCombo() { }

        public DTO_ChiTietCombo(int maChiTietCombo, int maCombo, int maHang, int soLuong, string tenHang)
        {
            MaChiTietCombo = maChiTietCombo;
            MaCombo = maCombo;
            MaHang = maHang;
            SoLuong = soLuong;
            TenHang = tenHang;
        }
    }
}
