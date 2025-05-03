using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System.Data;
using System.Linq;

namespace ACCI_WINFORM.DAO
{
    public class PhongThiDAO
    {
        public int ThemPhongThi(PhongThi phongThi)
        {
            string query = "INSERT INTO PhongThi (TenPhong, SucChua) VALUES (@TenPhong, @SucChua)";
            var parameters = MapPhongThiToParameters(phongThi);
            parameters = parameters.Where(p => p.ParameterName != "@MaPhongThi").ToArray(); // Remove ID for insert
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayPhongThi(string maPhongThi)
        {
            string query = "SELECT * FROM PhongThi WHERE MaPhongThi = @MaPhongThi";
            var parameters = new[] { new MySqlParameter("@MaPhongThi", maPhongThi) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSPhongThi()
        {
            string query = "SELECT * FROM PhongThi";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatPhongThi(PhongThi phongThi)
        {
            string query = "UPDATE PhongThi SET TenPhong = @TenPhong, SucChua = @SucChua WHERE MaPhongThi = @MaPhongThi";
            var parameters = MapPhongThiToParameters(phongThi);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaPhongThi(string maPhongThi)
        {
            // Consider checking if room is used in future LichThi before allowing deletion
            string query = "DELETE FROM PhongThi WHERE MaPhongThi = @MaPhongThi";
            var parameters = new[] { new MySqlParameter("@MaPhongThi", maPhongThi) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // Helper to map object to parameters
        private MySqlParameter[] MapPhongThiToParameters(PhongThi phongThi)
        {
            return new[]
           {
                new MySqlParameter("@MaPhongThi", phongThi.MaPhongThi), // Needed for update/delete
                new MySqlParameter("@TenPhong", phongThi.TenPhong),
                new MySqlParameter("@SucChua", phongThi.SucChua)
            };
        }
    }
}