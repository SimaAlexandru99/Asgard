using Asgard.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace Asgard.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select *from users where Username=@Username and Password=@Password";
                    command.Parameters.Add("@Username", MySqlDbType.VarChar).Value = credential.UserName;
                    command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = credential.Password;
                    validUser =
                        command.ExecuteScalar() != null;
                }
                catch (MySqlException ex)
                {
                    // Handle MySQL exception
                    MessageBox.Show($"Failed to execute database command: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    validUser = false; // Set the result to false
                }
                catch (Exception ex)
                {
                    // Handle general exception
                    MessageBox.Show($"Failed to execute database command: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    validUser = false; // Set the result to false
                }
            }
            return validUser;
        }

        public Task AuthenticateUserAsync(NetworkCredential networkCredential) => throw new NotImplementedException();

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM users WHERE Username=@Username";
                command.Parameters.Add("@Username", MySqlDbType.VarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        user = new UserModel()
                        {
                            Id = reader.GetString(0),
                            Username = reader.GetString(1),
                            Email = reader.GetString(2),
                            Name = reader.GetString(3),
                            LastName = reader.GetString(4),
                            Proiect = reader.GetString(6),
                            Subproiect = reader.GetString(7),
                            TeamlLeader = reader.GetString(8),
                            Quality = reader.GetString(9),
                            ID_Bria = reader.GetString(10),
                            Status = reader.GetString(11),
                            Password = string.Empty



                        };

                        connection.Close();
                        connection.Open();
                        command.CommandText = "UPDATE users SET Status='Online' WHERE Username='" + user.Username + "';";
                        command.ExecuteNonQuery();
                        connection.Close();
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