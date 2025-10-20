using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhaPhanPhoi
    {
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();

        // Lấy danh sách toàn bộ nhà phân phối
        public List<DTO_NhaPhanPhoi> LayDanhSachNhaPhanPhoi()
        {
            var ds = from n in db.NhaPhanPhois
                     select new DTO_NhaPhanPhoi
                     {
                         MaNPP = n.MaNPP,
                         TenNPP = n.TenNPP,
                         DiaChi = n.DiaChi,
                         SoDienThoai = n.DienThoai
                     };
            return ds.ToList();
        }

        // Lấy thông tin chi tiết theo mã
        public DTO_NhaPhanPhoi LayNhaPhanPhoiTheoMa(int maNPP)
        {
            var npp = db.NhaPhanPhois.FirstOrDefault(n => n.MaNPP == maNPP);
            if (npp == null) return null;

            return new DTO_NhaPhanPhoi
            {
                MaNPP = npp.MaNPP,
                TenNPP = npp.TenNPP,
                DiaChi = npp.DiaChi,
                SoDienThoai = npp.DienThoai
            };
        }
    }
}
