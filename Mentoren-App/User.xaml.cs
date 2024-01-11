﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
//using System.classes.facher;


namespace Mentoren_App
{
    /// <summary>
    /// Interaktionslogik für User.xaml
    /// </summary>
    public partial class User : Page
    {
        public User()
        {
            InitializeComponent();
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.ShowMenuItems();
            }
       

        private void GoToEmailPage(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("SendEmail.xaml", UriKind.Relative));
        }

        /*
        public void sortMentorsBySubject(List<Benutzer> allMentors)

        {
            //idk why aber Faecher gibts nicht.
            /*List<Faecher> subject = new List<Faecher>();
            foreach (var faecher in subject)
            {
                subject.Add(faecher.Name);
            }*/
        }
        /*
public void sortMentorsBySubject(List<Benutzer> allMentors)
{
   List<Benutzer> sortedMentors = new List<Benutzer>;
   foreach(Benutzer mentor in allMentors)
   {
       foreach (Feacher fach in mentor.Subjects)
           sortedMentors.Add(mentor);

   }
   showMentors(sortedMentors);
}
public void showMentors(List<Benutzer> sortedMentors)
{
   foreach (Benutzer mentor in sortedMentors)

       mentorOutput.Items.Add(mentor.ToString);
}*/

                mentorOutput.Items.Add(mentor.ToString);
        }*/
    }
}

