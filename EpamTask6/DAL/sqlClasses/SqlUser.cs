using DALInterfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL.sqlClasses
{
    public class SqlUser<T> : IData<T> where T : User
    {
        private string tableName;
        private string ConnectionString;
        private string SqlCommand;

        public SqlUser(string TableName)
        {
            tableName = TableName;
            ConnectionString = ConfigurationManager.ConnectionStrings["epamTask11DB"].ConnectionString;
        }

        public void AddData(T data)
        {
            SqlCommand = $"INSERT INTO {tableName}(Name, Age, Birthday) values ( '{data.Name}', {data.Age}, '{data.BirthDay.ToString("dd.MM.yyyy")}')";
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
            SqlCommand = $"UPDATE {tableName} ";
            SqlCommand += $"SET Name = '{Edited.Name}', Age = {Edited.Age}, ";
            SqlCommand += $"Birthday = '{Edited.BirthDay.ToString("dd.MM.yyyy")}', ";
            SqlCommand += $"id_image = {Edited.Icon.Id} WHERE Id={Edited.Id}";

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
                        var user = new User
                        {
                            Age = (int)reader["Age"],
                            Name = reader["Name"].ToString(),
                            BirthDay = (DateTime)reader["Birthday"],
                            Id = (int)reader["Id"]
                        };
                        img = new Image();
                        imgId = reader["id_image"] as int?;
                        if (imgId.HasValue)
                        {
                            img.Id = imgId.Value;
                        }
                        user.Icon = img;

                        result.Add((T)user);
                    }
                }
            }
            return result;
        }
    }
}
