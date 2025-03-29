using HotelProgram.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelProgram.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(User userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User] where username = @username and [password] = @password ";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null? false : true;
            }
            return validUser;
        }

        public void Edit(User userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            User user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User] where username = @username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader()) 
                {
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            Id = (int)reader["Id"],
                            Username = reader["Username"].ToString(),
                            Password = string.Empty, // Никогда не возвращайте пароли!
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString()

                        };
                    }
                }
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
