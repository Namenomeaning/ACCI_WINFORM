using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;

namespace ACCI_WINFORM.DAO
{
    public class UuDaiDAO
    {
        public int ThemUuDai(UuDai uuDai)
        {
            string query = "INSERT INTO UuDai (TenUuDai, Loai, GiaTri, DieuKien, NgayBD, NgayKT, TrangThai) VALUES (@TenUuDai, @Loai, @GiaTri, @DieuKien, @NgayBD, @NgayKT, @TrangThai)";
            var parameters = MapUuDaiToParameters(uuDai);
            parameters = parameters.Where(p => p.ParameterName != "@MaUuDai").ToArray(); // Remove MaUuDai for INSERT
            // Assuming ExecuteNonQuery is preferable for INSERT/UPDATE/DELETE
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayUuDai(string maUuDai)
        {
            string query = "SELECT * FROM UuDai WHERE MaUuDai = @MaUuDai";
            var parameters = new[] { new MySqlParameter("@MaUuDai", maUuDai) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSUuDai()
        {
            string query = "SELECT * FROM UuDai";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatUuDai(UuDai uuDai)
        {
            string query = "UPDATE UuDai SET TenUuDai = @TenUuDai, Loai = @Loai, GiaTri = @GiaTri, DieuKien = @DieuKien, NgayBD = @NgayBD, NgayKT = @NgayKT, TrangThai = @TrangThai WHERE MaUuDai = @MaUuDai";
            var parameters = MapUuDaiToParameters(uuDai);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaUuDai(string maUuDai)
        {
            string query = "DELETE FROM UuDai WHERE MaUuDai = @MaUuDai";
            var parameters = new[] { new MySqlParameter("@MaUuDai", maUuDai) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // Helper to map UuDai object to parameters
        private MySqlParameter[] MapUuDaiToParameters(UuDai uuDai)
        {
            return new[]
           {
                new MySqlParameter("@MaUuDai", uuDai.MaUuDai), // Needed for update/delete check
                new MySqlParameter("@TenUuDai", uuDai.TenUuDai),
                new MySqlParameter("@Loai", uuDai.Loai),
                new MySqlParameter("@GiaTri", uuDai.GiaTri),
                new MySqlParameter("@DieuKien", uuDai.DieuKien),
                new MySqlParameter("@NgayBD", uuDai.NgayBD),
                new MySqlParameter("@NgayKT", uuDai.NgayKT),
                new MySqlParameter("@TrangThai", uuDai.TrangThai)
            };
        }
    }
}