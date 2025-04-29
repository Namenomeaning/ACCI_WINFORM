using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCI_WINFORM.Models
{
    public class ThongTinDangNhap
    {
        public string MaThongTinDangNhap { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhauHash { get; set; }
        public string MaNhanVien { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}