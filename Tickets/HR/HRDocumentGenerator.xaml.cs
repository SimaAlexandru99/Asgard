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

            string newFileName3 = Path.Combine(outputFolder2, $"3.AA GDPR_WFH-{nameAngajat.Text}.pdf");
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

                MessageBox.Show("PDF salvat.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
