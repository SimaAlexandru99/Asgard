// <copyright file="HRDocumentGenerator.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Tickets.HR
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using Asgard.ViewModels;
    using iTextSharp.text.pdf;

    /// <summary>
    /// Interaction logic for HRDocumentGenerator.xaml.
    /// </summary>
    public partial class HRDocumentGenerator : Page
    {
        public HRDocumentGenerator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = new MainViewModel();
            string nume = user.CurrentUserAccount.Name.ToString();
            string prenume = user.CurrentUserAccount.LastName.ToString();

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderName = nameAngajat.Text; // Replace with your custom folder name

            string templateFolder = "Assets/HR";
            string templateFileName = "1.Angajamentul consultantului.pdf";
            string templatePath = Path.Combine(templateFolder, templateFileName);

            string outputFolder = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder);

            string newFileName = Path.Combine(outputFolder, $"1.Angajamentul consultantului-{nameAngajat.Text}.pdf");
            FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text);
                acroFields.SetField("prenume", prenumeAngajat.Text);

                pdfStamper.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder2 = "Assets/HR";
            string templateFileName2 = "2.X2 Consimtamant salariati prelucrare imagine_foto_video_final.pdf";
            string templatePath2 = Path.Combine(templateFolder2, templateFileName2);

            string outputFolder2 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder2);

            string newFileName2 = Path.Combine(outputFolder2, $"2.X2 Consimtamant salariati prelucrare imagine_foto_video_final-{nameAngajat.Text}.pdf");
            FileStream fileStream2 = new FileStream(newFileName2, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath2);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream2);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text);
                acroFields.SetField("prenume", prenumeAngajat.Text);

                pdfStamper.Close();
                fileStream2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder3 = "Assets/HR";
            string templateFileName3 = "3.AA GDPR_WFH.pdf";
            string templatePath3 = Path.Combine(templateFolder3, templateFileName3);

            string outputFolder3 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder3);

            string newFileName3 = Path.Combine(outputFolder3, $"3.AA GDPR_WFH-{nameAngajat.Text}.pdf");
            FileStream fileStream3 = new FileStream(newFileName3, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath3);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream3);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text);
                acroFields.SetField("prenume", prenumeAngajat.Text);
                acroFields.SetField("HR", nume + " " + prenume);

                pdfStamper.Close();
                fileStream3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder4 = "Assets/HR";
            string templateFileName4 = "4.Anexa Fisa autoevaluare SSM Optima.pdf";
            string templatePath4 = Path.Combine(templateFolder4, templateFileName4);

            string outputFolder4 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder4);

            string newFileName4 = Path.Combine(outputFolder4, $"4.Anexa Fisa autoevaluare SSM Optima-{nameAngajat.Text}.pdf");
            FileStream fileStream4 = new FileStream(newFileName4, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath4);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream4);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text);
                acroFields.SetField("prenume", prenumeAngajat.Text);

                pdfStamper.Close();
                fileStream4.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder5 = "Assets/HR";
            string templateFileName5 = "5.Anexa SSM _ WFH.pdf";
            string templatePath5 = Path.Combine(templateFolder5, templateFileName5);

            string outputFolder5 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder5);

            string newFileName5 = Path.Combine(outputFolder5, $"5.Anexa SSM _ WFH-{nameAngajat.Text}.pdf");
            FileStream fileStream5 = new FileStream(newFileName5, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath5);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream5);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text);
                acroFields.SetField("prenume", prenumeAngajat.Text);

                pdfStamper.Close();
                fileStream5.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder6 = "Assets/HR";
            string templateFileName6 = "6.Angajament RI 1 ex.pdf";
            string templatePath6 = Path.Combine(templateFolder6, templateFileName6);

            string outputFolder6 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder6);

            string newFileName6 = Path.Combine(outputFolder6, $"6.Angajament RI 1 ex-{nameAngajat.Text}.pdf");
            FileStream fileStream6 = new FileStream(newFileName6, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath6);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream6);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text);
                acroFields.SetField("prenume", prenumeAngajat.Text);
                acroFields.SetField("serieCI", serieCI.Text);
                acroFields.SetField("numarCI", NumarCI.Text);
                acroFields.SetField("dataT", dataAngajare.Text);

                pdfStamper.Close();
                fileStream6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder7 = "Assets/HR";
            string templateFileName7 = "7.Cerere de angajare 1 ex.pdf";
            string templatePath7 = Path.Combine(templateFolder7, templateFileName7);

            string outputFolder7 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder7);

            string newFileName7 = Path.Combine(outputFolder7, $"7.Cerere de angajare 1 ex-{nameAngajat.Text}.pdf");
            FileStream fileStream7 = new FileStream(newFileName7, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath7);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream7);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                acroFields.SetField("localitate", localitate.Text);
                acroFields.SetField("strada", strada.Text);
                acroFields.SetField("numar", numarStrada.Text);
                acroFields.SetField("bloc", bloc.Text);
                acroFields.SetField("scara", scara.Text);
                acroFields.SetField("apartament", apartament.Text);
                acroFields.SetField("judet", judet.Text);
                acroFields.SetField("serieCI", serieCI.Text);
                acroFields.SetField("numarCI", NumarCI.Text);
                acroFields.SetField("deLa", valabilitateCI.Text);
                acroFields.SetField("emis", emisDe.Text);
                acroFields.SetField("dataT", dataAngajare.Text);
                acroFields.SetField("functia", ComboFunctie.Text);

                pdfStamper.Close();
                fileStream7.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder8 = "Assets/HR";
            string templateFileName8 = "8.Consimtamant salariati prelucrare acordare beneficii_draft_OPTIMA 2 ex.pdf";
            string templatePath8 = Path.Combine(templateFolder8, templateFileName8);

            string outputFolder8 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder8);

            string newFileName8 = Path.Combine(outputFolder8, $"8.Consimtamant salariati prelucrare acordare beneficii_draft_OPTIMA 2 ex-{nameAngajat.Text}.pdf");
            FileStream fileStream8 = new FileStream(newFileName8, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath8);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream8);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                acroFields.SetField("cnp", cnpAngajat.Text);
                acroFields.SetField("dataT", dataAngajare.Text);

                pdfStamper.Close();
                fileStream8.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder9 = "Assets/HR";
            string templateFileName9 = "9.Consimtamant salariati prelucrare imagine_foto_video_final - Template OP 2 ex.pdf";
            string templatePath9 = Path.Combine(templateFolder9, templateFileName9);

            string outputFolder9 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder9);

            string newFileName9 = Path.Combine(outputFolder9, $"9.Consimtamant salariati prelucrare imagine_foto_video_final - Template OP 2 ex-{nameAngajat.Text}.pdf");
            FileStream fileStream9 = new FileStream(newFileName9, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath9);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream9);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                acroFields.SetField("dataT", dataAngajare.Text);

                pdfStamper.Close();
                fileStream9.Close();

                MessageBox.Show("PDF salvat.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder10 = "Assets/HR";
            string templateFileName10 = "10.Declaratie CAS.pdf";
            string templatePath10 = Path.Combine(templateFolder10, templateFileName10);

            string outputFolder10 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder10);

            string newFileName10 = Path.Combine(outputFolder10, $"10.Declaratie CAS-{nameAngajat.Text}.pdf");
            FileStream fileStream10 = new FileStream(newFileName10, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath10);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream10);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                acroFields.SetField("dataT", dataAngajare.Text);

                pdfStamper.Close();
                fileStream10.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder11 = "Assets/HR";
            string templateFileName11 = "11.Declaratie la angajare 1 ex.pdf";
            string templatePath11 = Path.Combine(templateFolder11, templateFileName11);

            string outputFolder11 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder11);

            string newFileName11 = Path.Combine(outputFolder11, $"11.Declaratie la angajare 1 ex-{nameAngajat.Text}.pdf");
            FileStream fileStream11 = new FileStream(newFileName11, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath11);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream11);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                acroFields.SetField("dataT", dataAngajare.Text);
                acroFields.SetField("cnp", cnpAngajat.Text);
                acroFields.SetField("judet", judet.Text);
                acroFields.SetField("localitate", localitate.Text);
                acroFields.SetField("strada", strada.Text);
                acroFields.SetField("numar", numarStrada.Text);
                acroFields.SetField("bloc", bloc.Text);
                acroFields.SetField("scara", scara.Text);
                acroFields.SetField("apartament", apartament.Text);

                pdfStamper.Close();
                fileStream11.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder12 = "Assets/HR";
            string templateFileName12 = "12.Declaratie part-time 1ex.pdf";
            string templatePath12 = Path.Combine(templateFolder12, templateFileName12);

            string outputFolder12 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder12);

            string newFileName12 = Path.Combine(outputFolder12, $"12.Declaratie part-time 1ex-{nameAngajat.Text}.pdf");
            FileStream fileStream12 = new FileStream(newFileName12, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath12);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream12);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                acroFields.SetField("dataT", dataAngajare.Text);
                acroFields.SetField("cnp", cnpAngajat.Text);
                acroFields.SetField("judet", judet.Text);
                acroFields.SetField("localitate", localitate.Text);
                acroFields.SetField("strada", strada.Text);
                acroFields.SetField("numar", numarStrada.Text);
                acroFields.SetField("bloc", bloc.Text);
                acroFields.SetField("scara", scara.Text);
                acroFields.SetField("apartament", apartament.Text);
                acroFields.SetField("serieCI", serieCI.Text);
                acroFields.SetField("numarCI", NumarCI.Text);

                pdfStamper.Close();
                fileStream12.Close();

                MessageBox.Show("PDF salvat.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
