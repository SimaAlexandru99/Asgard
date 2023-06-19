// <copyright file="EditAccount.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Pages
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Asgard.ViewModels;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Interaction logic for EditAccount.xaml.
    /// </summary>
    public partial class EditAccount : Page
    {
        private readonly MainViewModel user;

        public EditAccount()
        {
            InitializeComponent();
            user = new MainViewModel();

            EmailTextbox.Text = user.CurrentUserAccount.Email.ToString();
            NumeTextbox.Text = user.CurrentUserAccount.Name.ToString();
            PrenumeTextbox.Text = user.CurrentUserAccount.LastName.ToString();
            IdBriaTextbox.Text = user.CurrentUserAccount.ID_Bria.ToString();
            UsernameTextbox.Text = user.CurrentUserAccount.Username.ToString();
            ProiectTextBox.Text = user.CurrentUserAccount.Proiect.ToString();
            SubProiectTextBox.Text = user.CurrentUserAccount.Subproiect.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = new MainViewModel();
            string email = EmailTextbox.Text;
            string nume = NumeTextbox.Text;
            string prenume = PrenumeTextbox.Text;
            string password = PasswordBox.Text;
            string idBria = IdBriaTextbox.Text;
            string username = user.CurrentUserAccount.Username.ToString();

            string connectionString = "Server=192.168.100.18;Port=3306;Database=asgard;Uid=eoverart;Pwd=P3CZV4pgc7jtT4z;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE users SET Email=@email, Nume=@nume, Prenume=@prenume, Password=@password, ID_Bria=@idbria WHERE Username=@username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add the user's email as a parameter to the query
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@nume", nume);
                        command.Parameters.AddWithValue("@prenume", prenume);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@idbria", idBria);
                        command.Parameters.AddWithValue("@username", username);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Display an error dialog with the exception message
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                connection.Close();
            }

            CustomControls.Prompt dialog = new CustomControls.Prompt();
            dialog.Loaded += (s, ea) =>
            {
                dialog.Title = "Succes";
                dialog.Status.Text = "Datele au fost salvate cu succes";
                dialog.Descriere.Text = "Am actualizat toate datele introduse de tine";
            };
            dialog.ShowDialog();
        }
    }
}
