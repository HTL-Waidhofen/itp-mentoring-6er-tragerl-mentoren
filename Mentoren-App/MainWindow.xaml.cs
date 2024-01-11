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
        public List<Benutzer> testUser = new List<Benutzer>
            {
                new Benutzer(1, "Max", "Mustermann", "Admin", "max@example.com", "geheimesPasswort1"),
                new Benutzer(2, "Anna", "Musterfrau", "Benutzer", "anna@example.com", "geheimesPasswort2"),
                new Benutzer(3, "Peter", "Pan", "Mentor", "peter@example.com", "geheimesPasswort3"),
                new Benutzer(4, "Lena", "Lustig", "Benutzer", "lena@example.com", "geheimesPasswort4"),
                new Benutzer(5, "Tom", "Tester", "Mentor", "tom@example.com", "geheimesPasswort5"),
                };
        public MainWindow()
        {
            InitializeComponent();
            NavigateToPage("Login.xaml");
        }

        // Navigation Functions
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

        public void Shutdown(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        public void HideMenuItems()
        {
            foreach (var menuItem in Menu.Items)
            {
                
                if (menuItem is MenuItem subMenuItem)
                {
                    if (subMenuItem.Header.ToString() == "Einstellungen" || subMenuItem.Header.ToString() == "Logout" || subMenuItem.Header.ToString() == "Schüler" || subMenuItem.Header.ToString() == "Mentor")
                    {
                        subMenuItem.Visibility = Visibility.Collapsed;

                    }
                }
            }
        }
        public void ShowMenuItems()
        {
            foreach (var menuItem in Menu.Items)
            {
                if (menuItem is MenuItem subMenuItem)
                {
                    if (subMenuItem.Header.ToString() == "Einstellungen" || subMenuItem.Header.ToString() == "Logout")
                    {
                        subMenuItem.Visibility = Visibility.Visible;
                    }
                }
            }
        }
        private void ChangeToUser(object sender, RoutedEventArgs e)
        {
            NavigateToPage("User.xaml");
        }
        private void ChangeToMentor(object sender, RoutedEventArgs e)
        {
            NavigateToPage("Mentoren.xaml");
        }


        //End of Navigation Functions

        /// <summary>
        /// E-Mail validieren
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Schreibt die Benutzer in einem Standardisierten Format in beliebige ListBoxen
        /// </summary>
        /// <param name="user"></param>
        /// <param name="listBox"></param>
        public void writeBenuterToListBox(List<Benutzer> user, ListBox listBox)
        {
            foreach (Benutzer b in user)
            {
                listBox.Items.Add(b.ListBoxFormat());
            }
        }
        public Benutzer GetBenutzerByID(int id) 
        {
            foreach(Benutzer user in testUser)
            {
                if(user.ID == id)
                { return user; }

            }
                return new Benutzer(-1, "N:A", "N:A", string.Empty, "N:A", string.Empty);
        }

    }
}

