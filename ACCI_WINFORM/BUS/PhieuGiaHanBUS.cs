using ACCI_WINFORM.DAO;
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class PhieuGiaHanBUS
    {
        private PhieuGiaHanDAO phieuGiaHanDAO = new PhieuGiaHanDAO();

        public bool ThemPhieuGiaHan(PhieuGiaHan phieuGiaHan)
        {
            phieuGiaHan.NgayYC = DateTime.Now;
            phieuGiaHan.TrangThai = "ChoThanhToan";
            // Không gán cứng MaNV_XuLy, giá trị đã được truyền từ form
            if (string.IsNullOrEmpty(phieuGiaHan.MaNV_XuLy))
            {
                throw new Exception("Mã nhân viên xử lý không được để trống!");
            }

            return phieuGiaHanDAO.ThemPhieuGiaHan(phieuGiaHan) > 0;
        }

        public PhieuGiaHan LayPhieuGiaHan(string maPhieuGiaHan)
        {
            DataTable dt = phieuGiaHanDAO.LayPhieuGiaHan(maPhieuGiaHan);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToPhieuGiaHan(dt.Rows[0]);
        }

        public PhieuGiaHan LayPhieuGiaHanTheoMaPhieuDKVaLichThi(string maPhieuDK, string maLichThiCu, string maLichThiMoi)
        {
            DataTable dt = phieuGiaHanDAO.LayPhieuGiaHanTheoMaPhieuDKVaLichThi(maPhieuDK, maLichThiCu, maLichThiMoi);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToPhieuGiaHan(dt.Rows[0]);
        }

        public List<PhieuGiaHan> LayDSPhieuGiaHan()
        {
            DataTable dt = phieuGiaHanDAO.LayDSPhieuGiaHan();
            var phieuGiaHanList = new List<PhieuGiaHan>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    phieuGiaHanList.Add(MapDataRowToPhieuGiaHan(row));
                }
            }
            return phieuGiaHanList;
        }

        public bool CapNhatPhieuGiaHan(PhieuGiaHan phieuGiaHan)
        {
            return phieuGiaHanDAO.CapNhatPhieuGiaHan(phieuGiaHan) > 0;
        }

        public bool XoaPhieuGiaHan(string maPhieuGiaHan)
        {
            var phieu = LayPhieuGiaHan(maPhieuGiaHan);
            if (phieu != null && phieu.TrangThai != "ChoXuLy")
            {
                return false;
            }
            return phieuGiaHanDAO.XoaPhieuGiaHan(maPhieuGiaHan) > 0;
        }

        public decimal LayDonGiaPhiGiaHan(string maPhiGiaHan)
        {
            DataTable dt = phieuGiaHanDAO.LayDonGiaPhiGiaHan(maPhiGiaHan);
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception($"Không tìm thấy phí gia hạn với mã {maPhiGiaHan}");
            }
            return Convert.ToDecimal(dt.Rows[0]["DonGia"]);
        }

        private PhieuGiaHan MapDataRowToPhieuGiaHan(DataRow row)
        {
            return new PhieuGiaHan
            {
                MaPhieuGiaHan = row["MaPhieuGiaHan"].ToString(),
                MaPhieuDK = row["MaPhieuDK"].ToString(),
                ThuTu_CT = Convert.ToInt32(row["ThuTu_CT"]),
                MaLichThi_Cu = row["MaLichThi_Cu"].ToString(),
                MaLichThi_Moi = row["MaLichThi_Moi"].ToString(),
                LyDo = row["LyDo"].ToString(),
                NgayYC = Convert.ToDateTime(row["NgayYC"]),
                MaNV_XuLy = row["MaNV_XuLy"] != DBNull.Value ? row["MaNV_XuLy"].ToString() : null,
                TrangThai = row["TrangThai"].ToString(),
                MaPhiGiaHan = row["MaPhiGiaHan"] != DBNull.Value ? row["MaPhiGiaHan"].ToString() : null
            };
        }
    }
}