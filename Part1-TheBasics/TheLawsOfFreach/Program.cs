int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

// Finds smallest value of array and displays
int currentSmallest = int.MaxValue;

foreach (int number in array)
{
    if (number < currentSmallest)
        currentSmallest = number;
}

Console.WriteLine($"Smallest value: {currentSmallest}");

// Finds average value of array and displays
int total = 0;

foreach (int number in array)
    total += number;

float average = (float)total / array.Length;

Console.WriteLine($"Average: {average}");