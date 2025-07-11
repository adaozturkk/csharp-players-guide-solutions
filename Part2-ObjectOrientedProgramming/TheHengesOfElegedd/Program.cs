Henge[] henges = { new Henge(new Location(0, 0), new Color(89, 12, 131), 'T'),
    new Henge(new Location(1, 0), new Color(143, 48, 161), 'M'),
    new Henge(new Location(2, 0), new Color(240, 24, 79), 'A'),
    new Henge(new Location(3, 0), new Color(246, 215, 141), 'J'),
    new Henge(new Location(4, 0), new Color(70, 179, 165), 'K'),
    new Henge(new Location(5, 0), new Color(46, 109, 146), 'B') };

Crate[] crates = { new Crate(new Location(5, 4)), new Crate(new Location(0, 7)),
    new Crate(new Location(2, 8)), new Crate(new Location(4, 2)) };

Henge current = henges[0]; 

while (true) 
{ 
    Console.Clear(); 
    foreach (Crate target in crates) 
        target.Display(); 
    foreach (Henge henge in henges) 
        henge.Display(); 

    ConsoleKey key = Console.ReadKey(true).Key; 

    if (key == ConsoleKey.Spacebar) 
    { 
        foreach (Crate crate in crates) 
            if (current.Location.X == crate.Location.X && current.Location.Y == crate.Location.Y) 
                crate.IsIntact = false; 
    } 

    if (key == ConsoleKey.UpArrow && current.Location.Y > 0) current.Location.Y--; 
    if (key == ConsoleKey.DownArrow && current.Location.Y < 9) current.Location.Y++;
    if (key == ConsoleKey.LeftArrow && current.Location.X > 0) current.Location.X--;
    if (key == ConsoleKey.RightArrow && current.Location.X < 9) current.Location.X++;
     
    if (key == ConsoleKey.D1) current = henges[0]; 
    if (key == ConsoleKey.D2) current = henges[1]; 
    if (key == ConsoleKey.D3) current = henges[2];
    if (key == ConsoleKey.D4) current = henges[3];
    if (key == ConsoleKey.D5) current = henges[4];
    if (key == ConsoleKey.D6) current = henges[5];
}


public class Location(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
}

public class Color(int r, int g, int b)
{
    public int R { get; } = r;
    public int G { get; } = g;
    public int B { get; } = b;

    public string GetColorText() => $"\e[38;2;{R};{G};{B}m";
}

public class Henge(Location location, Color color, char representation)
{
    public Location Location { get; } = location;
    public Color Color { get; } = color;
    public char Representation { get; } = representation;

    public void Display()
    {
        Console.SetCursorPosition(Location.X, Location.Y);
        Console.Write(Color.GetColorText() + Representation);
    }
}

public class Crate(Location location)
{
    public Location Location { get; } = location;
    public bool IsIntact { get; set; } = true;

    public void Display()
    {
        if (!IsIntact) 
            return;

        Console.SetCursorPosition(Location.X, Location.Y);
        Console.Write("\e[38;2;255;255;255m*");
    }
}