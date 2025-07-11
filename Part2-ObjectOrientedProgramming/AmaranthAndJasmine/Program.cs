DisplayHenges();

void DisplayHenges()
{ 
    Henge amaranth = new Henge(new Location(3, 2), new Color(240, 24, 79), 'A');
    Henge jasmine = new Henge(new Location(1, 5), new Color(246, 215, 141), 'J');

    amaranth.Display();
    jasmine.Display();
}


public class Location
{
    public int X { get; set; }
    public int Y { get; set; }

    public Location (int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Color
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    public Color (int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public string GetColorText() => $"\e[38;2;{R};{G};{B}m";
}

public class Henge
{
    public Location Location { get; }
    public Color Color { get; }
    public char Representation { get; }

    public Henge(Location location, Color color, char representation)
    {
        Location = location;
        Color = color;
        Representation = representation;
    }

    public void Display()
    {
        Console.SetCursorPosition(Location.X, Location.Y);
        Console.Write(Color.GetColorText() + Representation);
    }
}