using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Phong
    {
        public int maPhong {  get; set; }
        public string tenPhong { get; set; }
        public int? sucChua { get; set; }
        public int? maRap { get; set; }

        public DTO_Phong() { }

        public DTO_Phong(int maPhong, string tenPhong, int? sucChua, int? maRap)
        {
            this.maPhong = maPhong;
            this.tenPhong = tenPhong;
            this.sucChua = sucChua;
            this.maRap = maRap;
        }
    }
}
