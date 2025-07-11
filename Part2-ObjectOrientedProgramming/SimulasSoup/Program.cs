// Create soup as a tuple and display.
(Type type, MainIngredient ingredient, Seasoning seasoning) soup = GetSoup();

Console.WriteLine($"{soup.type} {soup.ingredient} {soup.seasoning}");

// --------- METHODS ---------

// Combine different soup features and return them as a tuple.
(Type, MainIngredient, Seasoning) GetSoup()
{
    Type type = GetType();
    MainIngredient ingredient = GetMainIngredient();
    Seasoning seasoning = GetSeasoning();

    return (type, ingredient, seasoning);

}

// Return soup's type as enum based on user input.
Type GetType()
{
    Console.Write("Choose a type (soup, stew, gumbo): ");
    string? typeInput = Console.ReadLine()?.ToLower().Trim();

    Type type = typeInput switch
    {
        "soup" => Type.Soup,
        "stew" => Type.Stew,
        "gumbo" => Type.Gumbo
    };

    return type; 
}

// Return soup's main ingredient as enum based on user input.
MainIngredient GetMainIngredient()
{
    Console.Write("Choose a main ingredient (mushroom, chicken, carrot, potato): ");
    string? ingredientInput = Console.ReadLine()?.ToLower().Trim();

    MainIngredient ingredient = ingredientInput switch
    {
        "mushroom" => MainIngredient.Mushroom,
        "chicken" => MainIngredient.Chicken,
        "carrot" => MainIngredient.Carrot,
        "potato" => MainIngredient.Potato
    };

    return ingredient;
}

// Return soup's seasoning as enum based on user input.
Seasoning GetSeasoning()
{
    Console.Write("Choose a seasoning (spicy, salty, sweet): ");
    string? seasoningInput = Console.ReadLine()?.ToLower().Trim();

    Seasoning seasoning = seasoningInput switch
    {
        "spicy" => Seasoning.Spicy,
        "salty" => Seasoning.Salty,
        "sweet" => Seasoning.Sweet
    };

    return seasoning;
}


// Enumeration for soup characteristics.
enum Type
{
    Soup,
    Stew,
    Gumbo
}

enum MainIngredient
{
    Mushroom,
    Chicken,
    Carrot,
    Potato
}

enum Seasoning
{
    Spicy,
    Salty,
    Sweet
}