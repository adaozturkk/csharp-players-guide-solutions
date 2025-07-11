Arrow a = new Arrow(Arrowhead.Obsidian, Fletching.TurkeyFeathers, 78);
Console.WriteLine($"Arrowhead={a.Arrowhead} Fletching={a.Fletching} Length={a.Length}cm");
public class Arrow(Arrowhead arrowhead, Fletching fletching, float length)
{
    public Arrowhead Arrowhead { get; } = arrowhead;
    public Fletching Fletching { get; } = fletching;
    public float Length { get; } = length;
}
public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }