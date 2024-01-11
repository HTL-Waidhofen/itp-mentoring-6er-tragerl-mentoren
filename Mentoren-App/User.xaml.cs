using Microsoft.Identity.Client;
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
    /// Interaktionslogik für User.xaml
    /// </summary>
    public partial class User : Page
    {
        public MainWindow mainWindow = new MainWindow();
        public User()
        {
            
            InitializeComponent();
           
                mainWindow.ShowMenuItems();
                //showMentors(mainWindow.mentorListe); needs List in Main
           
        }

        private void subjectChanged(object sender, SelectionChangedEventArgs e)
        {
            sortMentorsBySubject();
        }
        
        public void sortMentorsBySubject()
        {
           List<Benutzer> sortedMentors = new List<Benutzer>();
           foreach(Benutzer mentor in mainWindow.mentorListe)
           {
            //   foreach (Feacher fach in mentor.Subjects)
                   sortedMentors.Add(mentor);

           }
           showMentors(sortedMentors);
        }
        public void showMentors(List<Benutzer> sortedMentors)
        {
           foreach (Benutzer mentor in sortedMentors)

               MentorOutput.Items.Add(mentor.ToString);
        }

    }
}
