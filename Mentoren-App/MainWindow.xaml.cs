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
        private void GoToInfo(object sender, RoutedEventArgs e)
        {
            NavigateToPage("Info.xaml");
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            //evl funktion für das Abmelden?
            NavigateToPage("Login.xaml");
        }

        private void Shutdown(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
