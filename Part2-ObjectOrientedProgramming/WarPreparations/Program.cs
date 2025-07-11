// Create 3 different swords and display each of them with their characteristics.
Sword original = new Sword(Material.Iron, Gemstone.None, 25m, 2.5m);
Sword sword1 = original with { Gemstone = Gemstone.Emerald };
Sword sword2 = original with { Material = Material.Steel, Gemstone = Gemstone.Sapphire };

Console.WriteLine(original);
Console.WriteLine(sword1);
Console.WriteLine(sword2);

public enum Material
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium
}

public enum Gemstone
{
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone,
    None
}

public record Sword(Material Material, Gemstone Gemstone, decimal Length, decimal CrossguardWidth);