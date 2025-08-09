// Get user's name.
Console.Write("Enter your name: ");
string? name = Console.ReadLine()?.Trim().ToLower();

// If user already created before get their score, otherwise start from 0.
int score = 0;
if (File.Exists(name + ".txt"))
    score = int.Parse(File.ReadAllText(name + ".txt"));

// Until user press Enter key, increment their score by one.
while (true)
{
    ConsoleKey key = Console.ReadKey().Key;

    if (key == ConsoleKey.Enter)
        break;

    score++;

    Console.WriteLine($"\nYour score: {score}");
}

// Write user's score to a file named after their name.
File.WriteAllText(name + ".txt", score.ToString());