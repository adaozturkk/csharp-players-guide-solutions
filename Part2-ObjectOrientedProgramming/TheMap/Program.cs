Terrain[,] map = { 
    { Terrain.Water, Terrain.Land, Terrain.City, Terrain.Land, Terrain.Water, Terrain.Land, Terrain.Water, Terrain.Water},
    { Terrain.Mountain, Terrain.Land, Terrain.Land, Terrain.Land, Terrain.Water, Terrain.Land, Terrain.Land, Terrain.Water},
    { Terrain.Water, Terrain.Mountain, Terrain.Land, Terrain.Land, Terrain.Land, Terrain.Land, Terrain.Land, Terrain.Land},
    { Terrain.Water, Terrain.Water, Terrain.Mountain, Terrain.City, Terrain.Mountain, Terrain.Water, Terrain.Water, Terrain.Water}
};

DisplayMap(map);

// Show map in format of string to console.
void DisplayMap(Terrain[,] map)
{
    for (int i = 0; i < map.GetLength(0); i++)
    {
        for (int j = 0; j <  map.GetLength(1); j++)
            Console.Write(GetText(map[i, j]));

        Console.WriteLine();
    }
}

// Assign each enum value to a coresponding string for visual representation.
string GetText(Terrain terrain)
{
    string text = terrain switch
    {
        Terrain.Land => "  ",
        Terrain.Water => "~~",
        Terrain.Mountain => "^^",
        Terrain.City => "()"
    };

    return text;
}

enum Terrain
{
    Land,
    Water,
    Mountain,
    City
}