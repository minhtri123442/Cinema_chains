using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Phong
    {
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();

        public List<DTO_Phong> GetAll()
        {
            var query = from p in db.PhongChieus
                        select new DTO_Phong
                        {
                            maPhong = p.MaPhong,
                            tenPhong = p.TenPhong,
                            sucChua = p.SuaChua,
                            maRap = p.MaRap
                        };
            return query.ToList();
        }
    }
}
