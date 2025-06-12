// Creates an array of length 5 and gets its values from user
int[] numbers = new int[5];

for (int i = 0; i < numbers.Length; i++)
{
    Console.Write($"Enter number {i + 1}: ");
    numbers[i] = int.Parse(Console.ReadLine());
}

// Creates a new array which copies original one
int[] copyNumbers = new int[5];

for (int i = 0; i < copyNumbers.Length; i++)
    copyNumbers[i] = numbers[i];

Console.WriteLine();

// Displays both arrays with doing a comparison to show they are same
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Original array: {numbers[i], -10} | Copy array: {copyNumbers[i], -10}");
}