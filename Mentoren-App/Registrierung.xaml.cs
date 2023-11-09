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
        }

        private void RegistrateUser(object sender, RoutedEventArgs e)
        {
            //Registrierungsfunktion
            VName.Text = Mail.Text;
            bool isValid = IsValidEmail(Mail.Text.ToString());
            if(isValid == true)
            {
                MessageBox.Show("Ihre Email hat ein falsches Format. Bitte überprüfen sie ihre Eingabe", "Fehler bei Email", MessageBoxButton.OK);
            }
            //MessageBox.Show("Registrierung wurde verarbeitet. Sie können sich nun einloggen.", "Registrierung", MessageBoxButton.OK, MessageBoxImage.Information);
            //NavigationService?.Navigate(new Uri("Login.xaml", UriKind.Relative));
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

            string domainPart = parts[1];
            int dotIndex = domainPart.IndexOf('.');
            if (dotIndex == -1 || dotIndex < 2 || dotIndex >= domainPart.Length - 2)
            {
                return false;
            }

            return true;
        }
    }
}
