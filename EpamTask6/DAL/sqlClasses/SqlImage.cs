using DALInterfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL.sqlClasses
{
    public class SqlImage<T> : IData<T> where T : Image
    {
        private string tableName;
        private string ConnectionString;
        private string SqlCommand;

        public SqlImage(string TableName)
        {
            tableName = TableName;
            ConnectionString = ConfigurationManager.ConnectionStrings["epamTask11DB"].ConnectionString;
        }

        public void AddData(T data)
        {
            SqlCommand = $"INSERT INTO {tableName}(url, IsDefault) values ( '{data.Path}', 0)";
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                command.ExecuteNonQuery();      
            }
        }

        public void Delete(int Id)
        {
            SqlCommand = $"DELETE FROM {tableName}  WHERE Id={Id}";
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                command.ExecuteNonQuery();
            }
        }

        public void Edit(T Edited)
        {
            SqlCommand = $"UPDATE {tableName} SET url = '{Edited.Path}' WHERE Id={Edited.Id}";
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<T> GetAll()
        {
            SqlCommand = $"SELECT * FROM {tableName}";
            var result = new List<T>();
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var img = new Image
                        {
                            Id = (int)reader["Id"],
                            Path = reader["url"].ToString(),
                            IsDefault = Convert.ToBoolean(reader["IsDefault"])
                        };
                        result.Add((T)img);
                    }
                }
            }
            return result;
        }
    }
}