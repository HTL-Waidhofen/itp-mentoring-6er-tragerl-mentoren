using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaktionslogik für Registrierung.xaml
    /// </summary>
    public partial class Registrierung : Page
    {
        public Registrierung()
        {
            InitializeComponent();
        }

        private void RegistrateUser(object sender, RoutedEventArgs e)
        {
            //Registrierungsfunktion
            if(IsValidEmail(Mail.Text.ToString()) == false)
            {
                MessageBox.Show("Ihre Email hat ein falsches Format. Bitte überprüfen sie ihre Eingabe", "Fehler bei Email", MessageBoxButton.OK);
            }
            else if (AreFieldsFilled() == false)
            {
                MessageBox.Show("Nicht alle Felder sind ausgefüllt.","Fehler bei Eingabe" ,MessageBoxButton.OK);
            }
            else if (PwAreEqual() == false)
            {
                MessageBox.Show("Die Passwörter stimmen nich überein oder besitzen keine Großbchstaben/Zahlen", "Felher bei Passwort", MessageBoxButton.OK);
            }
            else
            {          
                //Crud Funktion für Benutzer erstellen
                MessageBox.Show("Registrierung wurde verarbeitet. Sie können sich nun einloggen.", "Registrierung", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.Navigate(new Uri("Login.xaml", UriKind.Relative));
                
            }
        }
        public bool IsValidEmail(string email)
        {

            string pat = "(@htlwy.at){1}$";
            Regex mailPat = new Regex(pat);
            MatchCollection matchCollection = mailPat.Matches(email);
            if (matchCollection.Count == 1)
            {
                return true;
            }
            else
                return false;
        }

        public bool AreFieldsFilled()
        {
            List<Control> fields = new List<Control>();
            fields.Add(VName);
            fields.Add(NName);
            fields.Add(Mail);

            bool isFilled = true;
            SolidColorBrush brightRedBrush = new SolidColorBrush(Colors.IndianRed);
            SolidColorBrush whiteBrush = new SolidColorBrush(Colors.White);

            foreach (TextBox field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    field.Background = brightRedBrush;
                    isFilled = false;
                    break; // exit the loop on the first empty field
                }
                else
                {
                    field.Background = whiteBrush;
                }
            }
            if (isFilled == false)
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus", "Felder ausfüllen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           // Schüler Mentor
            return isFilled;
        }

        public bool IsNameCorrect()
        {
            string[] names = Mail.Text.Split('@');

            string[] seperatedNames = names[0].Split(".");

            if (VName.Text == seperatedNames[0] && NName.Text == seperatedNames[1])
                return true;

            MessageBox.Show("Ihr Vor- und Nachname soll gleich denen in der Email sein", "Inkorrekter Name", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;
        }
        public bool PwAreEqual()
        {
            string pw = pwd.Password.ToString();
            string verPw = pwdBestaetigt.Password.ToString();
            string pat = "[1,2,3,4,5,6,7,8,9,0][A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z]";
            Regex pwdPat = new Regex(pat);
            MatchCollection pwdCol = pwdPat.Matches(pw);
            
            if(pw.Equals(verPw) && pwdCol.Count() == 1)
                return true;

            return false;
        }
    }
}
