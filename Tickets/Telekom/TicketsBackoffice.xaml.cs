using Asgard.Repositories;
using Asgard.ViewModels;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Media;
using System.Security.Authentication;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Asgard.Tickets.Telekom
{
    /// <summary>
    /// Interaction logic for TicketsBackoffice.xaml
    /// </summary>
    public partial class TicketsBackoffice : Page
    {
        public TicketsBackoffice()
        {
            InitializeComponent();
        }

        private void Text_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new MainViewModel();
            string email = user.CurrentUserAccount.Email.ToString();
            string emailAddress = "asgard@optimacall.ro";
            string password = "Optima#321";


            if (comboboxTickete.Text == "Exceptare plata depozit")
            {
                if (codAgent.Text == "" || idCerere.Text == "" || etichetaRisk.Text == "")
                {

                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Nu ai completat toate câmpurile";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else if (!idCerere.Text.StartsWith("18"))
                {

                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Informare";
                        dialog.Status.Text = "Informare";
                        dialog.Descriere.Text = "ID-ul cererii trebuie sa inceapa cu 18";
                    };
                    dialog.ShowDialog();
                }
                else
                {

                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("tickete.telekom@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("telekom1@optimacall.ro"));
                    // message.To.Add(MailboxAddress.Parse("cristian.ilie@telekom.ro"));
                    //message.To.Add(MailboxAddress.Parse("elena.leonte@telekom.ro"));
                    // message.To.Add(MailboxAddress.Parse("TKRM.monitorizare_credit.ROU02@telekom.ro"));

                    message.Subject = "Exceptarea plații depozit/avans cerere: " + idCerere.Text;
                    message.Body = new TextPart("plain")
                    {
                        Text = @"Bună, " + "\r\n" + "\r\n" +
                        "Vă rog sa ma ajutați cu exceptarea plații depozitului avans pentru cererea: " + idCerere.Text + " Etichetă Risc: " +
                        etichetaRisk.Text + "\r\n" + "\r\n" + "Vă mulțumesc, " + "\r\n" + "Alexandru Puiu"
                    };

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
            else if (comboboxTickete.Text == "Anulare cereri la curier RPA")
            {
                if (codAgent.Text == "" || idSursa.Text == "")
                {

                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Nu ai completat toate câmpurile";
                        dialog.Descriere.Text = "Ticket-ul nu a putut fi trimis, verifică toate câmpurile înainte de a reîncerca";
                    };
                    dialog.ShowDialog();
                }
                else if (!idSursa.Text.StartsWith("10"))
                {

                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Informare";
                        dialog.Status.Text = "Informare";
                        dialog.Descriere.Text = "ID-ul sursă trebuie să înceapă cu 10";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("tickete.telekom@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("telekom2@optimacall.ro"));


                    //message.To.Add(MailboxAddress.Parse("florentina.popazu@telekom.ro"));
                    //message.To.Add(MailboxAddress.Parse("laurentiu.ifrim@telekom.ro"));
                    //message.To.Add(MailboxAddress.Parse("cristian.ilie@telekom.ro"));

                    message.Subject = "Anulare cerere la curier RPA : " + idSursa.Text;
                    message.Body = new TextPart("plain")
                    {
                        Text = @"Bună, " + "\r\n" + "\r\n" +
                        "Rog anulare cerere urgentă: " + idSursa.Text + "\r\n" + "\r\n" + "Vă mulțumesc, " + "\r\n" + "Alexandra Puiu"
                    };

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
            else if (comboboxTickete.Text == "Anulare cerere cu echipament Curier DPD/URGENT CARGUS")
            {
                if (codAgent.Text == "" || idSursa.Text == "")
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
                else if (!idSursa.Text.StartsWith("10"))
                {

                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Informare";
                        dialog.Status.Text = "Informare";
                        dialog.Descriere.Text = "ID-ul sursă trebuie să înceapă cu 10";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    if (comboboxAWB.Text == "DA")
                    {
                        if (awb.Text == "")
                        {

                            CustomControls.Prompt dialog = new CustomControls.Prompt();
                            dialog.Loaded += (s, ea) =>
                            {
                                dialog.Descriere.Text = "Nu ai completat AWB-ul";
                            };
                            dialog.ShowDialog();
                        }
                        else
                        {
                            MimeMessage message = new MimeMessage();
                            message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                            message.To.Add(MailboxAddress.Parse("tickete.telekom@optimacall.ro"));
                            message.To.Add(MailboxAddress.Parse("telekom3@optimacall.ro"));


                            //message.To.Add(MailboxAddress.Parse("rodica_paun@telekom.ro"));
                            // message.To.Add(MailboxAddress.Parse("cristian.ilie@telekom.ro"));
                            // message.To.Add(MailboxAddress.Parse("elena.leonte@telekom.ro"));

                            message.Subject = "Anulare ID sursă: " + idSursa.Text + " AWB: " + awb.Text;
                            message.Body = new TextPart("plain")
                            {
                                Text = @"Bună, " + "\r\n" + "\r\n" +
                                "Rog anulare ID sursă: " + idSursa.Text + " AWB: " + awb.Text + "\r\n" + "\r\n" + "Vă mulțumesc, " + "\r\n" + "Alexandra Puiu"
                            };

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
                    else
                    {
                        MimeMessage message = new MimeMessage();
                        message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                        message.To.Add(MailboxAddress.Parse("tickete.telekom@optimacall.ro"));
                        message.To.Add(MailboxAddress.Parse("telekom3@optimacall.ro"));


                        //message.To.Add(MailboxAddress.Parse("rodica_paun@telekom.ro"));
                        //message.To.Add(MailboxAddress.Parse("cristian.ilie@telekom.ro"));
                        //message.To.Add(MailboxAddress.Parse("elena.leonte@telekom.ro"));

                        message.Subject = "Anulare ID sursă: " + idSursa.Text;
                        message.Body = new TextPart("plain")
                        {
                            Text = @"Bună, " + "\r\n" + "\r\n" +
                            "Rog anulare ID sursă: " + idSursa.Text + "\r\n" + "\r\n" + "Vă mulțumesc, " + "\r\n" + "Alexandra Puiu"
                        };

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
            else if (comboboxTickete.Text == "Urgentare cerere cu echipament Curier DPD/URGENT CARGUS")
            {
                if (codAgent.Text == "" || idSursa.Text == "")
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
                else if (!idSursa.Text.StartsWith("10"))
                {

                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Informare";
                        dialog.Status.Text = "Informare";
                        dialog.Descriere.Text = "ID-ul sursă trebuie să înceapă cu 10";

                    };
                    dialog.ShowDialog();
                }
                else
                {
                    if (comboboxAWB.Text == "DA")
                    {
                        if (awb.Text == "")
                        {

                            CustomControls.Prompt dialog = new CustomControls.Prompt();
                            dialog.Loaded += (s, ea) =>
                            {
                                dialog.Title = "Eroare";
                                dialog.Status.Text = "Eroare la AWB";
                                dialog.Descriere.Text = "Nu ai completat AWB-ul";

                            };
                            dialog.ShowDialog();
                        }
                        else
                        {
                            MimeMessage message = new MimeMessage();
                            message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                            message.To.Add(MailboxAddress.Parse("tickete.telekom@optimacall.ro"));
                            message.To.Add(MailboxAddress.Parse("telekom3@optimacall.ro"));

                            //message.To.Add(MailboxAddress.Parse("rodica_paun@telekom.ro"));
                            //message.To.Add(MailboxAddress.Parse("cristian.ilie@telekom.ro"));
                            //message.To.Add(MailboxAddress.Parse("elena.leonte@telekom.ro"));
                            message.Subject = "Urgentare ID sursă: " + idSursa.Text + " AWB: " + awb.Text;
                            message.Body = new TextPart("plain")
                            {
                                Text = @"Bună, " + "\r\n" + "\r\n" +
                                "Rog urgentare ID sursă: " + idSursa.Text + " AWB: " + awb.Text + "\r\n" + "\r\n" + "Vă mulțumesc, " + "\r\n" + "Alexandra Puiu"
                            };

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
                    else if (comboboxAWB.Text == "NU")
                    {
                        MimeMessage message = new MimeMessage();
                        message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                        message.To.Add(MailboxAddress.Parse("tickete.telekom@optimacall.ro"));
                        message.To.Add(MailboxAddress.Parse("telekom3@optimacall.ro"));

                        //message.To.Add(MailboxAddress.Parse("rodica_paun@telekom.ro"));
                        //message.To.Add(MailboxAddress.Parse("cristian.ilie@telekom.ro"));
                        //message.To.Add(MailboxAddress.Parse("elena.leonte@telekom.ro"));
                        message.Subject = "Urgentare ID sursă: " + idSursa.Text;
                        message.Body = new TextPart("plain")
                        {
                            Text = @"Bună, " + "\r\n" + "\r\n" +
                            "Rog urgentare ID sursă: " + idSursa.Text + "\r\n" + "\r\n" + "Vă mulțumesc, " + "\r\n" + "Alexandra Puiu"
                        };

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
            else if (comboboxTickete.Text == "Schimbare adresa livrare Curier DPD/URGENT CARGUS")
            {
                if (codAgent.Text == "" || idSursa.Text == "" || comboboxAWB.Text == "")
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
                else if (!idSursa.Text.StartsWith("10"))
                {

                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Informare";
                        dialog.Status.Text = "Informare";
                        dialog.Descriere.Text = "ID-ul sursă trebuie să înceapă cu 10";
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("tickete.telekom@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("telekom3@optimacall.ro"));


                    //message.To.Add(MailboxAddress.Parse("rodica_paun@telekom.ro"));
                    // message.To.Add(MailboxAddress.Parse("cristian.ilie@telekom.ro"));
                    // message.To.Add(MailboxAddress.Parse("elena.leonte@telekom.ro"));
                    message.Subject = "Schimbare adresă livrare ID sursă: " + idSursa.Text + " AWB: " + awb.Text;
                    message.Body = new TextPart("plain")
                    {
                        Text = @"Bună, " + "\r\n" + "\r\n" +
                        "Rog livrare colet ID sursă: " + idSursa.Text + " AWB: " + awb.Text + " către adresa: " + schimbareAdresa.Text + " Număr contact: " + numarContact.Text + "\r\n" + "\r\n" + "Vă mulțumesc, " + "\r\n" + "Alexandra Puiu"
                    };

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
            else if (comboboxTickete.Text == "Urgentare incident")
            {
                if (codAgent.Text == "" || idIncident.Text == "")
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
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("tickete.telekom@optimacall.ro"));
                    message.Subject = "Urgentare incident: " + idIncident.Text;
                    message.Body = new TextPart("plain")
                    {
                        Text = @"Bună, " + "\r\n" + "\r\n" +
                        "Rog urgentare incident: " + idIncident.Text + "\r\n" + "\r\n" + "Vă mulțumesc, " + "\r\n" + "Backoffice"
                    };

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
            else if (comboboxTickete.Text == "Ticket de semnal")
            {
                if (codAgent.Text == "" || adresaSemnal.Text == "" || dataProblemeSemnal.Text == "" || comboboxIndoorOutdoor.Text == "" || dataUltimaData.Text == "" || numarClient.Text == "" || descriereProblemaSemnal.Text == "")
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
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                    message.To.Add(MailboxAddress.Parse("tickete.telekom@optimacall.ro"));
                    message.Subject = "Ticket probleme semnal: " + numarClient.Text;
                    message.Body = new TextPart("plain")
                    {
                        Text = @"Bună, " + "\r\n" + "\r\n" +
                        "Place Bria: " + codAgent.Text + "\r\n" +
                        "Adresa la care clientul nu are semnal (  Localitate, Judet , strada , numar ): " + adresaSemnal.Text + "\r\n" +
                        "Data de cand clientul are probleme cu semnalul: " + dataProblemeSemnal.Text + "\r\n" +
                        "Problema este indoor/outdoor (indoor - intr-o incapere / outdoor  - inafara incaperii): " + comboboxIndoorOutdoor.Text + "\r\n" +
                        "Cand a fost ultima data cand clientul si-a schimbat cartela ?: " + dataUltimaData.Text + "\r\n" +
                        "Numarul pe care clientul intampina problema cu semnalul: " + numarClient.Text + "\r\n" +
                        "Numar de contact pe care colegii de la tehnic sa il contacteze: " + numarClientContact.Text + "\r\n" +
                        "Detalii despre problema intampinata: " + descriereProblemaSemnal.Text + "\r\n" +
                        "\r\n" + "Vă mulțumesc, " + "\r\n" + "Backoffice"
                    };

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

        private void comboboxTickete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void comboboxAWB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var user = new MainViewModel();
            string bria = user.CurrentUserAccount.ID_Bria.ToString();
            codAgent.Text = bria;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Pages.FrontPage());
        }

        private void TicketeButton_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Tickets.TicketsTelekom());
        }
    }

}
