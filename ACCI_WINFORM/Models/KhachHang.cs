using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCI_WINFORM.Models
{
    public class KhachHang
    {
        public string MaKhachHang { get; set; }
        public string LoaiKhach { get; set; } // TuDo, DonVi
        public string HoTen { get; set; }
        public string TenDonVi { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
    }
}