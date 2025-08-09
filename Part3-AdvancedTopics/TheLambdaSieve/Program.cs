// Get an input from user to choose which action to do.
Console.WriteLine("Select a filter to use.");
Console.WriteLine("1 - Check if even");
Console.WriteLine("2 - Check if positive");
Console.WriteLine("3 - Check if multiples of 10");

bool validInput = false;
int choice = 0;

while (true)
{
    Console.Write("Enter choice (1 to 3): ");
    validInput = int.TryParse(Console.ReadLine(), out choice);

    if (!validInput || choice < 1 || choice > 3)
    {
        Console.WriteLine("Invalid choice.");
        continue;
    }
    else
    {
        break;
    }
}

// Create an instance according to choice.
Sieve sieve = choice switch
{
    1 => new Sieve(n => n % 2 == 0), // Check even number.
    2 => new Sieve(n => n > 0),      // Check positive number.
    3 => new Sieve(n => n % 10 == 0) // Check number multiplies of 10.
};

// Ask number continuously and display it's result.
while (true)
{
    Console.Write("Enter a number: ");
    bool validNumber = int.TryParse(Console.ReadLine(), out int number);

    if (!validNumber)
    {
        Console.WriteLine("Invalid input.");
        continue;
    }

    string text = sieve.IsGood(number) ? "good" : "bad";

    Console.WriteLine($"{number} is {text} number!");
}

public class Sieve
{
    private readonly Func<int, bool> _check;

    public Sieve(Func<int, bool> check)
    {
        _check = check;
    }

    public bool IsGood(int number)
    {
        return _check(number);
    }
}