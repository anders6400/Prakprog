using System;

class constants{
	static void Main(){
		string name;
		int age;
		
		Console.WriteLine("What's your name?");
		name = Console.ReadLine();


		if (!name.Any(char.IsDigit))
			Console.WriteLine("What's your age?");
		else
		{
			Console.WriteLine("Invalid argument");
		}
		
		string userage = Console.ReadLine();
			   	

		try
		{
		age = int.Parse(userage);
		//Printmessage(age);
		if (age<0)
		Console.WriteLine("You can't have a negative age");
		else		
		Console.WriteLine($"Hello {name} you don't look a day older than {age}");
		}
		catch(Exception)
		{
			Console.WriteLine("Your input is not a number");
		}	
		
		
		//Console.WriteLine(age);
		//Console.WriteLine($"Hello {name} you don't look a day older than {age}");
		
	
	}
		
}
