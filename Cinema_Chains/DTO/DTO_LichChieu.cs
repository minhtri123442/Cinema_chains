using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LichChieu
    {
        public int maLichChieu { get; set; }
        public int? maPhim { get; set; }
        public int? maPhong { get; set; }
        public DateTime ngayChieu { get; set; }
        public DateTime? gioBatDau { get; set; }
        public DateTime? gioKetThuc { get; set; }
        public string trangThai { get; set; }
        public decimal? giaVe {  get; set; }

        public DTO_LichChieu(int maLichChieu, int? maPhim, int? maPhong, DateTime ngayChieu, DateTime? gioBatDau, DateTime? gioKetThuc, string trangThai, decimal? giaVe)
        {
            this.maLichChieu = maLichChieu;
            this.maPhim = maPhim;
            this.maPhong = maPhong;
            this.ngayChieu = ngayChieu;
            this.gioBatDau = gioBatDau;
            this.gioKetThuc = gioKetThuc;
            this.trangThai = trangThai;
            this.giaVe = giaVe;
        }
    }
}
