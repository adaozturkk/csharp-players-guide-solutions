// Get arrow and display cost.
Console.WriteLine("You can select our special arrows, or create your custom arrow from menu.");
Console.WriteLine("1. The Elite Arrow");
Console.WriteLine("2. The Beginner Arrow");
Console.WriteLine("3. The Marksman Arrow");
Console.WriteLine("4. Custom Arrow");

Arrow arrow = GetArrow();

Console.WriteLine();
Console.WriteLine($"Arrows costs {arrow.GetCost()} gold.");

// ------------- METHODS -------------

// Create arrow based on user's choice.
Arrow GetArrow()
{
    Console.Write("Enter the option you want (1 to 4): ");
    string? choiceInput = Console.ReadLine();
    bool validInput = int.TryParse(choiceInput, out int choice);

    while (!validInput || (choice < 1 || choice > 4))
    {
        Console.Write("Invalid opiton. Enter a number between 1 to 4: ");
        choiceInput = Console.ReadLine();
        validInput = int.TryParse(choiceInput, out choice);
    }

    return choice switch
    {
        1 => Arrow.CreateEliteArrow(),
        2 => Arrow.CreateBeginnerArrow(),
        3 => Arrow.CreateMarksmanArrow(),
        4 => GetCustomArrow()
    };
}

// Create an instance of arrow class.
Arrow GetCustomArrow()
{
    ArrowheadType arrowhead = GetArrowheadType();
    FletchingType fletching = GetFletchingType();
    int length = GetArrowLength();

    return new Arrow { Arrowhead = arrowhead, Fletching = fletching, Length = length };
}

// Let user choose arrowhead type for arrow.
ArrowheadType GetArrowheadType()
{
    Console.Write("Enter arrowhead type (steel/wood/obsidian): ");
    string? arrowheadInput = Console.ReadLine()?.Trim().ToLower();

    return arrowheadInput switch
    {
        "steel" => ArrowheadType.Steel,
        "wood" => ArrowheadType.Wood,
        "obsidian" => ArrowheadType.Obsidian,
        _ => GetArrowheadType()
    };
}

// Let user choose fletching type for arrow.
FletchingType GetFletchingType()
{
    Console.Write("Enter fletching type (plastic/turkey feathers/goose feathers): ");
    string? fletchingInput = Console.ReadLine()?.Trim().ToLower();

    return fletchingInput switch
    {
        "plastic" => FletchingType.Plastic,
        "turkey feathers" => FletchingType.TurkeyFeathers,
        "goose feathers" => FletchingType.GooseFeathers,
        _ => GetFletchingType()
    };
}

// Let user choose a valid length for arrow.
int GetArrowLength()
{
    Console.Write("Enter length between 60 and 100: ");
    string? lengthInput = Console.ReadLine()?.Trim();
    bool validInput = int.TryParse(lengthInput, out int length);

    while (!validInput || (length < 60 || length > 100))
    {
        Console.Write("Invalid input. Enter a value between 60 and 100: ");
        lengthInput = Console.ReadLine()?.Trim();
        validInput = int.TryParse(lengthInput, out length);
    }

    return length;
}


public class Arrow
{
    public required ArrowheadType Arrowhead { get; init; }
    public required FletchingType Fletching { get; init; }
    public required int Length { get; init; }

    // For creating specific arrrow types.
    public static Arrow CreateEliteArrow() => new Arrow 
        { Arrowhead = ArrowheadType.Steel, Fletching = FletchingType.Plastic, Length = 95 };

    public static Arrow CreateBeginnerArrow() => new Arrow
        { Arrowhead = ArrowheadType.Wood, Fletching = FletchingType.GooseFeathers, Length = 75 };

    public static Arrow CreateMarksmanArrow() => new Arrow
        { Arrowhead = ArrowheadType.Steel, Fletching = FletchingType.GooseFeathers, Length = 65 };


    public float GetCost()
    {
        float totalCost = 0F;

        // Based on arrowhead type add price to total cost.
        switch (Arrowhead)
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
        switch (Fletching)
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
        totalCost += (Length * 0.05F);

        return totalCost;
    }
}


public enum ArrowheadType
{
    Steel,
    Wood,
    Obsidian
}

public enum FletchingType
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers
}