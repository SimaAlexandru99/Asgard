// <copyright file="TicketsBackoffice.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Tickets.Vodafone
{
    using System;
    using System.Net.Security;
    using System.Security.Authentication;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;
    using Asgard.Pages;
    using Asgard.Repositories;
    using Asgard.ViewModels;
    using MailKit;
    using MailKit.Net.Smtp;
    using MimeKit;

    /// <summary>
    /// Interaction logic for TicketsBackoffice.xaml.
    /// </summary>
    public partial class TicketsBackoffice : Page
    {
        public TicketsBackoffice()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            phoneClient.Text = NumeClient.Text = CNP.Text = idPropunere.Text = orderID.Text = comboboxDesecurizare.Text = RefundMethodTextBox.Text = DenumireOptiune.Text = comboboxOptiune.Text = OptiuneData.Text = SumaAjustari.Text = MotivAjustare.Text = comboboxFacturaAjustare.Text = OfertaManuala.Text = CodDealer.Text = string.Empty;
        }

        private void Text_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var user = new MainViewModel();
            string email = user.CurrentUserAccount.Email.ToString();

            if (comboboxTicketeRetentie.Text == "Rollback")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || idPropunere.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + idPropunere.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" + "Nume si prenume: " + NumeClient.Text + "\r\n" + "CNP: " + CNP.Text + "\r\n" + "ID Propunere: " + idPropunere.Text + "\r\n" + "Descriere: " + "Va rog sa ma ajutati cu rollback",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Ajustare CED")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || idPropunere.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + idPropunere.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" + "Nume si prenume: " + NumeClient.Text + "\r\n" + "CNP: " + CNP.Text + "\r\n" + "ID Propunere: " + idPropunere.Text + "\r\n" + "Descriere: " + "Va rog sa ma ajutati cu ajustare CED in urma rollback-ului",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Desecurizare")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || idPropunere.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + idPropunere.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" +
                        "Nume si prenume: " + NumeClient.Text + "\r\n" +
                        "CNP: " + CNP.Text + "\r\n" +
                        "ID Propunere: " + idPropunere.Text + "\r\n" +
                        "Tip desecurizare: " + comboboxDesecurizare.Text + "\r\n" +
                               "Descriere: " + "Va rog sa ma ajutati cu desecurizare",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Anulare order")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || orderID.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + orderID.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" + "Nume si prenume: " + NumeClient.Text + "\r\n" + "CNP: " + CNP.Text + "\r\n" + "ID Propunere: " + idPropunere.Text + "\r\n" + "Descriere: " + "Va rog sa ma ajutati cu anulare order",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Solicitare refund")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty | orderID.Text == string.Empty || comboboxTipRefund.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + orderID.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" +
                               "Nume si prenume: " + NumeClient.Text + "\r\n" +
                               "CNP: " + CNP.Text + "\r\n" +
                               "ID Comanda: " + orderID.Text + "\r\n" +
                               "Metoda refund: " + orderID.Text + "\r\n" +
                               "Unde: " + comboboxTipRefund.Text + "\r\n" +
                               "Informatii suplimentare refund: " + RefundMethodTextBox.Text + "\r\n" +
                               "Descriere: " + "Va rog sa ma ajutati cu refund",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Activare/dezactivare opțiuni")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || DenumireOptiune.Text == string.Empty || comboboxOptiune.Text == string.Empty || OptiuneData.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + phoneClient.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" +
                               "Nume si prenume: " + NumeClient.Text + "\r\n" +
                               "CNP: " + CNP.Text + "\r\n" +
                               "Denumire optiune: " + DenumireOptiune.Text + "\r\n" +
                               "Activare/dezactivare: " + comboboxOptiune.Text + "\r\n" +
                               "Data activare/dezactivare: " + OptiuneData.Text + "\r\n" +
                               "Descriere: " + "Va rog sa ma ajutati cu " + comboboxOptiune.Text + " optiune",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            /* else if (comboboxTicketeRetentie.Text == "Ajustări")
             {
                 if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || SumaAjustari.Text == string.Empty || MotivAjustare.Text == string.Empty || comboboxFacturaAjustare.Text == string.Empty)
                 {
                     CustomControls.Prompt dialog = new CustomControls.Prompt();
                     dialog.Loaded += (s, ea) =>
                     {
                         dialog.Title = "Eroare";
                         dialog.Status.Text = "Ticket-ul nu a fost trimis";
                         dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                     };
                     dialog.ShowDialog();
                 } 
                 else
                 {
                     MimeMessage message = new MimeMessage
                     {
                         Subject = "Ticket Ajustare: " + phoneClient.Text,
                     };
                     message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                     message.To.Add(MailboxAddress.Parse(email));
                     message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                     message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                     message.Body = new TextPart("plain")
                     {
                         Text = "Client: " + phoneClient.Text + "\r\n" +
                                "Nume si prenume: " + NumeClient.Text + "\r\n" +
                                "CNP: " + CNP.Text + "\r\n" +
                                "Suma de ajustat: " + SumaAjustari.Text + "\r\n" +
                                "Motiv ajustare: " + MotivAjustare.Text + "\r\n" +
                                "Impact la factura?: " + comboboxFacturaAjustare.Text + "\r\n" +
                                "Descriere: " + "Va rog sa ma ajutati cu ajustare",
                     };
                     string emailAddress = "asgard@optimacall.ro";
                     string password = "Optima#321";
                     SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                     try
                     {
                         client.CheckCertificateRevocation = false;
                         client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                         client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                         client.Connect("zmail.optimacall.ro", 465, true);
                         client.Authenticate(emailAddress, password);
                         client.Send(message);

                         CustomControls.Prompt dialog = new CustomControls.Prompt();
                         dialog.Loaded += (s, ea) =>
                         {
                             dialog.Title = "Succes";
                             dialog.Status.Text = "Ticket-ul a fost trimis";
                             dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                         };
                         dialog.ShowDialog();
                         Clear();
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine(ex.Message);

                         CustomControls.Prompt dialog = new CustomControls.Prompt();
                         dialog.Loaded += (s, ea) =>
                         {
                             dialog.Title = "Eroare";
                             dialog.Status.Text = "Ticket-ul nu a fost trimis";
                             dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                         };
                         dialog.ShowDialog();
                     }
                     finally
                     {
                         client.Disconnect(true);
                         client.Dispose();
                     }
                 }
             } */
            else if (comboboxTicketeRetentie.Text == "Autorizări")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket Autorizare: " + phoneClient.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" +
                               "Nume si prenume: " + NumeClient.Text + "\r\n" +
                               "CNP: " + CNP.Text + "\r\n" +
                               "Descriere: " + "Va rog sa ma ajutati cu autorizare numar",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Scoatere numere din grup")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + phoneClient.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" + "Nume si prenume: " + NumeClient.Text + "\r\n" + "CNP: " + CNP.Text + "\r\n" + "Descriere: " + "Va rog sa ma ajutati cu scoatere numar din grup",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Implementare manuală")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || OfertaManuala.Text == string.Empty || CodDealer.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket implementare manuala: " + phoneClient.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" + "Nume si prenume: " + NumeClient.Text + "\r\n" + "CNP: " + CNP.Text + "\r\n" + "Oferta aleasa: " + OfertaManuala.Text + "\r\n" + "Cod Dealer: " + CodDealer.Text + "\r\n" + "Descriere: " + "Va rog sa ma ajutati cu implementare manuala",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Actualizare RMA")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || idPropunere.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + idPropunere.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" + "Nume si prenume: " + NumeClient.Text + "\r\n" + "CNP: " + CNP.Text + "\r\n" + "ID Propunere: " + idPropunere.Text + "\r\n" + "Descriere: " + "Va rog sa ma ajutati cu actualizare RMA",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Anulare comandă")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || orderID.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket anulare comanda: " + orderID.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" + "Nume si prenume: " + NumeClient.Text + "\r\n" + "CNP: " + CNP.Text + "\r\n" + "ID Comanda: " + orderID.Text + "\r\n" + "Descriere: " + "Va rog sa ma ajutati cu anulare comandă",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Anulare FR")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || idPropunere.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + idPropunere.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" + "Nume si prenume: " + NumeClient.Text + "\r\n" + "CNP: " + CNP.Text + "\r\n" + "ID Propunere: " + idPropunere.Text + "\r\n" + "Descriere: " + "Va rog sa ma ajutati cu anulare FR",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Reconectare număr")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || idPropunere.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket reconectare: " + idPropunere.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" + "Nume si prenume: " + NumeClient.Text + "\r\n" + "CNP: " + CNP.Text + "\r\n" + "ID Propunere: " + idPropunere.Text + "\r\n" + "Descriere: " + "Va rog sa ma ajutati cu reconectarea numarului",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Repostare FR")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || idPropunere.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + idPropunere.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" +
                               "Nume si prenume: " + NumeClient.Text + "\r\n" +
                               "CNP: " + CNP.Text + "\r\n" +
                               "ID Propunere: " + idPropunere.Text + "\r\n" +
                               "Data repostare FR: " + repostareFR.Text + "\r\n" +
                               "Descriere: " + "Va rog sa ma ajutati cu repostare FR",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
            else if (comboboxTicketeRetentie.Text == "Eroare LPS")
            {
                if (phoneClient.Text == string.Empty || NumeClient.Text == string.Empty || CNP.Text == string.Empty || idPropunere.Text == string.Empty)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ticket-ul nu a fost trimis";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage
                    {
                        Subject = "Ticket " + comboboxTicketeRetentie.Text + ": " + idPropunere.Text,
                    };
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse(email));
                    message.To.Add(MailboxAddress.Parse("odin@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("backoffice@optimacall.ro"));
                    message.Body = new TextPart("plain")
                    {
                        Text = "Client: " + phoneClient.Text + "\r\n" + "Nume si prenume: " + NumeClient.Text + "\r\n" + "CNP: " + CNP.Text + "\r\n" + "ID Propunere: " + idPropunere.Text + "\r\n" + "Descriere: " + "Va rog sa ma ajutati cu eroare LPS intalnita la FH. Tipul erorii : Eroare la autentificarea persoanei autorizate/ account_not_eligible",
                    };
                    string emailAddress = "asgard@optimacall.ro";
                    string password = "Optima#321";
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Ticket-ul a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul a fost trimis cu succes, verifică-ți email-ul pentru a fi la curent cu statusul lui.";
                        };
                        dialog.ShowDialog();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Ticket-ul nu a fost trimis";
                            dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void ComboboxTipRefund_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedValue = selectedItem.Content.ToString();

            if (selectedValue == "În magazin Vodafone")
            {
                RefundMethod.Text = "Adresa magazin";
                StackpanelRefund.Visibility = System.Windows.Visibility.Visible;
            }
            else if (selectedValue == "În contul bancar")
            {
                RefundMethod.Text = "IBAN cont client";
                StackpanelRefund.Visibility = System.Windows.Visibility.Visible;
            }
            else if (selectedValue == string.Empty)
            {
                RefundMethod.Text = string.Empty;
                StackpanelRefund.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                RefundMethod.Text = string.Empty;
                StackpanelRefund.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void ComboboxTicketeRetentie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedValue = selectedItem.Content.ToString();
            if (selectedValue == "Solicitare refund")
            {
                StackpanelRefund.Visibility = System.Windows.Visibility.Collapsed;
                comboboxTipRefund.SelectedIndex = 0;
            }
            else
            {
                StackpanelRefund.Visibility = System.Windows.Visibility.Collapsed;
                comboboxTipRefund.SelectedIndex = 0;
            }
        }

        private void HomeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PrimaryWindow window = System.Windows.Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new FrontPage());
            window.ButtonHome.IsChecked = true;
        }
    }
}
