using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class BUL_ChiTietCombo
    {
        private readonly dal_ChiTietCombo dal = new dal_ChiTietCombo();

        public bool XoaChiTietCombo(int maChiTietCombo)
        {
            return dal.XoaChiTietCombo(maChiTietCombo);
        }

        public bool SuaChiTietCombo(DTO_ChiTietCombo ct)
        {
            return dal.SuaChiTietCombo(ct);
        }

        public bool ThemChiTietCombo(DTO_ChiTietCombo ct)
        {
            return dal.ThemChiTietCombo(ct);
        }

        public List<DTO_ChiTietCombo> LayChiTietTheoMaCombo(int maCombo)
        {
            return dal.LayChiTietTheoMaCombo(maCombo);
        }
    }
}
