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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateToPage("Login.xaml");
        }
        public void NavigateToPage(string pageName)
        {
            mainFrame.Navigate(new Uri(pageName, UriKind.Relative));
        }

        private void GoToSettings(object sender, RoutedEventArgs e)
        {
            NavigateToPage("Einstellungen.xaml");
        }
        public void GoToInfo(object sender, RoutedEventArgs e)
        {
            NavigateToPage("Info.xaml");
        }

        public void Logout(object sender, RoutedEventArgs e)
        {
            //evl funktion für das Abmelden?
            NavigateToPage("Login.xaml");
        }

        private void Shutdown(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
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
