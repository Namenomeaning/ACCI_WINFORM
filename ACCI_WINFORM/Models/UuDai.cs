using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ACCI_WINFORM.Models
{
    public class UuDai
    {
        public string MaUuDai { get; set; }
        public string TenUuDai { get; set; }
        public string Loai { get; set; } // TLPhanTram, TienMat
        public decimal GiaTri { get; set; }
        public string DieuKien { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public string TrangThai { get; set; } // DangApDung, HetHan
    }
}
