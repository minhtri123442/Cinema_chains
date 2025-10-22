using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhanPhoiPhim
    {
        public int maPhim { get; set; }
        public int maRap { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime? ngayKetThuc { get; set; }

        public DTO_PhanPhoiPhim() { }

        public DTO_PhanPhoiPhim(int maPhim, int maRap, DateTime ngayBatDau, DateTime? ngayKetThuc)
        {
            this.maPhim = maPhim;
            this.maRap = maRap;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }
    }
}
