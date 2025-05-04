using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; // Required for LINQ operations if joining in BUS

namespace ACCI_WINFORM.BUS
{
    public class ChiTietPhieuDKBUS
    {
        private ChiTietPhieuDKDAO chiTietPhieuDKDAO = new ChiTietPhieuDKDAO();
        private ThiSinhBUS thiSinhBUS = new ThiSinhBUS(); // Dependency for getting HoTen

        public bool ThemChiTietPhieuDK(ChiTietPhieuDK chiTiet)
        {
            bool success = DatabaseHelper.ExecuteTransaction((connection, transaction) =>
            {
                return chiTietPhieuDKDAO.ThemChiTietPhieuDK(chiTiet, connection, transaction);
            }, out bool result);

            return success && result;
        }

        public ChiTietPhieuDK LayChiTietPhieuDK(string maPhieuDK, int thuTu)
        {
            DataTable dt = chiTietPhieuDKDAO.LayChiTietPhieuDK(maPhieuDK, thuTu);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToChiTiet(dt.Rows[0]);
        }

        public List<ChiTietPhieuDK> LayDSChiTietPhieuDK(string maPhieuDK)
        {
            DataTable dt = chiTietPhieuDKDAO.LayDSChiTietPhieuDK(maPhieuDK);
            return MapDataTableToChiTietList(dt);
        }

        public ChiTietPhieuDK LayChiTietPhieuDKDangKyTheoMaThiSinh(string maThiSinh)
        {
            DataTable dt = chiTietPhieuDKDAO.LayChiTietPhieuDKTheoMaThiSinh(maThiSinh);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            // Assuming only one active registration ('DK') per student is allowed by business rules
            return MapDataRowToChiTiet(dt.Rows[0]);
        }


        public bool CapNhatChiTietPhieuDK(ChiTietPhieuDK chiTiet)
        {
            // Add validation
            return chiTietPhieuDKDAO.CapNhatChiTietPhieuDK(chiTiet) > 0;
        }

        public bool XoaChiTietPhieuDK(string maPhieuDK, int thuTu)
        {
            // Add business logic: Cannot delete if TrangThaiCT is 'DaThi'?
            ChiTietPhieuDK chiTiet = LayChiTietPhieuDK(maPhieuDK, thuTu);
            if (chiTiet != null && chiTiet.TrangThaiCT == "DaThi") // Assuming 'DaThi' means 'Taken'
            {
                // Log error or inform user
                return false;
            }
            return chiTietPhieuDKDAO.XoaChiTietPhieuDK(maPhieuDK, thuTu) > 0;
        }

        // Method to join data in BUS layer
        public DataTable LayDanhSachThiSinhTheoLichThi(string maLichThi)
        {
            // 1. Get details from DAO
            DataTable dtCT = chiTietPhieuDKDAO.LayDanhSachThiSinhTheoLichThi(maLichThi);

            if (dtCT == null || dtCT.Rows.Count == 0)
            {
                return new DataTable(); // Return empty table if no details found
            }

            // 2. Get list of MaThiSinh from the results
            List<string> maThiSinhList = dtCT.AsEnumerable()
                                           .Select(row => row["MaThiSinh"].ToString())
                                           .Distinct()
                                           .ToList();

            // 3. Get ThiSinh info (HoTen) from ThiSinhBUS
            DataTable dtThiSinh = thiSinhBUS.LayDanhSachThiSinhTheoMa(maThiSinhList); // Assumes ThiSinhBUS has this method

            if (dtThiSinh == null || dtThiSinh.Rows.Count == 0)
            {
                // Handle cases where ThiSinh info might be missing, maybe return dtCT as is or log error
                // For now, we'll create the structure but might have null HoTen
                dtThiSinh = new DataTable();
                dtThiSinh.Columns.Add("MaThiSinh", typeof(string));
                dtThiSinh.Columns.Add("HoTen", typeof(string));
            }


            // 4. Create the final result DataTable structure
            DataTable result = new DataTable();
            result.Columns.Add("MaPhieuDK", typeof(string));
            result.Columns.Add("ThuTu", typeof(int));
            result.Columns.Add("MaThiSinh", typeof(string));
            result.Columns.Add("HoTen", typeof(string)); // Added HoTen column
            result.Columns.Add("SoBaoDanh", typeof(string));
            result.Columns.Add("Diem", typeof(decimal)); // Assuming Diem is decimal based on original mapping

            // 5. Join the data in memory (using LINQ)
            var queryResult = from ctRow in dtCT.AsEnumerable()
                              join tsRow in dtThiSinh.AsEnumerable()
                              on ctRow.Field<string>("MaThiSinh") equals tsRow.Field<string>("MaThiSinh") into thiSinhGroup
                              from ts in thiSinhGroup.DefaultIfEmpty() // Left join to handle missing ThiSinh
                              select new
                              {
                                  MaPhieuDK = ctRow.Field<string>("MaPhieuDK"),
                                  ThuTu = ctRow.Field<sbyte>("ThuTu"),
                                  MaThiSinh = ctRow.Field<string>("MaThiSinh"),
                                  HoTen = ts?.Field<string>("HoTen"), // Use null conditional operator
                                  SoBaoDanh = ctRow.Field<string>("SoBaoDanh"),
                                  Diem = ctRow.Field<decimal?>("Diem") // Allow null decimal
                              };

            // 6. Populate the result DataTable
            foreach (var item in queryResult)
            {
                result.Rows.Add(item.MaPhieuDK, item.ThuTu, item.MaThiSinh, item.HoTen ?? (object)DBNull.Value, item.SoBaoDanh ?? (object)DBNull.Value, item.Diem ?? (object)DBNull.Value);
            }


            return result;
        }

