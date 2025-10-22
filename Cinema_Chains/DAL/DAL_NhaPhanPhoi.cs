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

        // Thêm nhà phân phối mới
        public bool Insert(DTO_NhaPhanPhoi dto)
        {
            try
            {
                NhaPhanPhoi npp = new NhaPhanPhoi
                {
                    TenNPP = dto.TenNPP,
                    DiaChi = dto.DiaChi,
                    DienThoai = dto.SoDienThoai
                };
                db.NhaPhanPhois.InsertOnSubmit(npp);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        // Sửa nhà phân phối
        public bool Update(DTO_NhaPhanPhoi dto)
        {
            try
            {
                NhaPhanPhoi npp = db.NhaPhanPhois.FirstOrDefault(x => x.MaNPP == dto.MaNPP);
                if (npp == null) return false;
                npp.TenNPP = dto.TenNPP;
                npp.DiaChi = dto.DiaChi;
                npp.DienThoai = dto.SoDienThoai;
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        //Xóa nhà phân phối
        public bool Delete(int ma)
        {
            try
            {
                var npp = db.NhaPhanPhois.FirstOrDefault(x => x.MaNPP == ma);
                if (npp == null) return false;
                db.NhaPhanPhois.DeleteOnSubmit(npp);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
