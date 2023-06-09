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

                acroFields.SetField("nume", nameAngajat.Text+" "+prenumeAngajat.Text);
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

                MessageBox.Show("PDF salvat.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
