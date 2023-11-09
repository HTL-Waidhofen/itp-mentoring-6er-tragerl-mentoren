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
public class User
{
	public int ID { get; }
	public string FName { get; }
    public string Name { get; }
	public string Role { get; set; }
	public string Password { get; set; }
    public string Email { get; set; }
    public list<Functions> Function {  get; set; } 
	public User()
	{
	}
}
public class Functions
{
    public bool Admin { get; set; }
    public bool Student { get; set; }
    public bool Mentor { get; set; }
    //add any other Roles/Functions

    Functions(bool admin = false, bool student = true, bool mentor = false) 
    { 
        Admin = admin;
        Student = student;
        Mentor = mentor;
    }

}
