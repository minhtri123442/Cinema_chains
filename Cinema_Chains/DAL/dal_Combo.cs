using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{

    public class dal_Combo
    {
        private readonly Cinema_ChainsDataContext db = dal_KetNoi.GetDataContext();


        // ******************************************************************************
        // ************************************************** Sửa Combo
        // ******************************************************************************
        public bool SuaCombo(DTO_Combo combo)
        {
            try
            {
                var existing = db.Combos.FirstOrDefault(c => c.MaCombo == combo.MaCombo);
                if (existing == null) return false;

                existing.TenCombo = combo.TenCombo;
                existing.Gia = combo.Gia;
                existing.MoTa = combo.MoTa;
                existing.HinhAnh = combo.HinhAnh;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // ******************************************************************************
        // ************************************************** Xóa Combo
        // ******************************************************************************
        public bool XoaCombo(int maCombo)
        {
            try
            {
                bool daSuDung = db.ChiTietHoaDonCombos.Any(x => x.MaCombo == maCombo);

                var combo = db.Combos.FirstOrDefault(x => x.MaCombo == maCombo);
                if (combo == null)
                    return false;

                if (daSuDung)
                {
                    combo.TrangThai = false;
                }
                else
                {
                    var chiTietCombos = db.ChiTietCombos.Where(x => x.MaCombo == maCombo);
                    db.ChiTietCombos.DeleteAllOnSubmit(chiTietCombos);
                    db.Combos.DeleteOnSubmit(combo);
                }

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // ******************************************************************************
        // ************************************************** Thêm Combo
        // ******************************************************************************
        public bool ThemCombo(DTO_Combo combo)
        {
            try
            {
                Combo c = new Combo
                {
                    TenCombo = combo.TenCombo,
                    Gia = combo.Gia,
                    MoTa = combo.MoTa,
                    HinhAnh = combo.HinhAnh,
                };
                c.TrangThai = true;
                db.Combos.InsertOnSubmit(c);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm combo: " + ex.Message);
                return false;
            }
        }

        // ******************************************************************************
        // ************************************************** Lấy danh sách Combo
        // ******************************************************************************

        public List<Combo> LayDanhSachCombo()
        {
            return db.Combos.Where(c => c.TrangThai == true).ToList();
        }
    }
}
