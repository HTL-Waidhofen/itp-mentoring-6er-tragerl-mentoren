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
            string smtpBenutzername = "zaunersilke21@gmail.at";
            string smtpPasswort = "";

            // E-Mail-Einstellungen
            string absenderEmail = "silke.zauner@htlwy.at";
            string empfaengerEmail = "anappp73@gmail.com";
            string betreff = "Test E-Mail";
            string text = "Dies ist eine Test-E-Mail.";

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
