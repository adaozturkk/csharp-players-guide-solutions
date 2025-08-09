using System.Dynamic;

int id = 1;

while (true)
{
    dynamic robot = new ExpandoObject();
    robot.ID = id++;

    Console.WriteLine($"You are producting robot #{robot.ID}.");

    // Decide robot's name.
    Console.Write("Do you want to name this robot? ");
    string? nameChoice = Console.ReadLine();

    if (nameChoice == "yes")
    {
        Console.Write("What is its name? ");
        string? name = Console.ReadLine();
        robot.Name = name;
    }

    // Decide robot's size.
    Console.Write("Does this robot have a specific size? ");
    string? sizeChoice = Console.ReadLine();

    if (sizeChoice == "yes")
    {
        Console.Write("What is its height? ");
        string? height = Console.ReadLine();
        robot.Height = height;

        Console.Write("What is its width? ");
        string? width = Console.ReadLine();
        robot.Width = width;
    }

    // Decide robot's color.
    Console.Write("Does this robot need to be a specific color? ");
    string? colorChoice = Console.ReadLine();

    if (colorChoice == "yes")
    {
        Console.Write("What color? ");
        string? color = Console.ReadLine();
        robot.Color = color;
    }

    // Display robot properties.
    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
        Console.WriteLine($"{property.Key}: {property.Value}");
}