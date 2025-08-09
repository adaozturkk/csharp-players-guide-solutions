// Get valid values from user based on type.

bool validInt;
do
{
    Console.Write("Enter integer: ");
    string? intInput = Console.ReadLine();
    validInt = int.TryParse(intInput, out int num);
}
while (!validInt);

bool validDouble;
do
{
    Console.Write("Enter number: ");
    string? numberInput = Console.ReadLine();
    validDouble = double.TryParse(numberInput, out double num2);
}
while (!validDouble);

bool validBool;
do
{
    Console.Write("Enter true or false: ");
    string? boolInput = Console.ReadLine();
    validBool = bool.TryParse(boolInput, out bool boolean);
}
while (!validBool);