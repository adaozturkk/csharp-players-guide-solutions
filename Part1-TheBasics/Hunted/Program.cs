// Display array with moving the first element at the end, and showing the rest in order continuously.
int[] brightness = [4, 8, 15, 16, 23, 42];

while (true)
{
    Console.WriteLine(brightness[0]);
    brightness = [.. brightness[1..], brightness[0]];
}