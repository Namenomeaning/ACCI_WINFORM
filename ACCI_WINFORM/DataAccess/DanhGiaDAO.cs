using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class DanhGiaDAO
    {
        public void ThemDanhGia(DanhGia danhGia)
        {
            string query = "INSERT INTO DanhGia (TenDanhGia, MoTa, DonGia) VALUES (@TenDanhGia, @MoTa, @DonGia)";
            var parameters = new[]
            {
                new MySqlParameter("@TenDanhGia", danhGia.TenDanhGia),
                new MySqlParameter("@MoTa", danhGia.MoTa ?? (object)DBNull.Value),
                new MySqlParameter("@DonGia", danhGia.DonGia)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DanhGia LayDanhGia(string maDanhGia)
        {
            string query = "SELECT * FROM DanhGia WHERE MaDanhGia = @MaDanhGia";
            var parameters = new[] { new MySqlParameter("@MaDanhGia", maDanhGia) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new DanhGia
            {
                MaDanhGia = row["MaDanhGia"].ToString(),
                TenDanhGia = row["TenDanhGia"].ToString(),
                MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                DonGia = Convert.ToDecimal(row["DonGia"])
            };
        }

        public List<DanhGia> LayDSDanhGia()
        {
            string query = "SELECT * FROM DanhGia";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var danhGiaList = new List<DanhGia>();

            foreach (DataRow row in result.Rows)
            {
                danhGiaList.Add(new DanhGia
                {
                    MaDanhGia = row["MaDanhGia"].ToString(),
                    TenDanhGia = row["TenDanhGia"].ToString(),
                    MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                    DonGia = Convert.ToDecimal(row["DonGia"])
                });
            }
            return danhGiaList;
        }

        public void CapNhatDanhGia(DanhGia danhGia)
        {
            string query = "UPDATE DanhGia SET TenDanhGia = @TenDanhGia, MoTa = @MoTa, DonGia = @DonGia WHERE MaDanhGia = @MaDanhGia";
            var parameters = new[]
            {
                new MySqlParameter("@MaDanhGia", danhGia.MaDanhGia),
                new MySqlParameter("@TenDanhGia", danhGia.TenDanhGia),
                new MySqlParameter("@MoTa", danhGia.MoTa ?? (object)DBNull.Value),
                new MySqlParameter("@DonGia", danhGia.DonGia)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaDanhGia(string maDanhGia)
        {
            string query = "DELETE FROM DanhGia WHERE MaDanhGia = @MaDanhGia";
            var parameters = new[] { new MySqlParameter("@MaDanhGia", maDanhGia) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}