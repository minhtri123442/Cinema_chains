using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class bul_MatHang
    {
        private readonly dal_MatHang dal = new dal_MatHang();
        public List<MatHang> LayDanhSachMatHang()
        {
            return dal.LayDanhSachMatHang();
        }
    }
}
