using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TheLoai
    {
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();

        public List<DTO_TheLoai> LayDanhSachTheLoai()
        {
            var ds = from tl in db.TheLoais
                     select new DTO_TheLoai
                     {
                         MaTheLoai = tl.MaTheLoai,
                         TenTheLoai = tl.TenTheLoai,
                     };
            return ds.ToList();
        }

        public bool ThemTheLoai(DTO_TheLoai theLoai)
        {
            try
            {
                TheLoai tl = new TheLoai
                {
                    TenTheLoai = theLoai.TenTheLoai,
                };
                db.TheLoais.InsertOnSubmit(tl);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool SuaTheLoai(DTO_TheLoai theLoai)
        {
            try
            {
                var tl = db.TheLoais.FirstOrDefault(x => x.MaTheLoai == theLoai.MaTheLoai);
                if (tl == null) return false;

                tl.TenTheLoai = theLoai.TenTheLoai;

                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool XoaTheLoai(int maTheLoai)
        {
            try
            {
                var tl = db.TheLoais.FirstOrDefault(x => x.MaTheLoai == maTheLoai);
                if (tl == null) return false;

                db.TheLoais.DeleteOnSubmit(tl);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public List<DTO_TheLoai> TimKiemTheLoai(string tuKhoa)
        {
            var ds = from tl in db.TheLoais
                     where tl.TenTheLoai.Contains(tuKhoa)
                     select new DTO_TheLoai
                     {
                         MaTheLoai = tl.MaTheLoai,
                         TenTheLoai = tl.TenTheLoai,
                     };
            return ds.ToList();
        }
    }
}
