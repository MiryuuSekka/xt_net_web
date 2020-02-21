using DALInterfaces;
using Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL.sqlClasses
{
    public class SqlWeilder<T> : IData<T> where T : AwardWeilder
    {
        private string tableName;
        private string ConnectionString;
        private string SqlCommand;

        public SqlWeilder(string TableName)
        {
            tableName = TableName;
            ConnectionString = ConfigurationManager.ConnectionStrings["epamTask11DB"].ConnectionString;
        }

        public void AddData(T data)
        {
            SqlCommand = $"INSERT INTO {tableName}(Id_Award, Id_User) values ( {data.AwardId}, {data.UserId})";
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
            SqlCommand = $"UPDATE {tableName} SET Id_Award = {Edited.AwardId}, ";
            SqlCommand += $"Id_User = {Edited.UserId} WHERE Id={Edited.Id}";
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
                        var weilder = new AwardWeilder
                        {
                            AwardId = (int)reader["Id_Award"],
                            UserId = (int)reader["Id_User"],
                            Id = (int)reader["Id"]
                        };
                        result.Add((T)weilder);
                    }
                }
            }
            return result;
        }
    }
}