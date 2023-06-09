﻿// <copyright file="HRDocumentGenerator.xaml.cs" company="eOverArt Marketing Agency">
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

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);

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

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);

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

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
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

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                acroFields.SetField("dataT", dataAngajare.Text);

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

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);

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

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder13 = "Assets/HR";
            string templateFileName13 = "13.Declaratie_pentru_indeplinirea_cerintelor_de_securitate_si_confidentialitate 1 ex.pdf";
            string templatePath13 = Path.Combine(templateFolder13, templateFileName13);

            string outputFolder13 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder13);

            string newFileName13 = Path.Combine(outputFolder13, $"13.Declaratie_pentru_indeplinirea_cerintelor_de_securitate_si_confidentialitate 1 ex-{nameAngajat.Text}.pdf");
            FileStream fileStream13 = new FileStream(newFileName13, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath13);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream13);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                acroFields.SetField("dataT", dataAngajare.Text);

                pdfStamper.Close();
                fileStream13.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder14 = "Assets/HR";
            string templateFileName14 = "14.Fisa postului - Agent vanzari 2ex.pdf";
            string templatePath14 = Path.Combine(templateFolder14, templateFileName14);

            string outputFolder14 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder14);

            string newFileName14 = Path.Combine(outputFolder14, $"14.Fisa postului - Agent vanzari 2ex-{nameAngajat.Text}.pdf");
            FileStream fileStream14 = new FileStream(newFileName14, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath14);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream14);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                acroFields.SetField("dataT", dataAngajare.Text);

                pdfStamper.Close();
                fileStream14.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            string templateFolder15 = "Assets/HR";
            string templateFileName15 = "15.Informare salariati_Final_TC_rev KPMG_23052018_Optima_revAS_28032019  2 ex.pdf";
            string templatePath15 = Path.Combine(templateFolder15, templateFileName15);

            string outputFolder15 = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(outputFolder15);

            string newFileName15 = Path.Combine(outputFolder15, $"15.Informare salariati_Final_TC_rev KPMG_23052018_Optima_revAS_28032019  2 ex-{nameAngajat.Text}.pdf");
            FileStream fileStream15 = new FileStream(newFileName15, FileMode.Create, FileAccess.Write);

            try
            {
                PdfReader pdfReader = new PdfReader(templatePath15);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream15);
                AcroFields acroFields = pdfStamper.AcroFields;

                acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                acroFields.SetField("dataT", dataAngajare.Text);

                pdfStamper.Close();
                fileStream15.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            if (ComboProiect.Text == "Vodafone")
            {
                string templateFolder16 = "Assets/HR";
                string templateFileName16 = "16.DPA- GDPR clienti VDF - 2 ex.pdf";
                string templatePath16 = Path.Combine(templateFolder16, templateFileName16);

                string outputFolder16 = Path.Combine(desktopPath, folderName);
                Directory.CreateDirectory(outputFolder16);

                string newFileName16 = Path.Combine(outputFolder16, $"16.DPA- GDPR clienti VDF - 2 ex-{nameAngajat.Text}.pdf");
                FileStream fileStream16 = new FileStream(newFileName16, FileMode.Create, FileAccess.Write);

                try
                {
                    PdfReader pdfReader = new PdfReader(templatePath16);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream16);
                    AcroFields acroFields = pdfStamper.AcroFields;

                    acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                    acroFields.SetField("localitate", localitate.Text);
                    acroFields.SetField("serieCI", serieCI.Text);
                    acroFields.SetField("numarCI", NumarCI.Text);
                    acroFields.SetField("emis", emisDe.Text);
                    acroFields.SetField("deLa", valabilitateCI.Text);
                    acroFields.SetField("dataT", dataAngajare.Text);
                    acroFields.SetField("cnp", cnpAngajat.Text);

                    pdfStamper.Close();
                    fileStream16.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (ComboProiect.Text == "Telekom")
            {
                string templateFolder17 = "Assets/HR";
                string templateFileName17 = "17.DPA- GDPR clienti TLK - 2 ex.pdf";
                string templatePath17 = Path.Combine(templateFolder17, templateFileName17);

                string outputFolder17 = Path.Combine(desktopPath, folderName);
                Directory.CreateDirectory(outputFolder17);

                string newFileName17 = Path.Combine(outputFolder17, $"17.DPA- GDPR clienti TLK - 2 ex-{nameAngajat.Text}.pdf");
                FileStream fileStream17 = new FileStream(newFileName17, FileMode.Create, FileAccess.Write);

                try
                {
                    PdfReader pdfReader = new PdfReader(templatePath17);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream17);
                    AcroFields acroFields = pdfStamper.AcroFields;

                    acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                    acroFields.SetField("localitate", localitate.Text);
                    acroFields.SetField("serieCI", serieCI.Text);
                    acroFields.SetField("numarCI", NumarCI.Text);
                    acroFields.SetField("emis", emisDe.Text);
                    acroFields.SetField("deLa", valabilitateCI.Text);
                    acroFields.SetField("dataT", dataAngajare.Text);
                    acroFields.SetField("cnp", cnpAngajat.Text);

                    pdfStamper.Close();
                    fileStream17.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (ComboProiect.Text == "CEC")
            {
                string templateFolder18 = "Assets/HR";
                string templateFileName18 = "20.DPA- GDPR clienti CEC - 2 ex.pdf";
                string templatePath18 = Path.Combine(templateFolder18, templateFileName18);

                string outputFolder18 = Path.Combine(desktopPath, folderName);
                Directory.CreateDirectory(outputFolder18);

                string newFileName18 = Path.Combine(outputFolder18, $"20.DPA- GDPR clienti CEC - 2 ex-{nameAngajat.Text}.pdf");
                FileStream fileStream18 = new FileStream(newFileName18, FileMode.Create, FileAccess.Write);

                try
                {
                    PdfReader pdfReader = new PdfReader(templatePath18);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream18);
                    AcroFields acroFields = pdfStamper.AcroFields;

                    acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                    acroFields.SetField("localitate", localitate.Text);
                    acroFields.SetField("serieCI", serieCI.Text);
                    acroFields.SetField("numarCI", NumarCI.Text);
                    acroFields.SetField("emis", emisDe.Text);
                    acroFields.SetField("deLa", valabilitateCI.Text);
                    acroFields.SetField("dataT", dataAngajare.Text);
                    acroFields.SetField("cnp", cnpAngajat.Text);

                    pdfStamper.Close();
                    fileStream18.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (ComboProiect.Text == "BCR")
            {
                string templateFolder19 = "Assets/HR";
                string templateFileName19 = "18.DPA- GDPR clienti BCR - 2 ex.pdf";
                string templatePath19 = Path.Combine(templateFolder19, templateFileName19);

                string outputFolder19 = Path.Combine(desktopPath, folderName);
                Directory.CreateDirectory(outputFolder19);

                string newFileName19 = Path.Combine(outputFolder19, $"18.DPA- GDPR clienti BCR - 2 ex-{nameAngajat.Text}.pdf");
                FileStream fileStream19 = new FileStream(newFileName19, FileMode.Create, FileAccess.Write);

                try
                {
                    PdfReader pdfReader = new PdfReader(templatePath19);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream19);
                    AcroFields acroFields = pdfStamper.AcroFields;

                    acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                    acroFields.SetField("localitate", localitate.Text);
                    acroFields.SetField("seriaCI", serieCI.Text);
                    acroFields.SetField("numarCI", NumarCI.Text);
                    acroFields.SetField("emis", emisDe.Text);
                    acroFields.SetField("deLa", valabilitateCI.Text);
                    acroFields.SetField("dataT", dataAngajare.Text);
                    acroFields.SetField("cnp", cnpAngajat.Text);

                    pdfStamper.Close();
                    fileStream19.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (ComboProiect.Text == "EON")
            {
                string templateFolder20 = "Assets/HR";
                string templateFileName20 = "19.DPA- GDPR clienti EON - 2 ex.pdf";
                string templatePath20 = Path.Combine(templateFolder20, templateFileName20);

                string outputFolder20 = Path.Combine(desktopPath, folderName);
                Directory.CreateDirectory(outputFolder20);

                string newFileName20 = Path.Combine(outputFolder20, $"19.DPA- GDPR clienti EON - 2 ex-{nameAngajat.Text}.pdf");
                FileStream fileStream20 = new FileStream(newFileName20, FileMode.Create, FileAccess.Write);

                try
                {
                    PdfReader pdfReader = new PdfReader(templatePath20);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream20);
                    AcroFields acroFields = pdfStamper.AcroFields;

                    acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                    acroFields.SetField("localitate", localitate.Text);
                    acroFields.SetField("serieCI", serieCI.Text);
                    acroFields.SetField("numarCI", NumarCI.Text);
                    acroFields.SetField("emis", emisDe.Text);
                    acroFields.SetField("deLa", valabilitateCI.Text);
                    acroFields.SetField("dataT", dataAngajare.Text);
                    acroFields.SetField("cnp", cnpAngajat.Text);

                    pdfStamper.Close();
                    fileStream20.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (ComboProiect.Text == "Orange")
            {
                string templateFolder21 = "Assets/HR";
                string templateFileName21 = "22. DPA- GDPR clienti Orange - 2ex.pdf";
                string templatePath21 = Path.Combine(templateFolder21, templateFileName21);

                string outputFolder21 = Path.Combine(desktopPath, folderName);
                Directory.CreateDirectory(outputFolder21);

                string newFileName21 = Path.Combine(outputFolder21, $"22. DPA- GDPR clienti Orange - 2ex-{nameAngajat.Text}.pdf");
                FileStream fileStream21 = new FileStream(newFileName21, FileMode.Create, FileAccess.Write);

                try
                {
                    PdfReader pdfReader = new PdfReader(templatePath21);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream21);
                    AcroFields acroFields = pdfStamper.AcroFields;

                    acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                    acroFields.SetField("localitate", localitate.Text);
                    acroFields.SetField("serieCI", serieCI.Text);
                    acroFields.SetField("numarCI", NumarCI.Text);
                    acroFields.SetField("emis", emisDe.Text);
                    acroFields.SetField("deLa", valabilitateCI.Text);
                    acroFields.SetField("dataT", dataAngajare.Text);
                    acroFields.SetField("cnp", cnpAngajat.Text);

                    pdfStamper.Close();
                    fileStream21.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (ComboProiect.Text == "OROC")
            {
                string templateFolder22 = "Assets/HR";
                string templateFileName22 = "21. DPA- GDPR clienti OROC - 2ex.pdf";
                string templatePath22 = Path.Combine(templateFolder22, templateFileName22);

                string outputFolder22 = Path.Combine(desktopPath, folderName);
                Directory.CreateDirectory(outputFolder22);

                string newFileName22 = Path.Combine(outputFolder22, $"21. DPA- GDPR clienti OROC - 2ex-{nameAngajat.Text}.pdf");
                FileStream fileStream22 = new FileStream(newFileName22, FileMode.Create, FileAccess.Write);

                try
                {
                    PdfReader pdfReader = new PdfReader(templatePath22);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream22);
                    AcroFields acroFields = pdfStamper.AcroFields;

                    acroFields.SetField("nume", nameAngajat.Text + " " + prenumeAngajat.Text);
                    acroFields.SetField("localitate", localitate.Text);
                    acroFields.SetField("serieCI", serieCI.Text);
                    acroFields.SetField("numarCI", NumarCI.Text);
                    acroFields.SetField("emis", emisDe.Text);
                    acroFields.SetField("deLa", valabilitateCI.Text);
                    acroFields.SetField("dataT", dataAngajare.Text);
                    acroFields.SetField("cnp", cnpAngajat.Text);

                    pdfStamper.Close();
                    fileStream22.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            CustomControls.Prompt dialog = new CustomControls.Prompt();
            dialog.Loaded += (s, ea) =>
            {
                dialog.Title = "Succes";
                dialog.Status.Text = "Toate pdf-urile au fost generate";
                dialog.Descriere.Text = "A fost creat un folder pe desktop unde se gasesc toate fisierele completate.";
            };
            dialog.ShowDialog();
        }
    }
}
