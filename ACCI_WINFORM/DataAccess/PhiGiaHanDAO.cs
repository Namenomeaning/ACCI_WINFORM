using ACCI_WINFORM.Models;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using ACCI_WINFORM.Utils;

namespace ACCI_WINFORM.DataAccess
{
    public class PhiGiaHanDAO
    {
        public void ThemPhiGiaHan(PhiGiaHan phiGiaHan)
        {
            string query = "INSERT INTO PhiGiaHan (TenLoaiPhi, DonGia) VALUES (@TenLoaiPhi, @DonGia)";
            var parameters = new[]
            {
                new MySqlParameter("@TenLoaiPhi", phiGiaHan.TenLoaiPhi),
                new MySqlParameter("@DonGia", phiGiaHan.DonGia)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public PhiGiaHan LayPhiGiaHan(string maPhiGiaHan)
        {
            string query = "SELECT * FROM PhiGiaHan WHERE MaPhiGiaHan = @MaPhiGiaHan";
            var parameters = new[] { new MySqlParameter("@MaPhiGiaHan", maPhiGiaHan) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new PhiGiaHan
            {
                MaPhiGiaHan = row["MaPhiGiaHan"].ToString(),
                TenLoaiPhi = row["TenLoaiPhi"].ToString(),
                DonGia = Convert.ToDecimal(row["DonGia"])
            };
        }

        public List<PhiGiaHan> LayDSPhiGiaHan()
        {
            string query = "SELECT * FROM PhiGiaHan";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var phiGiaHanList = new List<PhiGiaHan>();

            foreach (DataRow row in result.Rows)
            {
                phiGiaHanList.Add(new PhiGiaHan
                {
                    MaPhiGiaHan = row["MaPhiGiaHan"].ToString(),
                    TenLoaiPhi = row["TenLoaiPhi"].ToString(),
                    DonGia = Convert.ToDecimal(row["DonGia"])
                });
            }
            return phiGiaHanList;
        }

        public void CapNhatPhiGiaHan(PhiGiaHan phiGiaHan)
        {
            string query = "UPDATE PhiGiaHan SET TenLoaiPhi = @TenLoaiPhi, DonGia = @DonGia WHERE MaPhiGiaHan = @MaPhiGiaHan";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhiGiaHan", phiGiaHan.MaPhiGiaHan),
                new MySqlParameter("@TenLoaiPhi", phiGiaHan.TenLoaiPhi),
                new MySqlParameter("@DonGia", phiGiaHan.DonGia)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaPhiGiaHan(string maPhiGiaHan)
        {
            string query = "DELETE FROM PhiGiaHan WHERE MaPhiGiaHan = @MaPhiGiaHan";
            var parameters = new[] { new MySqlParameter("@MaPhiGiaHan", maPhiGiaHan) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}