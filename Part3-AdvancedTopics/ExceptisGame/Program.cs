try
{
    Random random = new Random();
    int randomNumber = random.Next(0, 10);

    List<int> numbers = new List<int>();

    while (true)
    {
        Console.Write("Enter number between 0 to 9: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (numbers.Contains(number))
            Console.WriteLine("This number guessed before.");
        else
            numbers.Add(number);

        if (number == randomNumber)
        {
            throw new Exception();
        }
    }
}
catch (Exception)
{
    Console.WriteLine("You picked the wrong one. You lose!");
}