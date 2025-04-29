using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCI_WINFORM.Models
{
    public class PhieuDK
    {
        public string MaPhieuDK { get; set; }
        public string MaKhachHang { get; set; }
        public string MaNV_TiepNhan { get; set; }
        public DateTime NgayTao { get; set; }
        public int SoLanGiaHan { get; set; }
        public string TrangThai { get; set; } // Moi, ChoThanhToan, DaThanhToan, Huy, DaHoanTat
        public KhachHang KhachHang { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
