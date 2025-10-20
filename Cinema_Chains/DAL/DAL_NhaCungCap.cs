using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhaCungCap
    {
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();
        public List<NhaCungCap> LayDanhSachNCC()
        {
            return db.NhaCungCaps.ToList();
        }

        public bool KiemTraNhaCungCapCoPhieuNhap(int maNCC)
        {
            return db.PhieuNhaps.Any(p => p.MaNCC == maNCC);
        }

        public bool KiemTraEmailTonTai(string email, int maNCC = 0)
        {
            var existing = db.NhaCungCaps.FirstOrDefault(x => x.Email == email);
            if (existing == null) return false;

            // Nếu đang sửa, cho phép trùng chính nó
            if (maNCC != 0 && existing.MaNCC == maNCC) return false;

            return true;
        }

        public bool ThemNCC(DTO_NhaCungCap ncc)
        {
            try
            {
                var newNCC = new NhaCungCap
                {
                    TenNCC = ncc.TenNCC,
                    DiaChi = ncc.DiaChi,
                    DienThoai = ncc.DienThoai,
                    Email = ncc.Email
                };
                db.NhaCungCaps.InsertOnSubmit(newNCC);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaNCC(DTO_NhaCungCap ncc)
        {
            try
            {
                var existing = db.NhaCungCaps.FirstOrDefault(x => x.MaNCC == ncc.MaNCC);
                if (existing == null) return false;

                existing.TenNCC = ncc.TenNCC;
                existing.DiaChi = ncc.DiaChi;
                existing.DienThoai = ncc.DienThoai;
                existing.Email = ncc.Email;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaNCC(int maNCC)
        {
            try
            {
                var ncc = db.NhaCungCaps.FirstOrDefault(x => x.MaNCC == maNCC);
                if (ncc == null) return false;

                db.NhaCungCaps.DeleteOnSubmit(ncc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
