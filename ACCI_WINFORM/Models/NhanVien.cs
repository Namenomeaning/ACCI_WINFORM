using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCI_WINFORM.Models
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; } // TiepNhan, KeToan, NhapLieu
        public string TrangThai { get; set; } // DangLam, NghiViec
    }
}