using System;
using System.Collections.Generic;

public class Mentor : Base
{
	List<string> students { get; set; }
	
	public Mentor()
	{
		Role = "mentor";
	}
}
