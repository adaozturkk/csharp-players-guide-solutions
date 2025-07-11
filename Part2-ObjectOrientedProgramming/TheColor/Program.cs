// Display selected color's rgb values.
DisplayColor(new Color(0, 0, 128));
DisplayColor(Color.Yellow);

void DisplayColor(Color color) => Console.WriteLine($"R: {color.R}  G: {color.G}  B: {color.B}");

public class Color(int r, int g, int b)
{
    public int R { get; } = r;
    public int G { get; } = g;
    public int B { get; } = b;

    // Commonly used colors.
    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Orange { get; } = new Color(255, 165, 0);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Green { get; } = new Color(0, 128, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Purple { get; } = new Color(128, 0, 128);
}