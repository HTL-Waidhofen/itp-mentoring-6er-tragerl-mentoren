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
            //Methode für den Login mit Email/ Passwort# mit rückgabe von true/false und ist User/Admin/Mentor
            //Wenn true => Redirect auf Page
            //Redirect auf User /NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));
            //Redirect auf Mentor /NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));
            //Redirect auf Admin /NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));
            string email = "htlwy.at";  //Filler für daten der Datenbank
            string password = "123";
            Functions b = new Functions(true, false, false);

            if(LoginMail.ToString() == email && LoginPwd.ToString() == password)
            {
                if (b.Admin == true)
                    NavigationService?.Navigate(new Uri("Admin.xaml", UriKind.Relative));
                else if (b.Mentor == true)
                    NavigationService?.Navigate(new Uri("Mentoren.xaml", UriKind.Relative));
                else if (b.Student == true)
                    NavigationService?.Navigate(new Uri("User.xaml", UriKind.Relative));      
            }
            else
            {
                if (LoginPwd.ToString() != password)
                    MessageBox.Show("Ihr Passwort ist falsch bitter versuchen sie es erneut");
                else if (LoginMail.ToString() != email)
                    MessageBox.Show("Ihre Email ist falsch bitte versuchen sie es erneut");
                else
                {
                    MessageBox.Show("Sie haben noch kein Konto");
                    NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));

                }

            }

        }

        private void GoToRegistration(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));
        }


    }
}
