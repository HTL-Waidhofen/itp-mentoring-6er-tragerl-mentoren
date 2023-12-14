using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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

namespace Mentoren_App
{
    /// <summary>
    /// Interaktionslogik für User.xaml
    /// </summary>
    public partial class User : Page
    {
        public User()
        {
            InitializeComponent();
        }

        private void SendEmail_Click(object sender, RoutedEventArgs e)
        {
            try {
                string fromMail = "ana.pop@htlwy.at";

                using (var smtpClient = new SmtpClient("smtp-mail.outlook.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromMail, "Funny_Bunny11");
                    smtpClient.EnableSsl = true;


                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(fromMail);
                        mailMessage.Subject = Betreff_TB.Text;
                        mailMessage.Body = EmailContent_TB.Text;
                        mailMessage.IsBodyHtml = true;
                        mailMessage.To.Add(LoginMail_TB.Text);

                        smtpClient.Send(mailMessage);
                    }
                }

                MessageBox.Show("E-Mail wurde erfolgreich gesendet.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Senden der E-Mail: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
