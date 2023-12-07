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

            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpBenutzername = "";
            string smtpPasswort = "";

            string absenderEmail = LoginMail_TB.Text;
            string empfaengerEmail = "";
            string betreff = Betreff_TB.Text;
            string text = EmailContent_TB.Text;

            // Erstellen der MailMessage

            MailMessage mailNachricht = new MailMessage(absenderEmail, empfaengerEmail, betreff, text);

            // Erstellen des SmtpClients und Senden der E-Mail

            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.Credentials = new NetworkCredential(smtpBenutzername, smtpPasswort);
            smtpClient.EnableSsl = true;

            smtpClient.Send(mailNachricht);

            MessageBox.Show("E-Mail wurde erfolgreich gesendet.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
        }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Senden der E-Mail: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }

}
    }
}
