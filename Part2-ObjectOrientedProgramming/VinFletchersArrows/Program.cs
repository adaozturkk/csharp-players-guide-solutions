// Create arrow and display cost.
Arrow arrow = GetArrow();

Console.WriteLine();
Console.WriteLine($"Arrows costs {arrow.GetCost()} gold.");

// ------------- METHODS -------------

// Create an instance of arrow class.
Arrow GetArrow() 
{
    ArrowheadType arrowhead = GetArrowhead();
    FletchingType fletching = GetFletching();
    int length = GetLength();

    return new Arrow(arrowhead, fletching, length);
}

// Let user choose arrowhead type for arrow.
ArrowheadType GetArrowhead()
{
    Console.Write("Enter arrowhead type (steel/wood/obsidian): ");
    string? arrowheadInput = Console.ReadLine()?.Trim().ToLower();

    return arrowheadInput switch
    {
        "steel" => ArrowheadType.Steel,
        "wood" => ArrowheadType.Wood,
        "obsidian" => ArrowheadType.Obsidian,
        _ => GetArrowhead()
    };
}

// Let user choose fletching type for arrow.
FletchingType GetFletching()
{
    Console.Write("Enter fletching type (plastic/turkey feathers/goose feathers): ");
    string? fletchingInput = Console.ReadLine()?.Trim().ToLower();

    return fletchingInput switch
    {
        "plastic" => FletchingType.Plastic,
        "turkey feathers" => FletchingType.TurkeyFeathers,
        "goose feathers" => FletchingType.GooseFeathers,
        _ => GetFletching()
    };
}

// Let user choose a valid length for arrow.
int GetLength()
{
    Console.Write("Enter length between 60 and 100: ");
    string? lengthInput = Console.ReadLine()?.Trim();
    bool validInput = int.TryParse(lengthInput, out int length);

    while (!validInput || (length < 60 || length > 100) )
    {
        Console.Write("Invalid input. Enter a value between 60 and 100: ");
        lengthInput = Console.ReadLine()?.Trim();
        validInput = int.TryParse(lengthInput, out length);
    }

    return length;
}


class Arrow
{
    public ArrowheadType _arrowhead;
    public FletchingType _fletching;
    public int _length;

    public Arrow(ArrowheadType arrowhead, FletchingType fletching, int length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    public float GetCost()
    {
        float totalCost = 0F;

        // Based on arrowhead type add price to total cost.
        switch (_arrowhead)
        {
            case ArrowheadType.Steel:
                totalCost += 10;
                break;
            case ArrowheadType.Wood:
                totalCost += 3;
                break;
            case ArrowheadType.Obsidian:
                totalCost += 5;
                break;
        }

        // Based on fletching type add price to total cost.
        switch (_fletching)
        {
            case FletchingType.Plastic:
                totalCost += 10;
                break;
            case FletchingType.TurkeyFeathers:
                totalCost += 5;
                break;
            case FletchingType.GooseFeathers:
                totalCost += 3;
                break;
        }

        // Based on length add price to total cost.
        totalCost += (_length * 0.05F);

        return totalCost;
    }
}


enum ArrowheadType
{
    Steel,
    Wood,
    Obsidian
}

enum FletchingType
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers
}