using System;
using System.Collections.Generic;

public class Base
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
