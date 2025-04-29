using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class UuDaiDAO
    {
        public void ThemUuDai(UuDai uuDai)
        {
            string query = "INSERT INTO UuDai (TenUuDai, Loai, GiaTri, DieuKien, NgayBD, NgayKT, TrangThai) VALUES (@TenUuDai, @Loai, @GiaTri, @DieuKien, @NgayBD, @NgayKT, @TrangThai)";
            var parameters = new[]
            {
                new MySqlParameter("@TenUuDai", uuDai.TenUuDai),
                new MySqlParameter("@Loai", uuDai.Loai),
                new MySqlParameter("@GiaTri", uuDai.GiaTri),
                new MySqlParameter("@DieuKien", uuDai.DieuKien),
                new MySqlParameter("@NgayBD", uuDai.NgayBD),
                new MySqlParameter("@NgayKT", uuDai.NgayKT),
                new MySqlParameter("@TrangThai", uuDai.TrangThai)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public UuDai LayUuDai(string maUuDai)
        {
            string query = "SELECT * FROM UuDai WHERE MaUuDai = @MaUuDai";
            var parameters = new[] { new MySqlParameter("@MaUuDai", maUuDai) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new UuDai
            {
                MaUuDai = row["MaUuDai"].ToString(),
                TenUuDai = row["TenUuDai"].ToString(),
                Loai = row["Loai"].ToString(),
                GiaTri = Convert.ToDecimal(row["GiaTri"]),
                DieuKien = row["DieuKien"].ToString(),
                NgayBD = Convert.ToDateTime(row["NgayBD"]),
                NgayKT = Convert.ToDateTime(row["NgayKT"]),
                TrangThai = row["TrangThai"].ToString()
            };
        }

        public List<UuDai> LayDSUuDai()
        {
            string query = "SELECT * FROM UuDai";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var uuDaiList = new List<UuDai>();

            foreach (DataRow row in result.Rows)
            {
                uuDaiList.Add(new UuDai
                {
                    MaUuDai = row["MaUuDai"].ToString(),
                    TenUuDai = row["TenUuDai"].ToString(),
                    Loai = row["Loai"].ToString(),
                    GiaTri = Convert.ToDecimal(row["GiaTri"]),
                    DieuKien = row["DieuKien"].ToString(),
                    NgayBD = Convert.ToDateTime(row["NgayBD"]),
                    NgayKT = Convert.ToDateTime(row["NgayKT"]),
                    TrangThai = row["TrangThai"].ToString()
                });
            }
            return uuDaiList;
        }

        public void CapNhatUuDai(UuDai uuDai)
        {
            string query = "UPDATE UuDai SET TenUuDai = @TenUuDai, Loai = @Loai, GiaTri = @GiaTri, DieuKien = @DieuKien, NgayBD = @NgayBD, NgayKT = @NgayKT, TrangThai = @TrangThai WHERE MaUuDai = @MaUuDai";
            var parameters = new[]
            {
                new MySqlParameter("@MaUuDai", uuDai.MaUuDai),
                new MySqlParameter("@TenUuDai", uuDai.TenUuDai),
                new MySqlParameter("@Loai", uuDai.Loai),
                new MySqlParameter("@GiaTri", uuDai.GiaTri),
                new MySqlParameter("@DieuKien", uuDai.DieuKien),
                new MySqlParameter("@NgayBD", uuDai.NgayBD),
                new MySqlParameter("@NgayKT", uuDai.NgayKT),
                new MySqlParameter("@TrangThai", uuDai.TrangThai)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaUuDai(string maUuDai)
        {
            string query = "DELETE FROM UuDai WHERE MaUuDai = @MaUuDai";
            var parameters = new[] { new MySqlParameter("@MaUuDai", maUuDai) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}