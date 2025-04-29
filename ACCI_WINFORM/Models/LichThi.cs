using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCI_WINFORM.Models
{
    public class LichThi
    {
        public string MaLichThi { get; set; }
        public string MaDanhGia { get; set; }
        public string MaPhongThi { get; set; }
        public DateTime NgayThi { get; set; }
        public TimeSpan GioThi { get; set; }
        public int SoLuongMax { get; set; }
        public int SoLuongDK { get; set; }
        public string TrangThai { get; set; } // MoDangKy, DuCho, Dong, DaThi
    }
}