using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_PhanPhoiPhim
    {
        private readonly DAL_PhanPhoiPhim dalPhanPhoiPhim = new DAL_PhanPhoiPhim();

        // Lấy danh sách tất cả phân phối phim
        public List<DTO_PhanPhoiPhim> GetAll()
        {
            return dalPhanPhoiPhim.GetAll();
        }

        // Thêm phân phối phim mới
        public bool Insert(DTO_PhanPhoiPhim dto)
        {
            // Kiểm tra dữ liệu hợp lệ trước khi thêm
            if (dto == null || dto.maPhim <= 0 || dto.maRap <= 0)
                return false;

            if (dto.ngayKetThuc.HasValue && dto.ngayKetThuc < dto.ngayBatDau)
                return false; // Ngày kết thúc không được nhỏ hơn ngày bắt đầu

            return dalPhanPhoiPhim.Insert(dto);
        }

        // Cập nhật phân phối phim
        public bool Update(DTO_PhanPhoiPhim dto)
        {
            if (dto == null || dto.maPhim <= 0 || dto.maRap <= 0)
                return false;

            if (dto.ngayKetThuc.HasValue && dto.ngayKetThuc < dto.ngayBatDau)
                return false;

            return dalPhanPhoiPhim.Update(dto);
        }

        // Xóa phân phối phim theo MaPhim và MaRap
        public bool Delete(int maPhim, int maRap)
        {
            if (maPhim <= 0 || maRap <= 0)
                return false;

            return dalPhanPhoiPhim.Delete(maPhim, maRap);
        }
    }
}
