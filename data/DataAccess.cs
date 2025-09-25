using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace data
{
    public static class DataAccess
    {
        // Change this to your actual connection string
        private static readonly string ConnectionString = "Data Source=ADMIN-PC-26\\SQLEXPRESS;Initial Catalog=hospitalDB;Integrated Security=True;Encrypt=False;";


        public static DataTable GetDataTable(string sql, Dictionary<string, object> parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public static int ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, Dictionary<string, object> parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
