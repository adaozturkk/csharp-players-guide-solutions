Console.Title = "Defense of Consolas";

// Gets target row and column from user
Console.Write("Target Row? ");
int targetRow = int.Parse(Console.ReadLine());

Console.Write("Target Column? ");
int targetColumn = int.Parse(Console.ReadLine());


// Display the places to deploy with unique colors for each and a beep sound
Console.WriteLine("Deploy to:");

Console.ForegroundColor = ConsoleColor.Red;
string bottomPlace = $"({targetRow}, {targetColumn - 1})";
Console.WriteLine(bottomPlace);

Console.ForegroundColor = ConsoleColor.Blue;
string leftPlace = $"({targetRow - 1}, {targetColumn})";
Console.WriteLine(leftPlace);

Console.ForegroundColor = ConsoleColor.Yellow;
string abovePlace = $"({targetRow}, {targetColumn + 1})";
Console.WriteLine(abovePlace);

Console.ForegroundColor = ConsoleColor.Green;
string rightPlace = $"({targetRow + 1}, {targetColumn})";
Console.WriteLine(rightPlace);

Console.Beep();
Console.ForegroundColor = ConsoleColor.Gray;