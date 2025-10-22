using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhanPhoiPhim
    {
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();

        // Lấy danh sách tất cả lịch chiếu
        public List<DTO_PhanPhoiPhim> GetAll()
        {
            var query = from pp in db.PhanPhoiPhims
                        select new DTO_PhanPhoiPhim
                        {
                            maPhim = pp.MaPhim,
                            maRap = pp.MaRap,
                            ngayBatDau = pp.NgayBatDau,
                            ngayKetThuc = pp.NgayKetThuc
                        };

            return query.ToList();
        }

        // Thêm phân phối phim
        public bool Insert(DTO_PhanPhoiPhim dto)
        {
            try
            {
                PhanPhoiPhim pp = new PhanPhoiPhim
                {
                   MaPhim = dto.maPhim,
                   MaRap = dto.maRap,
                   NgayBatDau = dto.ngayBatDau,
                   NgayKetThuc = dto.ngayKetThuc,

                };
                db.PhanPhoiPhims.InsertOnSubmit(pp);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa phân phối phim
        public bool Update(DTO_PhanPhoiPhim dto)
        {
            try
            {
                var pp = db.PhanPhoiPhims
                           .FirstOrDefault(x => x.MaPhim == dto.maPhim && x.MaRap == dto.maRap);
                if (pp == null) return false;

                pp.NgayBatDau = dto.ngayBatDau;
                pp.NgayKetThuc = dto.ngayKetThuc;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa phân phối phim (theo MaPhim và MaRap)
        public bool Delete(int maPhim, int maRap)
        {
            try
            {
                var pp = db.PhanPhoiPhims
                           .FirstOrDefault(x => x.MaPhim == maPhim && x.MaRap == maRap);
                if (pp == null) return false;

                db.PhanPhoiPhims.DeleteOnSubmit(pp);
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
