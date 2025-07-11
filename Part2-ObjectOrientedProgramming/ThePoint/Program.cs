// Display points in coordinate form.
DisplayPoint(new Point(2, 3));
DisplayPoint(new Point(-4, 0));

static void DisplayPoint(Point point) => Console.WriteLine($"({point.X}, {point.Y})");

public class Point(int x = 0, int y = 0)
{
    public int X { get; } = x;
    public int Y { get; } = y;
}