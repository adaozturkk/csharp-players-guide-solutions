Countdown(10);

// Starting from parameter number, counts down to 0 (exclusive) recursively and prints number
void Countdown (int number)
{
    if (number == 0)
        return;

    Console.WriteLine(number);
    Countdown(number - 1);
}