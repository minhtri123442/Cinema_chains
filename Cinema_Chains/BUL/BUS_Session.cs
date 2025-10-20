using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public static class SessionNV
    {
        public static DTO_NhanVien NhanVienHienTai { get; set; }

        public static void DangXuat()
        {
            NhanVienHienTai = null;
        }
    }
}
