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
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LogUserIn(object sender, RoutedEventArgs e)
        {
            //Methode für den Login mit Email/ Passwort 
            //If true => Redirect to Page
            //Redirect auf User /NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));
            //Redirect auf Mentor /NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));
            //Redirect auf Admin /NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));


            //Output if Login failed
            //if(false == true)
            //MessageBox.Show("Ein Fehler ist aufgetreten. Bitte kontrollieren sie ihre Eingaben. Wenn sie noch nicht registriet sind klicken sie auf 'Registrieren'","Fehler bei Verarbeitung", MessageBoxButton.OK);
        }

        private void GoToRegistration(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));
        }


    }
}
