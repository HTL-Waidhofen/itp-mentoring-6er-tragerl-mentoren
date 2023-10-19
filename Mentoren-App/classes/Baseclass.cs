using System;

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
}
