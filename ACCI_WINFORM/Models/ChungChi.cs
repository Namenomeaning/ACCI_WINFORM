using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ACCI_WINFORM.Models
{
    public class ChungChi
    {
        public string MaChungChi { get; set; }
        public string SoHieu { get; set; }
        public string MaPhieuDK { get; set; }
        public int ThuTu { get; set; }
        public string MaThiSinh { get; set; }
        public DateTime NgayCap { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string PhuongThucNhan { get; set; } // TaiTT, BuuDien
        public string DiaChiNhan { get; set; }
        public DateTime? NgayNhan { get; set; }
        public string TrangThaiNhan { get; set; } // ChuaNhan, DaNhan
        public string MaNV_CapNhat { get; set; }
    }
}
