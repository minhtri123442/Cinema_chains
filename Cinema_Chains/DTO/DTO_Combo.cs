using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Combo
    {
        public int MaCombo { get; set; }
        public string TenCombo { get; set; }
        public decimal Gia { get; set; }
        public string MoTa { get; set; }    
        public string HinhAnh { get; set; }
        public bool TrangThai { get; set; } = true;

        public DTO_Combo() { }

        public DTO_Combo(int maCombo, string tenCombo, decimal gia, string moTa, string hinhAnh, bool trangThai = true)
        {
            MaCombo = maCombo;
            TenCombo = tenCombo;
            Gia = gia;
            MoTa = moTa;
            HinhAnh = hinhAnh;
            TrangThai = trangThai;
        }
    }
}
