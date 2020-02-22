using DALInterfaces;
using Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL.sqlClasses
{
    public class SqlAward<T> : IData<T> where T : Award
    {
        private string tableName;
        private string ConnectionString;
        private string SqlCommand;

        public SqlAward(string TableName)
        {
            tableName = TableName;
            ConnectionString = ConfigurationManager.ConnectionStrings["epamTask11DB"].ConnectionString;
        }

        public void AddData(T data)
        {
            SqlCommand = $"INSERT INTO {tableName}(Title) values ('{data.Title}')";
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                command.ExecuteNonQuery();      //command.ExecuteScalar();  //can return id of added data?
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
            SqlCommand = $"UPDATE {tableName} SET Title = '{Edited.Title}', id_image = {Edited.Icon.Id} WHERE Id={Edited.Id}";
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
            int? imgId;
            var img = new Image();
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var award = new Award
                        {
                            Title = reader["Title"].ToString(),
                            Id = (int)reader["Id"]
                        };
                        img = new Image();
                        imgId = reader["id_image"] as int?; 
                        if (imgId.HasValue)
                        {
                            img.Id = imgId.Value;
                        }
                        award.Icon = img;
                        result.Add((T)award);
                    }
                }
            }
            return result;
        }
    }
}
