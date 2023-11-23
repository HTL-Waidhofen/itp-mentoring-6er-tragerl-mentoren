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
using System.Collections;
using System.Threading.Channels;
using System.ComponentModel;

public class User
{
	public int ID { get; }
	public string FName { get; }
    public string Name { get; }
	public string Password { get; set; }
    public string Email { get; set; }
    public Functions allowed {  get; set; }

    User()
    {
    }
    bool isAdmin(Functions allowed)
    {     
        if(allowed.Admin == true) 
         return true;         
        else         
            return false;        
    }
    bool isMentor(Functions allowed)
    {
        if (allowed.Mentor == true)
            return true;
        else
            return false;
    }
    bool isStudent(Functions allowed)
    {
        if (allowed.Student == true)
            return true;
        else
            return false;
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
