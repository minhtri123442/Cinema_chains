using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_LichChieu
    {
        private DAL_LichChieu dalLichChieu = new DAL_LichChieu();

     

        // Lấy danh sách tất cả lịch chiếu
        public List<DTO_LichChieu> GetAll()
        {
            return dalLichChieu.GetAll();
        }

        // Thêm lịch chiếu
        public bool Insert(DTO_LichChieu lichChieu)
        {
            if (lichChieu == null)
                throw new ArgumentNullException(nameof(lichChieu));

            // Kiểm tra giờ chiếu hợp lệ
            if (lichChieu.gioKetThuc <= lichChieu.gioBatDau)
                throw new Exception("Giờ kết thúc phải sau giờ bắt đầu.");

            return dalLichChieu.Insert(lichChieu);
        }

        // Cập nhật lịch chiếu
        public bool Update(DTO_LichChieu lichChieu)
        {
            if (lichChieu == null)
                throw new ArgumentNullException(nameof(lichChieu));

            if (lichChieu.gioKetThuc <= lichChieu.gioBatDau)
                throw new Exception("Giờ kết thúc phải sau giờ bắt đầu.");

            return dalLichChieu.Update(lichChieu);
        }

        // Xóa lịch chiếu
        public bool Delete(int maLichChieu)
        {
            if (maLichChieu <= 0)
                throw new Exception("Mã lịch chiếu không hợp lệ.");

            return dalLichChieu.Delete(maLichChieu);
        }

       
    }
}
