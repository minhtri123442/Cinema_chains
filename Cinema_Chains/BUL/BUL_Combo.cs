using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class BUL_Combo
    {
        private readonly dal_Combo dal = new dal_Combo();


        public bool SuaCombo(DTO_Combo combo)
        {
            return dal.SuaCombo(combo);
        }
        public bool XoaCombo(int maCombo)
        {
            return dal.XoaCombo(maCombo);
        }

        public bool ThemCombo(DTO_Combo combo)
        {
            return dal.ThemCombo(combo);
        }
        
        public List<Combo> LayDanhSachCombo()
        {
            return dal.LayDanhSachCombo();
        }
    }
}
