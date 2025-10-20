using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dal_MatHang
    {

        //private readonly Cinema_ChainsDataContext db = new Cinema_ChainsDataContext();
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();

        public List<MatHang> LayDanhSachMatHang()
        {
            return db.MatHangs.ToList();
        }
    }
}
