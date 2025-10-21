using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dal_ChiTietCombo
    {
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();

        // ******************************************************************************
        // ************************************************** Xóa 1 chi tiết combo
        // ******************************************************************************
        public bool XoaChiTietCombo(int maChiTietCombo)
        {
            try
            {
                var chiTiet = db.ChiTietCombos.FirstOrDefault(x => x.MaChiTietCombo == maChiTietCombo);
                if (chiTiet != null)
                {
                    db.ChiTietCombos.DeleteOnSubmit(chiTiet);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }



        // ******************************************************************************
        // ************************************************** CHỉnh sửa chi tiết combo
        // ******************************************************************************
        public bool SuaChiTietCombo(DTO_ChiTietCombo ct)
        {
            try
            {
                var a = db.ChiTietCombos.FirstOrDefault(x => x.MaChiTietCombo == ct.MaChiTietCombo);
                if (a == null) return false;

                a.MaHang = ct.MaHang;
                a.SoLuong = ct.SoLuong;
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        // ******************************************************************************
        // ************************************************** Thêm 1 món trong combo
        // ******************************************************************************
        public bool ThemChiTietCombo(DTO_ChiTietCombo ct)
        {
            try
            {
                ChiTietCombo chiTiet = new ChiTietCombo
                {
                    MaCombo = ct.MaCombo,
                    MaHang = ct.MaHang,
                    SoLuong = ct.SoLuong
                };

                db.ChiTietCombos.InsertOnSubmit(chiTiet);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // ******************************************************************************
        // ************************ Lấy danh sách từng món trong combo
        // ******************************************************************************
        public List<DTO_ChiTietCombo> LayChiTietTheoMaCombo(int maCombo)
        {
            var query = from ct in db.ChiTietCombos
                        join mh in db.MatHangs on ct.MaHang equals mh.MaHang
                        where ct.MaCombo == maCombo
                        select new DTO_ChiTietCombo
                        {
                            MaChiTietCombo = ct.MaChiTietCombo,
                            MaCombo = ct.MaCombo,
                            MaHang = ct.MaHang,
                            SoLuong = ct.SoLuong,
                            TenHang = mh.TenHang
                        };

            return query.ToList();
        }
    }
}
