using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_Phong
    {
        private DAL_Phong dalPhong = new DAL_Phong();

        public List<DTO_Phong> GetAll()
        {
            return dalPhong.GetAll();
        }
    }
}
