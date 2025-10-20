using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhaPhanPhoi
    {
        public int MaNPP { get; set; }
        public string TenNPP { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public DTO_NhaPhanPhoi() { }

        public DTO_NhaPhanPhoi(int maNPP, string tenNPP, string diaChi, string soDienThoai)
        {
            MaNPP = maNPP;
            TenNPP = tenNPP;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }
    }
}
