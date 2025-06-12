// Takes coordinates from user
Console.Write("Enter coordinate x: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Enter coordinate y: ");
int y = int.Parse(Console.ReadLine());

// Displays the enemies position according to coordinate
if (x > 0 && y > 0)
    Console.WriteLine("The enemy is to the north east!");
if (x > 0 && y < 0)
    Console.WriteLine("The enemy is to the south east!");
if (x > 0 && y == 0)
    Console.WriteLine("The enemy is to the east!");
if (x < 0 && y > 0)
    Console.WriteLine("The enemy is to the north west!");
if (x < 0 && y < 0)
    Console.WriteLine("The enemy is to the south west!");
if (x < 0 && y == 0)
    Console.WriteLine("The enemy is to the west!");
if (x == 0 && y > 0)
    Console.WriteLine("The enemy is to the north!");
if (x == 0 && y < 0)
    Console.WriteLine("The enemy is to the south!");
if (x == 0 && y == 0)
    Console.WriteLine("The enemy is here!");