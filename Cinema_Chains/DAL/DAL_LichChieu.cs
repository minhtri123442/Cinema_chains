using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LichChieu
    {
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();

        // Lấy danh sách tất cả lịch chiếu
        public List<DTO_LichChieu> GetAll()
        {
            var query = from lc in db.LichChieus
                        select new DTO_LichChieu(
                            lc.MaLichChieu,
                            lc.MaPhim,
                            lc.MaPhong,
                            lc.NgayChieu,
                            lc.GioBatDau,
                            lc.GioKetThuc,
                            lc.TrangThai,
                            lc.GiaVe
                        );

            return query.ToList();
        }

        // Thêm lịch chiếu mới
        public bool Insert(DTO_LichChieu lichChieu)
        {
            try
            {
                LichChieu lc = new LichChieu
                {
                    MaPhim = lichChieu.maPhim,
                    MaPhong = lichChieu.maPhong,
                    NgayChieu = lichChieu.ngayChieu,
                    GioBatDau = lichChieu.gioBatDau,
                    GioKetThuc = lichChieu.gioKetThuc,
                    TrangThai = lichChieu.trangThai,
                    GiaVe = lichChieu.giaVe
                };
                db.LichChieus.InsertOnSubmit(lc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Sửa lịch chiếu
        public bool Update(DTO_LichChieu lichChieu)
        {
            try
            {
                var lc = db.LichChieus.FirstOrDefault(x => x.MaLichChieu == lichChieu.maLichChieu);
                if (lc == null) return false;

                lc.MaPhim = lichChieu.maPhim;
                lc.MaPhong = lichChieu.maPhong;
                lc.NgayChieu = lichChieu.ngayChieu;
                lc.GioBatDau = lichChieu.gioBatDau;
                lc.GioKetThuc = lichChieu.gioKetThuc;
                lc.TrangThai = lichChieu.trangThai;
                lc.GiaVe = lichChieu.giaVe;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa lịch chiếu
        public bool Delete(int maLichChieu)
        {
            try
            {
                var lc = db.LichChieus.FirstOrDefault(x => x.MaLichChieu == maLichChieu);
                if (lc == null) return false;

                db.LichChieus.DeleteOnSubmit(lc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        

    }
}
