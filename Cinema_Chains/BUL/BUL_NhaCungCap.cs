using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_NhaCungCap
    {
        private readonly DAL_NhaCungCap dal = new DAL_NhaCungCap();

        public List<NhaCungCap> LayDanhSachNCC() => dal.LayDanhSachNCC();
        public bool ThemNCC(DTO_NhaCungCap ncc) => dal.ThemNCC(ncc);
        public bool SuaNCC(DTO_NhaCungCap ncc) => dal.SuaNCC(ncc);
        public bool XoaNCC(int maNCC) => dal.XoaNCC(maNCC);
        public bool KiemTraNCCCoPhieuNhap(int maNCC)
        {
            return dal.KiemTraNhaCungCapCoPhieuNhap(maNCC);
        }

    }
}
