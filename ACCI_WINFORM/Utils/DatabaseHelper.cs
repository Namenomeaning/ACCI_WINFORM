using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ACCI_WINFORM.Utils
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Server=localhost;Port=33306;Database=ACCI;User=root;Password=root;";

        private static MySqlConnection CreateAndOpenConnection()
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private static void CloseConnection(MySqlConnection connection)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            MySqlConnection connection = null;

            try
            {
                connection = CreateAndOpenConnection();
                using var command = new MySqlCommand(query, connection);
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                using var adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi truy vấn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection(connection);
            }

            return dataTable;
        }

        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            MySqlConnection connection = null;
            int rowsAffected = 0;

            try
            {
                connection = CreateAndOpenConnection();
                using var command = new MySqlCommand(query, connection);
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi lệnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection(connection);
            }

            return rowsAffected;
        }

        // New method to execute transactional operations and return results
        public static bool ExecuteTransaction<T>(Func<MySqlConnection, MySqlTransaction, T> operations, out T result)
        {
            MySqlConnection connection = null;
            MySqlTransaction transaction = null;
            result = default;

            try
            {
                connection = CreateAndOpenConnection();
                transaction = connection.BeginTransaction();

                // Execute the operations and capture the result
                result = operations(connection, transaction);

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Lỗi khi thực thi giao dịch: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = default;
                return false;
            }
            finally
            {
                CloseConnection(connection);
            }
        }
    }
}