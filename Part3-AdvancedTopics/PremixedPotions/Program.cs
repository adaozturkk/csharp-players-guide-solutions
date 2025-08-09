Console.WriteLine(CreatePotion(new List<Ingredient> {
    Ingredient.Stardust, Ingredient.EyeshineGem, Ingredient.ShadowGlass, Ingredient.Stardust }));

static Potion CreatePotion(List<Ingredient> ingredients) => ingredients switch
{
    []                                                                                         => Potion.Water,
    [Ingredient.Stardust]                                                                      => Potion.Elixir,
    [Ingredient.Stardust, Ingredient.SnakeVenom]                                               => Potion.Poison,
    [Ingredient.Stardust, Ingredient.DragonBreath]                                             => Potion.Flying,
    [Ingredient.Stardust, Ingredient.ShadowGlass]                                              => Potion.Invisibility,
    [Ingredient.Stardust, Ingredient.EyeshineGem]                                              => Potion.NightSight,
    [Ingredient.Stardust, Ingredient.EyeshineGem, Ingredient.ShadowGlass]                      => Potion.CloudyBrew,
    [Ingredient.Stardust, Ingredient.ShadowGlass, Ingredient.EyeshineGem]                      => Potion.CloudyBrew,
    [Ingredient.Stardust, Ingredient.EyeshineGem, Ingredient.ShadowGlass, Ingredient.Stardust] => Potion.Wraith,
    [Ingredient.Stardust, Ingredient.ShadowGlass, Ingredient.EyeshineGem, Ingredient.Stardust] => Potion.Wraith,
    _ => Potion.Ruined
};

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
    EyeshineGem
}