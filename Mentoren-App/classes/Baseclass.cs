﻿using System;

public abstract class Base
{
	int ID { get; }
	string FName { get; }
	string Name { get; }
	string Role { get; set; }
	string Password { get; set; }
    string Email { get; set; }
	public Base()
	{
	}
	public bool LoginSucess(string fname, string name, string password, list<Base> list)
	{
        foreach (Base user in list)
        {
            if (fname == user.FName)
            {
                if (name == user.Name) 
                {
                    if (password == user.Password)
                    {
                        return true
                    } 
                }
            }
        }
        return false;
    }
}
