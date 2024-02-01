using Microsoft.Identity.Client;
using System;
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
using System.Collections.Immutable;
//using System.classes.facher;

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
            mainWindow.writeBenuterToListBox(mainWindow.mentorListe, MentorOutput);  
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
               MentorOutput.Items.Add(mentor.ToString());
        }
        public void showUserInfo(Benutzer user)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.MentorMail = user.Email.ToString();
            nameBox.Text = user.Vorname + " " + user.Nachname;
            idBox.Text = user.ID.ToString();
            mailBox.Text = user.Email;
            roleBox.Text = user.Role;
        }

        private void mentorSelected(object sender, SelectionChangedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            char idChar = MentorOutput.SelectedItem.ToString().ElementAt(0);
            int id = int.Parse(idChar.ToString());
            showUserInfo(mainWindow.GetBenutzerByID(id));
        }

        #region sendEmail
        public void SendEmail_Click(object sender, RoutedEventArgs e)
        {
            recipientEmail.Text = mailBox.Text;
            if (Subject.Text == "")
            {
                Subject.Background = Brushes.Red;
                MessageBox.Show("Fülle alle Felder aus");
            }
            else if (EmailBody.Text == "")
            {
                EmailBody.Background = Brushes.Red;
                MessageBox.Show("Fülle alle Felder aus");
            }
            else
            {
                EmailBody.Background = Brushes.White;
                Subject.Background = Brushes.White;
                try
                {
                    //Listbox
                    string fromMail = "";

                    using (var smtpClient = new SmtpClient("smtp-mail.outlook.com"))
                    {
                        smtpClient.Port = 587;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(fromMail, "");
                        smtpClient.EnableSsl = true;

                        using (var mailMessage = new MailMessage())
                        {
                            mailMessage.From = new MailAddress(fromMail);
                            mailMessage.Subject = Subject.Text;
                            mailMessage.Body = EmailBody.Text;
                            mailMessage.IsBodyHtml = true;
                            mailMessage.To.Add(recipientEmail.Text);
                            smtpClient.Send(mailMessage);
                        }
                    }
                    MessageBox.Show("E-Mail wurde erfolgreich gesendet.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
                    recipientEmail.Text = "";
                    Subject.Text = "";
                    EmailBody.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Email konnte nicht gesendet werden");
                }
            }
        }
        #endregion
    }
}

