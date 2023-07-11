using Asgard.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Asgard.Tickets.Evaluari
{
    /// <summary>
    /// Interaction logic for TKRM.xaml
    /// </summary>
    public partial class TKRM : Page
    {
        public TKRM()
        {
            InitializeComponent();
            var user = new MainViewModel();
            emailSuperior.Text = user.CurrentUserAccount.Email;
        }

        private void Clear()
        {
            emailAngajat.Text = string.Empty;
            emailSuperior.Text = string.Empty;
            numarClient.Text = string.Empty;
            dataApel.Text = string.Empty;
            tipApel.Text = string.Empty;
            notaIntrebare1.Text = string.Empty;
            notaIntrebare2.Text = string.Empty;
            notaIntrebare3.Text = string.Empty;
            notaIntrebare4.Text = string.Empty;
            notaIntrebare5.Text = string.Empty;
            notaIntrebare6.Text = string.Empty;
            notaIntrebare7.Text = string.Empty;
            notaIntrebare8.Text = string.Empty;
            notaIntrebare9.Text = string.Empty;
            notaIntrebare10.Text = string.Empty;
            notaIntrebare11.Text = string.Empty;
            notaIntrebare12.Text = string.Empty;
            notaIntrebare13.Text = string.Empty;
            notaIntrebare14.Text = string.Empty;
            notaIntrebare15.Text = string.Empty;
            notaIntrebare16.Text = string.Empty;
            notaIntrebare17.Text = string.Empty;
        }


        private void TrimiteEvaluarea_Click(object sender, RoutedEventArgs e)
        {
            if (emailAngajat.Text != string.Empty && emailSuperior.Text != string.Empty && numarClient.Text != string.Empty && dataApel.Text != string.Empty && tipApel.Text != string.Empty)
            {
                string connectionString = "server=192.168.100.18;port=3306;user=eoverart;password=P3CZV4pgc7jtT4z;database=asgard";
                string insertQuery = "INSERT INTO evaluari_tkrm VALUES (NULL, @email_agent, @email_evaluator, @numar_client, @data_apel, @tip_apel, @comunicare1, @comunicare2, @comunicare3, @comunicare4, @comunicare5, @comunicare6, @rezolvare1, @rezolvare2, @rezolvare3, @rezolvare4, @rezolvare5, @rezolvare6, @rezolvare7, @rezolvare8, @rezolvare9, @promovarea, @observatii_genarale,NULL)";


                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@email_agent", emailAngajat.Text);
                            insertCommand.Parameters.AddWithValue("@email_evaluator", emailSuperior.Text);
                            insertCommand.Parameters.AddWithValue("@numar_client", numarClient.Text);
                            insertCommand.Parameters.AddWithValue("@data_apel", dataApel.Text);
                            insertCommand.Parameters.AddWithValue("@tip_apel", tipApel.Text);

                            insertCommand.ExecuteNonQuery();
                        }

                        connection.Close();
                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Felicitări";
                            dialog.Status.Text = "Ai înregistrat o evaluare cu succes";
                            dialog.Descriere.Text = "Felicitari, evaluare ta a fost inregistrata cu succes \n Apasa butonul de mai jos pentru a introduce o alta evaluare.";
                        };
                        dialog.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while inserting data into the database: " + ex.Message);
                }

                Clear();
            }
            else
            {
                CustomControls.Prompt dialog = new CustomControls.Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "Evaluare nu a fost trimisa";
                    dialog.Descriere.Text = "Te rog sa verifici toate campurile, ai uitat sa completezi ceva.";
                };
                dialog.ShowDialog();
            }

        }

        private void tipApel_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }

    }
}
