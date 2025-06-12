// Asks user 1 to enter a number in specified range and clears console
int number;

do
{
    Console.Write("User 1, enter a number between 0 and 100: ");
    number = int.Parse(Console.ReadLine());
}
while (number < 0 || number > 100);

Console.Clear();

// Let user 2 to guess that number until it is correct
Console.WriteLine("User 2, guess the number.");
int guess;

do
{
    Console.Write("What is your next guess? ");
    guess = int.Parse(Console.ReadLine());

    if (guess > number)
        Console.WriteLine($"{guess} is too high.");
    else if (guess < number)
        Console.WriteLine($"{guess} is too low.");
}
while (guess != number);

Console.WriteLine("You guessed the number!");