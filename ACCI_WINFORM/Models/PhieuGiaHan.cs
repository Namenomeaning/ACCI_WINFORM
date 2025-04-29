using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using ACCI_WINFORM.Models;

namespace ACCI_WINFORM.Models
{
    public class PhieuGiaHan
    {
        public string MaPhieuGiaHan { get; set; }
        public string MaPhieuDK { get; set; }
        public int ThuTu_CT { get; set; }
        public string MaLichThi_Cu { get; set; }
        public string MaLichThi_Moi { get; set; }
        public string LyDo { get; set; }
        public DateTime NgayYC { get; set; }
        public string MaNV_XuLy { get; set; }
        public string TrangThai { get; set; } // YeuCau, DaDuyet, ChoThanhToan, HoanTat, TuChoi
        public string MaPhiGiaHan { get; set; }
    }
}
