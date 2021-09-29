using InsuranceClaimsHandler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsHandler.Classes
{
    public class UserDbHandler
    {
        //green

        //can either take the remote or local, you get conflicts by having commits in both branches so only commit in one, git still needs work tho
        public UserModel ValidateUserInput(string username, string password)
        {
            DataTable dt = GetUserDetails(username);

            var user = new UserModel();

            if (dt.Rows.Count > 0)
            {
                user.UserName = dt.Rows[0]["UserName"].ToString();
                user.Password = dt.Rows[0]["Password"].ToString();
                user.DisplayName = dt.Rows[0]["DisplayName"].ToString();
                user.Active = (bool)dt.Rows[0]["Active"];

                if (user.UserName == username && user.Password == password && user.Active == true)
                {
                    user.DetailsCorrect = true;
                    return user;
                }
                else
                {
                    user.DetailsCorrect = false;
                    return user;
                }
            }

            return user;
        }
        private DataTable GetUserDetails(string username)
        {
            DataTable dt = new DataTable();

            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connectionString = $@"Server=interview-testing-server.database.windows.net; Database=Interview; User Id=TestLogin; Password=5D9ej2G64s3sd^;";
            sql = $"select * from Users where UserName = '{username}'";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                dt.Load(dataReader);
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection!");
            }

            return dt;
        }
    }
}
