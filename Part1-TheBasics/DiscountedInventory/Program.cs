// Asks user to select a number and their name
Console.WriteLine("The following items are available: ");
Console.WriteLine("1 – Rope");
Console.WriteLine("2 – Torches");
Console.WriteLine("3 – Climbing Equipment");
Console.WriteLine("4 – Clean Water");
Console.WriteLine("5 – Machete");
Console.WriteLine("6 – Canoe");
Console.WriteLine("7 – Food Supplies");

Console.Write("What number do you want to see the price of? ");
int number = int.Parse(Console.ReadLine());

Console.Write("What is your name? ");
string name = Console.ReadLine();

// Matches costs and items according to number
string item = "";
int cost = 0;

switch (number)
{
    case 1:
        item = "Rope";
        cost = 10;
        break;
    case 2:
        item = "Torches";
        cost = 15;
        break;
    case 3:
        item = "Climbing Equipment";
        cost = 25;
        break;
    case 4:
        item = "Clean Water";
        cost = 1;
        break;
    case 5:
        item = "Machete";
        cost = 20;
        break;
    case 6:
        item = "Canoe";
        cost = 200;
        break;
    case 7:
        item = "Food Supplies";
        cost = 1;
        break;
}

// Applys a special discount according to name and displays result
if (name == "Ada" || name == "ada")
    cost /= 2;

Console.WriteLine($"{item} costs {cost} gold.");