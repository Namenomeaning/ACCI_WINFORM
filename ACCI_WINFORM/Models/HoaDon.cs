using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ACCI_WINFORM.Models
{
    public class HoaDon
    {
        public string MaHoaDon { get; set; }
        public string MaPhieuDK { get; set; }
        public string MaPhieuGiaHan { get; set; }
        public string MaUuDai { get; set; }
        public string MaNV_KeToan { get; set; }
        public DateTime NgayLap { get; set; }
        public string PhuongThuc { get; set; } // TienMat, ChuyenKhoan
        public string MaGiaoDich { get; set; }
        public decimal TongTienGoc { get; set; }
        public decimal SoTienGiam { get; set; }
        public decimal TongThu { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string TrangThaiTT { get; set; } // ChuaTT, DaTT, Huy
    }
}
