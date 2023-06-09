﻿// <copyright file="UserRepository.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows;
    using Asgard.Models;
    using MySql.Data.MySqlClient;

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
                    command.CommandText = "SELECT COUNT(*) FROM users WHERE Username = @Username AND Password = @Password";
                    command.Parameters.AddWithValue("@Username", credential.UserName);
                    command.Parameters.AddWithValue("@Password", credential.Password);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    validUser = count > 0;
                }
                catch (MySqlException)
                {
                    // Show error message in a dialog box
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Nu te-am putut loga";
                        dialog.Descriere.Text = "Nu te-am putut conecta in Asgard, verifică conexiunea la internet și datele de logare.";
                    };
                    dialog.ShowDialog();

                    // Re-throw the exception to propagate it further if needed
                    throw;
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
                command.CommandText = "SELECT * FROM users WHERE Username = @Username";
                command.Parameters.AddWithValue("@Username", username);
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
                            Departament = reader.GetString(8),
                            TeamlLeader = reader.GetString(9),
                            Quality = reader.GetString(10),
                            ID_Bria = reader.GetString(11),
                            Status = reader.GetString(12),
                            Password = string.Empty,
                        };
                    }
                }

                if (user != null)
                {
                    command.CommandText = "UPDATE users SET Status = 'Online' WHERE Username = @Username";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.ExecuteNonQuery();
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