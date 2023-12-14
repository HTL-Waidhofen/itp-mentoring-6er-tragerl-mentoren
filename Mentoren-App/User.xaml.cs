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
        }

        public void SendEmail_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("zaunersilke21@gmail.com");
               
                mail.To.Add(LoginMail_TB.Text);
                mail.Subject = Betreff_TB.Text;
                mail.Body = EmailContent_TB.Text;

              
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                string psw = passwordbx.Password;
               

                SmtpServer.Credentials = new System.Net.NetworkCredential("zaunersilke21@gmail.com", psw);

                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

