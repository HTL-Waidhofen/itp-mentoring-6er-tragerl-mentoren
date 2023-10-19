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
public abstract class Base
{
	public int ID { get; }
	public string FName { get; }
    public string Name { get; }
	public string Role { get; set; }
	public string Password { get; set; }
    public string Email { get; set; }
	public Base()
	{
	}
	public bool LoginSucess(string email, string password, List<Base> list)
	{
        foreach (Base user in list)
        {
            if (email == user.Email)
            {
                if (password == user.Password) 
                {
                    return true;                 
                }
            }
        }
        return false;
    }
}
