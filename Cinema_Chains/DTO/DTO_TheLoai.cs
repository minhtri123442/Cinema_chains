using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TheLoai
    {
        public int MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }

        public DTO_TheLoai() { }

        public DTO_TheLoai(int ma, string ten)
        {
            MaTheLoai = ma;
            TenTheLoai = ten;
        }
    }
}
