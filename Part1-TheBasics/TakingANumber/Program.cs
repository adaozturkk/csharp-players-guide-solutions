// Displays text which should be provided when calling method which
// asks user to enter a number, then returns that number.
static int AskForNumber(string text)
{
    Console.Write(text + " ");
    return int.Parse(Console.ReadLine());
}

// Calls AskForNumber method to get number and checks if that number
// is in the provided range until it is, then returns number.
static int AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {
        int numberInput = AskForNumber(text);
        if (numberInput <= max && numberInput >= min)
            return numberInput;
    }
}