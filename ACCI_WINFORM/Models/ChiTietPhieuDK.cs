using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using System;

namespace ACCI_WINFORM.Models
{
    public class ChiTietPhieuDK
    {
        public string MaPhieuDK { get; set; }
        public int ThuTu { get; set; }
        public string MaThiSinh { get; set; }
        public string MaLichThi { get; set; }
        public string SoBaoDanh { get; set; }
        public string TrangThaiCT { get; set; } // DK, CoSBD, Vang, DaThi, Dat, KhongDat
        public decimal? Diem { get; set; }
        public string KetQua { get; set; } // Dat, KhongDat
        public DateTime? NgayCoKetQua { get; set; }
        public string MaNV_NhapLieu { get; set; }
    }
}
