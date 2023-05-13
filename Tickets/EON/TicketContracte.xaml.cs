using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Asgard.Tickets.EON
{
    /// <summary>
    /// Interaction logic for TicketContracte.xaml
    /// </summary>
    public partial class TicketContracte : Page
    {
        public TicketContracte()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Load the PDF file
            // Code to open PDFAssets/Contracte EON/Actual_Assist_Electric.pdf"

            string IDContractSave4 = null;
            string IDContractBun = null;

            string connectionString = "server=192.168.100.18;port=3306;user=eoverart;password=P3CZV4pgc7jtT4z;database=asgard";
            string selectQuery = "SELECT ID FROM contracte_eon ORDER BY ID DESC LIMIT 1";
            string insertQuery = "INSERT INTO contracte_eon (ID, CNP) VALUES (@ID, @CNP)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                {
                    int IDContract = Convert.ToInt32(command.ExecuteScalar());
                    int IDContractNoi = IDContract + 1;
                    IDContractBun = IDContractNoi.ToString();

                    IDContractSave4 = IDContractBun;

                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@ID", IDContractNoi);
                        insertCommand.Parameters.AddWithValue("@CNP", CNP.Text);
                        insertCommand.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }

            if (comboboxContract.Text == "Actual Assist Electric")
            {


                string fileName = "Assets/Contracte EON/Actual_Assist_Electric.pdf";
                PdfReader pdfReader = new PdfReader(fileName);
                /*            string fileSave = "Assets/Contracte EON/Generat/";*/

                // Code to save PDF with a modified name
                string newFileName = Path.Combine(Path.GetDirectoryName(fileName), $"{IDContractSave4}.pdf");
                FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);

                // Code to modify PDF fields
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
                AcroFields acroFields = pdfStamper.AcroFields;
                acroFields.SetField("Nume", NumeClient.Text); // Assuming "UserName" is the field name in the PDF
                acroFields.SetField("Prenume", PrenumeClient.Text);
                acroFields.SetField("Adresa", AdresaClient.Text);
                acroFields.SetField("CNP", CNP.Text);
                acroFields.SetField("Serie", Serie.Text);
                acroFields.SetField("Email", Email.Text);
                acroFields.SetField("Telefon", Telefon.Text);
                acroFields.SetField("IBAN", IBAN.Text);
                acroFields.SetField("Banca", Banca.Text);
                acroFields.SetField("AdresaCorespondenta", AdresaCorespondenta.Text);
                if (comboboxFormat.Text == "Electronic")
                {
                    acroFields.SetField("checkboxElectronic", "On");
                }
                else if (comboboxFormat.Text == "Tipărit")
                {
                    acroFields.SetField("checkboxTiparit", "On");
                }
                acroFields.SetField("CodClient", CodClient.Text);
                acroFields.SetField("AdresaLocConsum", AdresaLocConsum.Text);
                acroFields.SetField("ValabilitateActSpatiu", ValabilitateActSpatiu.Text);
                acroFields.SetField("CLC", CLC.Text);
                acroFields.SetField("POD", POD.Text);
                acroFields.SetField("Nivel tensiune", NivelTensiune.Text);
                acroFields.SetField("Nume Prenume", NumeClient.Text + " " + PrenumeClient.Text);
                acroFields.SetField("DataImplementare", DataImplementare.Text);
                acroFields.SetField("ConsumAnualPrognozat", ConsumAnualPrognozat.Text);
                acroFields.SetField("Data_semnari", DataSemnare.Text);
                acroFields.SetField("IDContract", IDContractBun);

                pdfStamper.Close();


                // Show message box to confirm that PDF was saved
                MessageBox.Show("PDF salvat.");

                // Code to open the saved PDF file
                Process.Start(newFileName);
            }
            else if (comboboxContract.Text == "Actual Electric")
            {


                string fileName = "Assets/Contracte EON/Actual_Electric.pdf";
                PdfReader pdfReader = new PdfReader(fileName);
                /*            string fileSave = "Assets/Contracte EON/Generat/";*/

                // Code to save PDF with a modified name
                string newFileName = Path.Combine(Path.GetDirectoryName(fileName), $"{IDContractSave4}.pdf");
                FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);

                // Code to modify PDF fields
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
                AcroFields acroFields = pdfStamper.AcroFields;
                acroFields.SetField("Nume", NumeClient.Text); // Assuming "UserName" is the field name in the PDF
                acroFields.SetField("Prenume", PrenumeClient.Text);
                acroFields.SetField("Adresa", AdresaClient.Text);
                acroFields.SetField("CNP", CNP.Text);
                acroFields.SetField("Serie", Serie.Text);
                acroFields.SetField("Email", Email.Text);
                acroFields.SetField("Telefon", Telefon.Text);
                acroFields.SetField("IBAN", IBAN.Text);
                acroFields.SetField("Banca", Banca.Text);
                acroFields.SetField("AdresaCorespondenta", AdresaCorespondenta.Text);
                if (comboboxFormat.Text == "Electronic")
                {
                    acroFields.SetField("checkboxElectronic", "On");
                }
                else if (comboboxFormat.Text == "Tipărit")
                {
                    acroFields.SetField("checkboxTiparit", "On");
                }
                acroFields.SetField("CodClient", CodClient.Text);
                acroFields.SetField("AdresaLocConsum", AdresaLocConsum.Text);
                acroFields.SetField("ValabilitateActSpatiu", ValabilitateActSpatiu.Text);
                acroFields.SetField("CLC", CLC.Text);
                acroFields.SetField("POD", POD.Text);
                acroFields.SetField("Nivel tensiune", NivelTensiune.Text);
                acroFields.SetField("Nume Prenume", NumeClient.Text + " " + PrenumeClient.Text);
                acroFields.SetField("DataImplementare", DataImplementare.Text);
                acroFields.SetField("ConsumAnualPrognozat", ConsumAnualPrognozat.Text);
                acroFields.SetField("Data_semnari", DataSemnare.Text);
                acroFields.SetField("IDContract", IDContractBun);


                pdfStamper.Close();


                // Show message box to confirm that PDF was saved
                MessageBox.Show("PDF salvat.");

                // Code to open the saved PDF file
                Process.Start(newFileName);
            }

            else if (comboboxContract.Text == "Actual Assist Gaz")
            {

                string fileName = "Assets/Contracte EON/Actual_Assist_Gas.pdf";
                PdfReader pdfReader = new PdfReader(fileName);
                /*            string fileSave = "Assets/Contracte EON/Generat/";*/

                // Code to save PDF with a modified name
                string newFileName = Path.Combine(Path.GetDirectoryName(fileName), $"{IDContractSave4}.pdf");
                FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);

                // Code to modify PDF fields
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
                AcroFields acroFields = pdfStamper.AcroFields;
                acroFields.SetField("Nume", NumeClient.Text); // Assuming "UserName" is the field name in the PDF
                acroFields.SetField("Prenume", PrenumeClient.Text);
                acroFields.SetField("Adresa", AdresaClient.Text);
                acroFields.SetField("CNP", CNP.Text);
                acroFields.SetField("Serie", Serie.Text);
                acroFields.SetField("Email", Email.Text);
                acroFields.SetField("Telefon", Telefon.Text);
                acroFields.SetField("IBAN", IBAN.Text);
                acroFields.SetField("Banca", Banca.Text);
                acroFields.SetField("AdresaCorespondenta", AdresaCorespondenta.Text);
                if (comboboxFormat.Text == "Electronic")
                {
                    acroFields.SetField("checkboxElectronic", "On");
                }
                else if (comboboxFormat.Text == "Tipărit")
                {
                    acroFields.SetField("checkboxTiparit", "On");
                }
                acroFields.SetField("CodClient", CodClient.Text);
                acroFields.SetField("AdresaLocConsum", AdresaLocConsum.Text);
                acroFields.SetField("ValabilitateActSpatiu", ValabilitateActSpatiu.Text);
                acroFields.SetField("CodLocConsum", CodLocConsumBox.Text);
                acroFields.SetField("CLC", CLCGazBox.Text);
                acroFields.SetField("CategorieDeConsum", CategorieConsumBox.Text);
                acroFields.SetField("Nume Prenume", NumeClient.Text + " " + PrenumeClient.Text);
                acroFields.SetField("ConsumAnualPrognozatGaz", ConsumAnualPrognozatGazBox.Text);
                acroFields.SetField("Data_semnari", DataSemnare.Text);
                acroFields.SetField("IDContract", IDContractBun);

                pdfStamper.Close();


                // Show message box to confirm that PDF was saved
                MessageBox.Show("PDF salvat.");

                // Code to open the saved PDF file
                Process.Start(newFileName);
            }
            else if (comboboxContract.Text == "Actual Gaz")
            {
                string fileName = "Assets/Contracte EON/Actual_Gas.pdf";
                PdfReader pdfReader = new PdfReader(fileName);
                /*            string fileSave = "Assets/Contracte EON/Generat/";*/

                // Code to save PDF with a modified name
                string newFileName = Path.Combine(Path.GetDirectoryName(fileName), $"{IDContractSave4}.pdf");
                FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);

                // Code to modify PDF fields
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
                AcroFields acroFields = pdfStamper.AcroFields;
                acroFields.SetField("Nume", NumeClient.Text); // Assuming "UserName" is the field name in the PDF
                acroFields.SetField("Prenume", PrenumeClient.Text);
                acroFields.SetField("Adresa", AdresaClient.Text);
                acroFields.SetField("CNP", CNP.Text);
                acroFields.SetField("Serie", Serie.Text);
                acroFields.SetField("Email", Email.Text);
                acroFields.SetField("Telefon", Telefon.Text);
                acroFields.SetField("IBAN", IBAN.Text);
                acroFields.SetField("Banca", Banca.Text);
                acroFields.SetField("AdresaCorespondenta", AdresaCorespondenta.Text);
                if (comboboxFormat.Text == "Electronic")
                {
                    acroFields.SetField("checkboxElectronic", "On");
                }
                else if (comboboxFormat.Text == "Tipărit")
                {
                    acroFields.SetField("checkboxTiparit", "On");
                }
                acroFields.SetField("CodClient", CodClient.Text);
                acroFields.SetField("AdresaLocConsum", AdresaLocConsum.Text);
                acroFields.SetField("ValabilitateActSpatiu", ValabilitateActSpatiu.Text);
                acroFields.SetField("CodLocConsum", CodLocConsumBox.Text);
                acroFields.SetField("CLC", CLCGazBox.Text);
                acroFields.SetField("CategorieDeConsum", CategorieConsumBox.Text);
                acroFields.SetField("Nume Prenume", NumeClient.Text + " " + PrenumeClient.Text);
                acroFields.SetField("ConsumAnualPrognozatGaz", ConsumAnualPrognozatGazBox.Text);
                acroFields.SetField("Data_semnari", DataSemnare.Text);
                acroFields.SetField("IDContract", IDContractBun);
                pdfStamper.Close();


                // Show message box to confirm that PDF was saved
                MessageBox.Show("PDF salvat.");

                // Code to open the saved PDF file
                Process.Start(newFileName);
            }
            else if (comboboxContract.Text == "Actual Duo Assist Pro")
            {



                string fileName = "Assets/Contracte EON/Actual_Duo_Assist_Pro.pdf";
                PdfReader pdfReader = new PdfReader(fileName);
                /*            string fileSave = "Assets/Contracte EON/Generat/";*/

                // Code to save PDF with a modified name
                string newFileName = Path.Combine(Path.GetDirectoryName(fileName), $"{IDContractSave4}.pdf");
                FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);

                // Code to modify PDF fields
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
                AcroFields acroFields = pdfStamper.AcroFields;
                acroFields.SetField("Nume", NumeClient.Text); // Assuming "UserName" is the field name in the PDF
                acroFields.SetField("Prenume", PrenumeClient.Text);
                acroFields.SetField("Adresa", AdresaClient.Text);
                acroFields.SetField("CNP", CNP.Text);
                acroFields.SetField("Serie", Serie.Text);
                acroFields.SetField("Email", Email.Text);
                acroFields.SetField("Telefon", Telefon.Text);
                acroFields.SetField("IBAN", IBAN.Text);
                acroFields.SetField("Banca", Banca.Text);
                acroFields.SetField("AdresaCorespondenta", AdresaCorespondenta.Text);
                if (comboboxFormat.Text == "Electronic")
                {
                    acroFields.SetField("checkboxElectronic", "On");
                }
                else if (comboboxFormat.Text == "Tipărit")
                {
                    acroFields.SetField("checkboxTiparit", "On");
                }
                acroFields.SetField("CodClient", CodClient.Text);
                acroFields.SetField("AdresaLocConsum", AdresaLocConsum.Text);
                acroFields.SetField("ValabilitateActSpatiu", ValabilitateActSpatiu.Text);
                acroFields.SetField("DataImplementare", DataImplementare.Text);
                acroFields.SetField("CLC", CLC.Text);
                acroFields.SetField("POD", POD.Text);
                acroFields.SetField("Nivel tensiune", NivelTensiune.Text);
                acroFields.SetField("CodLocConsum", CodLocConsumBox.Text);
                acroFields.SetField("CLCGaz", CLCGazBox.Text);
                acroFields.SetField("CategorieDeConsum", CategorieConsumBox.Text);
                acroFields.SetField("ConsumAnualPrognozatGaz", ConsumAnualPrognozatGazBox.Text);
                acroFields.SetField("Nume Prenume", NumeClient.Text + " " + PrenumeClient.Text);
                acroFields.SetField("Data_semnari", DataSemnare.Text);
                acroFields.SetField("IDContract", IDContractBun);
                pdfStamper.Close();


                // Show message box to confirm that PDF was saved
                MessageBox.Show("PDF salvat.");

                // Code to open the saved PDF file
                Process.Start(newFileName);
            }
            else if (comboboxContract.Text == "Actual Duo Assist")
            {



                string fileName = "Assets/Contracte EON/Actual_Duo_Assist.pdf";
                PdfReader pdfReader = new PdfReader(fileName);
                /*            string fileSave = "Assets/Contracte EON/Generat/";*/

                // Code to save PDF with a modified name
                string newFileName = Path.Combine(Path.GetDirectoryName(fileName), $"{IDContractSave4}.pdf");
                FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);

                // Code to modify PDF fields
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
                AcroFields acroFields = pdfStamper.AcroFields;
                acroFields.SetField("Nume", NumeClient.Text); // Assuming "UserName" is the field name in the PDF
                acroFields.SetField("Prenume", PrenumeClient.Text);
                acroFields.SetField("Adresa", AdresaClient.Text);
                acroFields.SetField("CNP", CNP.Text);
                acroFields.SetField("Serie", Serie.Text);
                acroFields.SetField("Email", Email.Text);
                acroFields.SetField("Telefon", Telefon.Text);
                acroFields.SetField("IBAN", IBAN.Text);
                acroFields.SetField("Banca", Banca.Text);
                acroFields.SetField("AdresaCorespondenta", AdresaCorespondenta.Text);
                if (comboboxFormat.Text == "Electronic")
                {
                    acroFields.SetField("checkboxElectronic", "On");
                }
                else if (comboboxFormat.Text == "Tipărit")
                {
                    acroFields.SetField("checkboxTiparit", "On");
                }
                acroFields.SetField("CodClient", CodClient.Text);
                acroFields.SetField("AdresaLocConsum", AdresaLocConsum.Text);
                acroFields.SetField("ValabilitateActSpatiu", ValabilitateActSpatiu.Text);
                acroFields.SetField("DataImplementare", DataImplementare.Text);
                acroFields.SetField("CLC", CLC.Text);
                acroFields.SetField("POD", POD.Text);
                acroFields.SetField("Nivel tensiune", NivelTensiune.Text);
                acroFields.SetField("CodLocConsum", CodLocConsumBox.Text);
                acroFields.SetField("CLCGaz", CLCGazBox.Text);
                acroFields.SetField("CategorieDeConsum", CategorieConsumBox.Text);
                acroFields.SetField("ConsumAnualPrognozatGaz", ConsumAnualPrognozatGazBox.Text);
                acroFields.SetField("Nume Prenume", NumeClient.Text + " " + PrenumeClient.Text);
                acroFields.SetField("Data_semnari", DataSemnare.Text);
                acroFields.SetField("IDContract", IDContractBun);
                pdfStamper.Close();


                // Show message box to confirm that PDF was saved
                MessageBox.Show("PDF salvat.");

                // Code to open the saved PDF file
                Process.Start(newFileName);
            }
            else if (comboboxContract.Text == "Actual Duo")
            {
                string fileName = "Assets/Contracte EON/Actual_Duo.pdf";
                PdfReader pdfReader = new PdfReader(fileName);
                /*            string fileSave = "Assets/Contracte EON/Generat/";*/

                // Code to save PDF with a modified name
                string newFileName = Path.Combine(Path.GetDirectoryName(fileName), $"{IDContractSave4}.pdf");
                FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);

                // Code to modify PDF fields
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
                AcroFields acroFields = pdfStamper.AcroFields;
                acroFields.SetField("Nume", NumeClient.Text); // Assuming "UserName" is the field name in the PDF
                acroFields.SetField("Prenume", PrenumeClient.Text);
                acroFields.SetField("Adresa", AdresaClient.Text);
                acroFields.SetField("CNP", CNP.Text);
                acroFields.SetField("Serie", Serie.Text);
                acroFields.SetField("Email", Email.Text);
                acroFields.SetField("Telefon", Telefon.Text);
                acroFields.SetField("IBAN", IBAN.Text);
                acroFields.SetField("Banca", Banca.Text);
                acroFields.SetField("AdresaCorespondenta", AdresaCorespondenta.Text);
                if (comboboxFormat.Text == "Electronic")
                {
                    acroFields.SetField("checkboxElectronic", "On");
                }
                else if (comboboxFormat.Text == "Tipărit")
                {
                    acroFields.SetField("checkboxTiparit", "On");
                }
                acroFields.SetField("CodClient", CodClient.Text);
                acroFields.SetField("AdresaLocConsum", AdresaLocConsum.Text);
                acroFields.SetField("ValabilitateActSpatiu", ValabilitateActSpatiu.Text);
                acroFields.SetField("DataImplementare", DataImplementare.Text);
                acroFields.SetField("CLC", CLC.Text);
                acroFields.SetField("POD", POD.Text);
                acroFields.SetField("Nivel tensiune", NivelTensiune.Text);
                acroFields.SetField("CodLocConsum", CodLocConsumBox.Text);
                acroFields.SetField("CLCGaz", CLCGazBox.Text);
                acroFields.SetField("CategorieDeConsum", CategorieConsumBox.Text);
                acroFields.SetField("ConsumAnualPrognozatGaz", ConsumAnualPrognozatGazBox.Text);
                acroFields.SetField("Nume Prenume", NumeClient.Text + " " + PrenumeClient.Text);
                acroFields.SetField("Data_semnari", DataSemnare.Text);
                acroFields.SetField("IDContract", IDContractBun);
                pdfStamper.Close();

                // Show message box to confirm that PDF was saved
                MessageBox.Show("PDF salvat.");

                // Code to open the saved PDF file
                Process.Start(newFileName);
            }
            else if (comboboxContract.Text == "Contract asistenta tehnica")
            {
                string fileName = "Assets/Contracte EON/ServExpress_D2D.pdf";
                PdfReader pdfReader = new PdfReader(fileName);
                /*            string fileSave = "Assets/Contracte EON/Generat/";*/

                // Code to save PDF with a modified name
                string newFileName = Path.Combine(Path.GetDirectoryName(fileName), $"{IDContractSave4}.pdf");
                FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);

                // Code to modify PDF fields
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
                AcroFields acroFields = pdfStamper.AcroFields;
                acroFields.SetField("Nume", NumeClient.Text); // Assuming "UserName" is the field name in the PDF
                acroFields.SetField("Prenume", PrenumeClient.Text);
                acroFields.SetField("Adresa", AdresaClient.Text);
                acroFields.SetField("CNP", CNP.Text);
                acroFields.SetField("Serie", Serie.Text);
                acroFields.SetField("Email", Email.Text);
                acroFields.SetField("Telefon", Telefon.Text);
                acroFields.SetField("IBAN", IBAN.Text);
                acroFields.SetField("Banca", Banca.Text);
                acroFields.SetField("AdresaCorespondenta", AdresaCorespondenta.Text);
                if (comboboxPachetServicii.Text == "EON ServExpress")
                {
                    acroFields.SetField("checkboxElectronic", "On");
                }
                else if (comboboxPachetServicii.Text == "EON ServExpress Pro")
                {
                    acroFields.SetField("checkboxTiparit", "On");
                }
                acroFields.SetField("AdresaLocConsum", AdresaLocConsum.Text);
                acroFields.SetField("DataImplementare", DataImplementare.Text);
                acroFields.SetField("Nume Prenume", NumeClient.Text + " " + PrenumeClient.Text);
                acroFields.SetField("IDContract", IDContractBun);
                pdfStamper.Close();

                // Show message box to confirm that PDF was saved
                MessageBox.Show("PDF salvat.");

                // Code to open the saved PDF file
                Process.Start(newFileName);
            }

        }

    }
}
