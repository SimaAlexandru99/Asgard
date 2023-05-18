// <copyright file="RepositoryBase.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Repositories
{
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Media.Animation;
    using Asgard.CustomControls;
    using MySql.Data.MySqlClient;

    public class RepositoryBase
    {
        private static readonly string ConnectionString = "datasource=192.168.100.18;port=3306;username=eoverart;password=P3CZV4pgc7jtT4z;database=asgard";

        public static MySqlConnection GetConnectionPublic()
        {
            var connection = new MySqlConnection(ConnectionString);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (MySqlException ex)
            {
                // Show the dialog to inform the user that the connection is not available
                Notifications notifications = new Notifications();
                notifications.Loaded += (s, ea) =>
                {
                    // Get the SlideInAnimation storyboard from the window resources
                    Storyboard slideInAnimation = notifications.Resources["SlideInAnimation"] as Storyboard;
                    Console.WriteLine(ex.Message);

                    // Begin the animation
                    slideInAnimation.Begin();
                };

                notifications.ShowDialog();
            }

            return connection;
        }

        public static void AddOrder(Models.Comenzi order)
        {
            string sql = "INSERT INTO comenzi VALUES (NULL, @Agent, @Telefon, @Model, @Semnare, NULL)";
            MySqlConnection con = GetConnectionPublic();
            MySqlCommand cmd = new MySqlCommand(sql, con)
            {
                CommandType = CommandType.Text,
            };
            cmd.Parameters.Add("@Agent", MySqlDbType.VarChar).Value = order.Agent;
            cmd.Parameters.Add("@Telefon", MySqlDbType.VarChar).Value = order.Telefon;
            cmd.Parameters.Add("@Model", MySqlDbType.VarChar).Value = order.Model;
            cmd.Parameters.Add("@Semnare", MySqlDbType.VarChar).Value = order.Semnare;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Comanda nu a putut fi trimisa! \n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            con.Close();
        }

        protected MySqlConnection GetConnection()
        {
            var connection = new MySqlConnection(ConnectionString);
            return connection;
        }
    }
}
