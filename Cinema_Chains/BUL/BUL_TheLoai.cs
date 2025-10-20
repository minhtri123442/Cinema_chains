using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_TheLoai
    {
        private readonly DAL_TheLoai dal = new DAL_TheLoai();

        public List<DTO_TheLoai> LayDanhSachTheLoai() => dal.LayDanhSachTheLoai();

        public bool ThemTheLoai(DTO_TheLoai tl) => dal.ThemTheLoai(tl);

        public bool SuaTheLoai(DTO_TheLoai tl) => dal.SuaTheLoai(tl);

        public bool XoaTheLoai(int ma) => dal.XoaTheLoai(ma);

        public List<DTO_TheLoai> TimKiemTheLoai(string tuKhoa) => dal.TimKiemTheLoai(tuKhoa);
    }
}
