using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUL
{
    public class BUL_NhaPhanPhoi
    {
        private readonly DAL_NhaPhanPhoi dalNPP = new DAL_NhaPhanPhoi();

        public List<DTO_NhaPhanPhoi> LayDanhSachNhaPhanPhoi()
        {
            return dalNPP.LayDanhSachNhaPhanPhoi();
        }

        public DTO_NhaPhanPhoi LayNhaPhanPhoiTheoMa(int maNPP)
        {
            return dalNPP.LayNhaPhanPhoiTheoMa(maNPP);
        }

        public bool Insert(DTO_NhaPhanPhoi dto)
        {
            return dalNPP.Insert(dto);
        }

        public bool Update(DTO_NhaPhanPhoi dto)
        {
            return dalNPP.Update(dto);
        }

        public bool Delete(int ma)
        {
            return dalNPP.Delete(ma);
        }
    }
}