        public bool CapNhatDiemThi(string maPhieuDK, int thuTu, double diem, string maNhanVien)
        {
            // Business Logic: Determine KetQua and TrangThaiCT based on Diem
            string ketQua = (diem >= 5) ? "Dat" : "KhongDat"; // Assuming 5 is the passing score
            string trangThai = "DaThi"; // Status changes to 'Taken'

            // Validation: Check if MaNhanVien exists? Check if ChiTiet exists? Check if already graded?
            ChiTietPhieuDK chiTiet = LayChiTietPhieuDK(maPhieuDK, thuTu);
            if (chiTiet == null || chiTiet.TrangThaiCT == "DaThi")
            {
                // Cannot update score if not found or already graded
                return false;
            }

            return chiTietPhieuDKDAO.CapNhatDiemThi(maPhieuDK, thuTu, diem, maNhanVien, ketQua, trangThai) > 0;
        }

        public DataTable LayChiTietTheoThiSinhVaSoBaoDanh(string maThiSinh, string soBaoDanh)
        {
            // Maybe add validation for MaThiSinh format
            return chiTietPhieuDKDAO.LayChiTietTheoThiSinhVaSoBaoDanh(maThiSinh, soBaoDanh);
        }

        public DataTable LayChiTietTheoSoBaoDanh(string soBaoDanh)
        {
            return chiTietPhieuDKDAO.LayChiTietTheoSoBaoDanh(soBaoDanh);
        }

        // --- Helper Methods ---
        private ChiTietPhieuDK MapDataRowToChiTiet(DataRow row)
        {
            return new ChiTietPhieuDK
            {
                MaPhieuDK = row["MaPhieuDK"].ToString(),
                ThuTu = Convert.ToInt32(row["ThuTu"]),
                MaThiSinh = row["MaThiSinh"] != DBNull.Value ? row["MaThiSinh"].ToString() : null,
                MaLichThi = row["MaLichThi"].ToString(),
                SoBaoDanh = row["SoBaoDanh"] != DBNull.Value ? row["SoBaoDanh"].ToString() : null,
                TrangThaiCT = row["TrangThaiCT"].ToString(),
                Diem = row["Diem"] != DBNull.Value ? Convert.ToDecimal(row["Diem"]) : (decimal?)null,
                KetQua = row["KetQua"] != DBNull.Value ? row["KetQua"].ToString() : null,
                NgayCoKetQua = row["NgayCoKetQua"] != DBNull.Value ? Convert.ToDateTime(row["NgayCoKetQua"]) : (DateTime?)null,
                MaNV_NhapLieu = row["MaNV_NhapLieu"] != DBNull.Value ? row["MaNV_NhapLieu"].ToString() : null
            };
        }


        private List<ChiTietPhieuDK> MapDataTableToChiTietList(DataTable dt)
        {
            var list = new List<ChiTietPhieuDK>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapDataRowToChiTiet(row));
                }
            }
            return list;
        }
    }
}