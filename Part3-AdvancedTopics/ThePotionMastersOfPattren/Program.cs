Potion potion = Potion.Water;

do
{
    // Display current potion.
    Console.WriteLine($"You have {potion.ToString().ToLower()} potion.");

    // Let user add an ingredient or finish the potion.
    Console.WriteLine("Available ingredients are stardust, snake venom, dragon breath, shadow glass, eyeshine gem.");
    Console.WriteLine("Pick an ingredient or write 'complete' to complete potion");
    Console.Write("Enter your choice: ");
    string? choice = Console.ReadLine()?.Trim().ToLower();

    if (choice == "complete")
        break;

    Ingredient ingredient = choice switch
    {
        "stardust" => Ingredient.Stardust,
        "snake venom" => Ingredient.SnakeVenom,
        "dragon breath" => Ingredient.DragonBreath,
        "shadow glass" => Ingredient.ShadowGlass,
        "eyeshine gem" => Ingredient.EyeshineGem,
        _ => Ingredient.Unknown
    };

    // Update potion according to ingredient added.
    potion = (potion, ingredient) switch
    {
        (Potion.Water, Ingredient.Stardust) => Potion.Elixir,
        (Potion.Elixir, Ingredient.SnakeVenom) => Potion.Poison,
        (Potion.Elixir, Ingredient.DragonBreath) => Potion.Flying,
        (Potion.Elixir, Ingredient.ShadowGlass) => Potion.Invisibility,
        (Potion.Elixir, Ingredient.EyeshineGem) => Potion.NightSight,
        (Potion.NightSight, Ingredient.ShadowGlass) => Potion.CloudyBrew,
        (Potion.Invisibility, Ingredient.EyeshineGem) => Potion.CloudyBrew,
        (Potion.CloudyBrew, Ingredient.Stardust) => Potion.Wraith,
        _ => Potion.Ruined
    };

    // If potion is ruined, display message and reset potion.
    if (potion is Potion.Ruined)
    {
        Console.WriteLine("Your potion is ruined. You will start over.\n");
        potion = Potion.Water;
        continue;
    }

    Console.WriteLine();
}
while (true);


// Enumeration for potion types.
public enum Potion
{
    Water,
    Elixir,
    Poison,
    Flying,
    Invisibility,
    NightSight,
    CloudyBrew,
    Wraith,
    Ruined
}

// Enumeration for ingredient types.
public enum Ingredient
{
    Stardust,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    EyeshineGem,
    Unknown
}