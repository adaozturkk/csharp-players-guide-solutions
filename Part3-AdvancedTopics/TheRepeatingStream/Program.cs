RecentNumbers numbers = new RecentNumbers() { Number1 = -1, Number2 = -1 };
Thread thread = new Thread(GenerateNumbers);
thread.Start(numbers);

Console.WriteLine("Press any key to check for repeat last 2 numbers.");

while (true)
{
    Console.ReadKey(true);

    lock(numbers)
    {
        if (numbers.Number1 < 0 || numbers.Number2 < 0)
        {
            Console.WriteLine("Not enough numbers yet.");
            continue;
        }

        if (numbers.Number1 == numbers.Number2)
            Console.WriteLine("You correctly identified the repeat!");
        else
            Console.WriteLine("You got it wrong!");
    }
}

void GenerateNumbers(object? obj)
{
    Random random = new();
    RecentNumbers recentNumbers = (RecentNumbers)obj;

    while (true)
    {
        int newNumber = random.Next(10);
        Console.WriteLine(newNumber);

        lock(recentNumbers)
        {
            recentNumbers.Number2 = recentNumbers.Number1;
            recentNumbers.Number1 = newNumber;
        }

        Thread.Sleep(1000);
    }
}

public class RecentNumbers
{
    public int Number1 { get; set; }
    public int Number2 { get; set; }
}