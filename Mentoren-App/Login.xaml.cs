using System;
using System.Collections.Generic;
using System.Data;
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
using Microsoft.Data.SqlClient;
using System.Data.SQLite;
using System.Configuration;
using Mentoren_App;
using System.Diagnostics.Eventing.Reader;

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
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.HideMenuItems();
            }
        }

        private void LogUserIn(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            foreach (var user in mainWindow.allUsers)
            {
                string pwd = LoginPwd.Password.ToString();
                if (user.isLoginDataCorrect(LoginMail.Text, pwd))
                    mainWindow.currentUser = user;
            }
            if (mainWindow.currentUser.Role != null)
            {
                if (mainWindow.currentUser.Role.Contains('s'))
                    NavigationService?.Navigate(new Uri("User.xaml", UriKind.Relative));
                else if (mainWindow.currentUser.Role.Contains('m'))
                    NavigationService?.Navigate(new Uri("Mentoren.xaml", UriKind.Relative));
                else if (mainWindow.currentUser.Role.Contains('a'))
                    NavigationService?.Navigate(new Uri("Admin.xaml", UriKind.Relative));
            }
            else
                MessageBox.Show("Ein Fehler ist aufggetreten. Bitte kontrollieren sie ihre Eingaben. Wenn sie noch nicht registriert sind klicken sie auf 'Registrieren'", "Fehler bei Verarbeitung", MessageBoxButton.OK);
        }
        public void GoToRegistration(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));
        }

    }
}