using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaktionslogik für Registrierung.xaml
    /// </summary>
    public partial class Registrierung : Page
    {
        public Registrierung()
        {
            InitializeComponent();
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.HideMenuItems();
            }
        }

        private void RegistrateUser(object sender, RoutedEventArgs e)
        {
            //Registrierungsfunktion
            if(IsValidEmail(Mail.Text.ToString()) == false || AreFieldsFilled() == false || IsNameCorrect() == false)
            {
                MessageBox.Show("Ihre Email hat ein falsches Format. Bitte überprüfen sie ihre Eingabe", "Fehler bei Email", MessageBoxButton.OK);
            }
            else
            {          
                //Crud Funktion für Benutzer erstellen
                MessageBox.Show("Registrierung wurde verarbeitet. Sie können sich nun einloggen.", "Registrierung", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.Navigate(new Uri("Login.xaml", UriKind.Relative));
                
            }
        }
        public bool IsValidEmail(string email)
        {
            if (!email.EndsWith("@htlwy.at"))
            {
                return false;
            }

            string[] parts = email.Split('@');
            if (parts.Length != 2 || string.IsNullOrEmpty(parts[0]) || string.IsNullOrEmpty(parts[1]))
            {
                return false;
            }

            string domainPart = parts[0];
            int dotIndex = domainPart.IndexOf('.');
            if (dotIndex == -1 || dotIndex < 2 || dotIndex >= domainPart.Length - 2)
            {
                return false;
            }

            return true;
        }

        public bool AreFieldsFilled()
        {
            List<Control> fields = new List<Control>();
            fields.Add(VName);
            fields.Add(NName);
            fields.Add(Mail);

            bool isFilled = true;
            SolidColorBrush brightRedBrush = new SolidColorBrush(Colors.IndianRed);
            SolidColorBrush whiteBrush = new SolidColorBrush(Colors.White);
            foreach (TextBox field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    field.Background = brightRedBrush;
                    isFilled = false;
                }
                else
                    field.Background = whiteBrush;
            }
            if (isFilled == false)
                MessageBox.Show("Bitte füllen Sie alle Felder aus", "Felder ausfüllen", MessageBoxButton.OK, MessageBoxImage.Error);
            if (pwd.SecurePassword != pwdBestaetigt.SecurePassword)
            {
                isFilled= false;
                MessageBox.Show("Die Passwörter stimmen nicht überein", "Falsches Passwort", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (pwd.SecurePassword == null)
                pwd.Background = brightRedBrush;
            if (pwdBestaetigt.SecurePassword == null)
                pwd.Background = brightRedBrush;
            
            
            //Schüler Mentor
            return isFilled;
        }

        public bool IsNameCorrect()
        {
            string[] names = Mail.Text.Split('@');

            string[] seperatedNames = names[0].Split(".");

            if (VName.Text == seperatedNames[0] && NName.Text == seperatedNames[1])
                return true;

            MessageBox.Show("Ihr Vor- und Nachname soll gleich denen in der Email sein", "Inkorrekter Name", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;
        }
    }
}
