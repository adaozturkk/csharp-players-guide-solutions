// Asks user type of product and gets answer as input
Console.WriteLine("What kind of thing are we talking about?");
string a = Console.ReadLine();

// Asks user a quantifier about it and gets answer as input
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
string b = Console.ReadLine();

// Constants to complete name
string c = "Doom"; // Deleted of from begining to fix repetition
string d = "3000";

Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!");