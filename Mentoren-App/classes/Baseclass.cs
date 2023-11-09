using System;

public abstract class User
{
	int ID { get; }
	string FName { get; }
	string Name { get; }
	string Role { get; set; }
	string Password { get; set; }
    string Email { get; set; }
    bool Admin { get; set; }
    bool Mentor { get; set; }
    bool Student {  get; set; }
	public Base()
	{
	}
	public bool LoginSucess(string email, string password, list<Base> list)
	{
        foreach (Base user in list)
        {
            if (email == user.Email)
            {
                if (password == user.Password) 
                {
                        return true                 
                }
            }
        }
        return false;
    }
}
