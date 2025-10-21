using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_Rap
    {
        private readonly DAL_NhanVien dal = new DAL_NhanVien();

        public List<DTO_Rap> LayDanhSachRap()
        {
            return dal.LayDanhSachRap();
        }
    }
}
