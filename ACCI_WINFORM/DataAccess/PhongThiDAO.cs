using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class PhongThiDAO
    {
        public void ThemPhongThi(PhongThi phongThi)
        {
            string query = "INSERT INTO PhongThi (TenPhong, SucChua) VALUES (@TenPhong, @SucChua)";
            var parameters = new[]
            {
                new MySqlParameter("@TenPhong", phongThi.TenPhong),
                new MySqlParameter("@SucChua", phongThi.SucChua)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public PhongThi LayPhongThi(string maPhongThi)
        {
            string query = "SELECT * FROM PhongThi WHERE MaPhongThi = @MaPhongThi";
            var parameters = new[] { new MySqlParameter("@MaPhongThi", maPhongThi) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new PhongThi
            {
                MaPhongThi = row["MaPhongThi"].ToString(),
                TenPhong = row["TenPhong"].ToString(),
                SucChua = Convert.ToInt32(row["SucChua"])
            };
        }

        public List<PhongThi> LayDSPhongThi()
        {
            string query = "SELECT * FROM PhongThi";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var phongThiList = new List<PhongThi>();

            foreach (DataRow row in result.Rows)
            {
                phongThiList.Add(new PhongThi
                {
                    MaPhongThi = row["MaPhongThi"].ToString(),
                    TenPhong = row["TenPhong"].ToString(),
                    SucChua = Convert.ToInt32(row["SucChua"])
                });
            }
            return phongThiList;
        }

        public void CapNhatPhongThi(PhongThi phongThi)
        {
            string query = "UPDATE PhongThi SET TenPhong = @TenPhong, SucChua = @SucChua WHERE MaPhongThi = @MaPhongThi";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhongThi", phongThi.MaPhongThi),
                new MySqlParameter("@TenPhong", phongThi.TenPhong),
                new MySqlParameter("@SucChua", phongThi.SucChua)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaPhongThi(string maPhongThi)
        {
            string query = "DELETE FROM PhongThi WHERE MaPhongThi = @MaPhongThi";
            var parameters = new[] { new MySqlParameter("@MaPhongThi", maPhongThi) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}