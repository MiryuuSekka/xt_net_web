using DALInterfaces;
using Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL.sqlClasses
{
    public class SqlWebUser<T> : IData<T> where T : WebUser
    {
        private string tableName;
        private string ConnectionString;
        private string SqlCommand;

        public SqlWebUser(string TableName)
        {
            tableName = TableName;
            ConnectionString = ConfigurationManager.ConnectionStrings["epamTask11DB"].ConnectionString;
        }

        public void AddData(T data)
        {
            SqlCommand = $"INSERT INTO {tableName}(Password, Username, id_Role) values ( '{data.Password}','{data.Username}', {data.Role.Id})";
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
            SqlCommand = $"UPDATE {tableName} SET Username = '{Edited.Username}', id_Role = {Edited.Role.Id}, ";
            SqlCommand += $"Password = '{Edited.Password}' WHERE Id={Edited.Id}";
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
            var role = new Role();
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new WebUser
                        {
                            Id = (int)reader["Id"],
                            Password = reader["Password"].ToString(),
                            Username = reader["Username"].ToString()
                        };
                        role = new Role();
                        role.Id = (int)reader["id_Role"];
                        user.Role = role;
                        result.Add((T)user);
                    }
                }
            }
            return result;
        }
    }
}
