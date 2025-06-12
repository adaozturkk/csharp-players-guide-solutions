// Asks user to enter their provinces, duchies, and estates count and stores
Console.WriteLine("How many provinces do you have?");
int provinces = int.Parse(Console.ReadLine());

Console.WriteLine("How many duchies do you have?");
int duchies = int.Parse(Console.ReadLine());

Console.WriteLine("How many estates do you have?");
int estates = int.Parse(Console.ReadLine());

// Calculates total point and displays
int totalScore = estates + 3 * duchies + 6 * provinces;
Console.WriteLine("Total points you have: " + totalScore);