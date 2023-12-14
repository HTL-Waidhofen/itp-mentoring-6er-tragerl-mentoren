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
    /// Interaktionslogik für Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.ShowMenuItems();
                mainWindow.writeBenuterToListBox(mainWindow.testUser, SchuelerList);
                mainWindow.writeBenuterToListBox(mainWindow.testUser, MentorList);
            }
        }
  

        public void showUserInfo(Benutzer user)
        {
            nameBox.Text = user.Vorname + " " + user.Nachname;
            idBox.Text = user.ID.ToString();
            mailBox.Text = user.Email;
            // Benutzerklasse muss Angepasst werden //roleBox.Text = ;
        }

        private void SelectProfile(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
