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
    /// Interaction logic for CEC.xaml
    /// </summary>
    public partial class CEC : Page
    {
        public CEC()
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
            observatiiIntrebare1.Text = string.Empty;
            notaIntrebare2.Text = string.Empty;
            observatiiIntrebare2.Text = string.Empty;
            notaIntrebare3.Text = string.Empty;
            observatiiIntrebare3.Text = string.Empty;
            notaIntrebare4.Text = string.Empty;
            observatiiIntrebare4.Text = string.Empty;
            notaIntrebare5.Text = string.Empty;
            observatiiIntrebare5.Text = string.Empty;
            notaIntrebare6.Text = string.Empty;
            observatiiIntrebare6.Text = string.Empty;
            notaIntrebare7.Text = string.Empty;
            observatiiIntrebare7.Text = string.Empty;
            notaIntrebare8.Text = string.Empty;
            observatiiIntrebare8.Text = string.Empty;
            notaIntrebare9.Text = string.Empty;
            observatiiIntrebare9.Text = string.Empty;
            notaIntrebare10.Text = string.Empty;
            observatiiIntrebare10.Text = string.Empty;
            observatiiIntrebare11.Text = string.Empty;
        }


        private void TrimiteEvaluarea_Click(object sender, RoutedEventArgs e)
        {
            if (emailAngajat.Text != string.Empty && emailSuperior.Text != string.Empty && numarClient.Text != string.Empty && dataApel.Text != string.Empty && tipApel.Text != string.Empty)
            {
                string connectionString = "server=192.168.100.18;port=3306;user=eoverart;password=P3CZV4pgc7jtT4z;database=asgard";
                string insertQuery = "INSERT INTO evaluari_cec VALUES (NULL, @email_agent, @email_evaluator, @numar_client, @data_apel, @tip_apel, @deschidere_apel_nota, @deschidere_apel_observatii, @gdpr_nota, @gdpr_observatii, @scop_apel_nota, @scop_apel_observatii, @captarea_informatiilor_nota, @captarea_informatiilor_observatii, @tratare_obiectii_nota, @tratare_obiectii_observatii, @finalizare_apel_nota, @finalizare_apel_observatii, @atitudine_nota, @atitudine_observatii, @aplicatii_nota, @aplicatii_observatii, @rezolutie_apel_nota, @rezolutie_apel_observatii, @business_nota, @business_observatii, @observatii, NULL)";


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
                            insertCommand.Parameters.AddWithValue("@deschidere_apel_nota", notaIntrebare1.Text);
                            insertCommand.Parameters.AddWithValue("@deschidere_apel_observatii", observatiiIntrebare1.Text);
                            insertCommand.Parameters.AddWithValue("@gdpr_nota", notaIntrebare2.Text);
                            insertCommand.Parameters.AddWithValue("@gdpr_observatii", observatiiIntrebare2.Text);
                            insertCommand.Parameters.AddWithValue("@scop_apel_nota", notaIntrebare3.Text);
                            insertCommand.Parameters.AddWithValue("@scop_apel_observatii", observatiiIntrebare3.Text);
                            insertCommand.Parameters.AddWithValue("@captarea_informatiilor_nota", notaIntrebare4.Text);
                            insertCommand.Parameters.AddWithValue("@captarea_informatiilor_observatii", observatiiIntrebare4.Text);
                            insertCommand.Parameters.AddWithValue("@tratare_obiectii_nota", notaIntrebare5.Text);
                            insertCommand.Parameters.AddWithValue("@tratare_obiectii_observatii", observatiiIntrebare5.Text);
                            insertCommand.Parameters.AddWithValue("@finalizare_apel_nota", notaIntrebare6.Text);
                            insertCommand.Parameters.AddWithValue("@finalizare_apel_observatii", observatiiIntrebare6.Text);
                            insertCommand.Parameters.AddWithValue("@atitudine_nota", notaIntrebare7.Text);
                            insertCommand.Parameters.AddWithValue("@atitudine_observatii", observatiiIntrebare7.Text);
                            insertCommand.Parameters.AddWithValue("@aplicatii_nota", notaIntrebare8.Text);
                            insertCommand.Parameters.AddWithValue("@aplicatii_observatii", observatiiIntrebare8.Text);
                            insertCommand.Parameters.AddWithValue("@rezolutie_apel_nota", notaIntrebare9.Text);
                            insertCommand.Parameters.AddWithValue("@rezolutie_apel_observatii", observatiiIntrebare9.Text);
                            insertCommand.Parameters.AddWithValue("@business_nota", notaIntrebare10.Text);
                            insertCommand.Parameters.AddWithValue("@business_observatii", observatiiIntrebare10.Text);
                            insertCommand.Parameters.AddWithValue("@observatii", observatiiIntrebare11.Text);

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
