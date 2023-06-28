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
using Asgard.ViewModels;
using MySql.Data.MySqlClient;

namespace Asgard.Tickets.Evaluari
{
    /// <summary>
    /// Interaction logic for OROC2023.xaml
    /// </summary>
    public partial class OROC2023 : Page
    {
        public OROC2023()
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
            clientCuFibra.Text = string.Empty;
            produsulDePeCerere.Text = string.Empty;
            respectaProcesulDeRetentie.Text = string.Empty;
            informatiileMandatorii.Text = string.Empty;
            produseRetentie.Text = string.Empty;
            ComboProiect.Text = string.Empty;
            dataApel.Text = string.Empty;
            ComboTipApel.Text = string.Empty;
            ComboMotivApel.Text = string.Empty;
            ComboMotivDesfintare.Text = string.Empty;
            notaIntrebare1.Text = string.Empty;
            observatiiIntrebare1.Text = string.Empty;
            notaIntrebare2.Text = string.Empty;
            observatiiIntrebare2.Text = string.Empty;
            notaIntrebare3.Text = string.Empty;
            observatiiIntrebare3.Text = string.Empty;
            notaIntrebare4.Text = string.Empty;
            observatiiIntrebare4.Text= string.Empty;
            notaIntrebare5.Text = string.Empty;
            observatiiIntrebare5.Text = string.Empty;
            notaIntrebare6.Text = string.Empty;
            observatiiIntrebare6.Text = string.Empty;
            notaIntrebare7.Text = string.Empty;
            observatiiIntrebare7.Text= string.Empty;
            notaIntrebare8.Text = string.Empty;
            observatiiIntrebare8.Text= string.Empty;
            notaIntrebare9.Text = string.Empty;
            observatiiIntrebare9.Text= string.Empty;
            notaIntrebare10.Text = string.Empty;
            observatiiIntrebare10.Text= string.Empty;
            notaIntrebare11.Text = string.Empty;
            observatiiIntrebare11.Text= string.Empty;
            observatiiIntrebare12.Text= string.Empty;
        }
        

        private void TrimiteEvaluarea_Click(object sender, RoutedEventArgs e)
        {
            if(emailAngajat.Text != string.Empty && emailSuperior.Text != string.Empty && numarClient.Text != string.Empty && ComboProiect.Text != string.Empty && dataApel.Text != string.Empty)
            {
                string connectionString = "server=192.168.100.18;port=3306;user=eoverart;password=P3CZV4pgc7jtT4z;database=asgard";
                string insertQuery = "INSERT INTO evaluari_oroc2023 VALUES (NULL, @email_agent, @email_superior, @numar_client, @client_cu_fibra, @produsul_de_pe_cerere, @respecta_procesul_de_retentie, @informatiile_mandatorii, @produse_retentie, @proiect, @data_apel, @tip_apel, @motiv_apel, @motiv_desfintare, @nota_intrebare1, @observatii_intrebare1, @nota_intrebare2, @observatii_intrebare2, @nota_intrebare3, @observatii_intrebare3, @nota_intrebare4, @observatii_intrebare4, @nota_intrebare5, @observatii_intrebare5, @nota_intrebare6, @observatii_intrebare6, @nota_intrebare7, @observatii_intrebare7, @nota_intrebare8, @observatii_intrebare8, @nota_intrebare9, @observatii_intrebare9, @nota_intrebare10, @observatii_intrebare10, @nota_intrebare11, @observatii_intrebare11, @observatii_intrebare12, NULL)";


                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@email_agent", emailAngajat.Text);
                            insertCommand.Parameters.AddWithValue("@email_superior", emailSuperior.Text);
                            insertCommand.Parameters.AddWithValue("@numar_client", numarClient.Text);
                            insertCommand.Parameters.AddWithValue("@client_cu_fibra", clientCuFibra.Text);
                            insertCommand.Parameters.AddWithValue("@produsul_de_pe_cerere", produsulDePeCerere.Text);
                            insertCommand.Parameters.AddWithValue("@respecta_procesul_de_retentie", respectaProcesulDeRetentie.Text);
                            insertCommand.Parameters.AddWithValue("@informatiile_mandatorii", informatiileMandatorii.Text);
                            insertCommand.Parameters.AddWithValue("@produse_retentie", produseRetentie.Text);
                            insertCommand.Parameters.AddWithValue("@proiect", ComboProiect.Text);
                            insertCommand.Parameters.AddWithValue("@data_apel", dataApel.Text);
                            insertCommand.Parameters.AddWithValue("@tip_apel", ComboTipApel.Text);
                            insertCommand.Parameters.AddWithValue("@motiv_apel", ComboMotivApel.Text);
                            insertCommand.Parameters.AddWithValue("@motiv_desfintare", ComboMotivDesfintare.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare1", notaIntrebare1.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare1", observatiiIntrebare1.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare2", notaIntrebare2.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare2", observatiiIntrebare2.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare3", notaIntrebare3.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare3", observatiiIntrebare3.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare4", notaIntrebare4.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare4", observatiiIntrebare4.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare5", notaIntrebare5.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare5", observatiiIntrebare5.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare6", notaIntrebare6.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare6", observatiiIntrebare6.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare7", notaIntrebare7.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare7", observatiiIntrebare7.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare8", notaIntrebare8.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare8", observatiiIntrebare8.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare9", notaIntrebare9.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare9", observatiiIntrebare9.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare10", notaIntrebare10.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare10", observatiiIntrebare10.Text);
                            insertCommand.Parameters.AddWithValue("@nota_intrebare11", notaIntrebare11.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare11", observatiiIntrebare11.Text);
                            insertCommand.Parameters.AddWithValue("@observatii_intrebare12", observatiiIntrebare12.Text);

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
        
        private void ComboProiect_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }
    }
}
