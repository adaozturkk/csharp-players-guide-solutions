// Create pack and apply program logic.
Pack pack = CreatePack();

while (true)
{
    // Display current pack status.
    Console.WriteLine();
    Console.WriteLine($"Currently you have {pack.CurrentNumberOfItems}/{pack.NumberOfItems} items - {pack.CurrentWeight}/{pack.MaxWeight} weight - {pack.CurrentVolume}/{pack.MaxVolume} volume.");
    Console.WriteLine();
    
    Console.WriteLine("Choose the item to add to pack (1-6).");
    Console.WriteLine("1. Arrow");
    Console.WriteLine("2. Bow");
    Console.WriteLine("3. Rope");
    Console.WriteLine("4. Water");
    Console.WriteLine("5. Food");
    Console.WriteLine("6. Sword");

    // Validate user input based on menu options.
    int choice = (int)ValidateInput(Console.ReadLine());

    while(choice < 1 || choice > 6)
    {
        Console.Write("Please enter a number between 1 and 6: ");
        choice = (int)ValidateInput(Console.ReadLine());
    }

    InventoryItem item = choice switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new Food(),
        6 => new Sword()
    };

    if (!pack.Add(item))
    {
        Console.WriteLine("Could not add this item.");
    }
}


decimal ValidateInput(string input)
{
    bool validInput = decimal.TryParse(input, out decimal number);
    while (!validInput || input == null)
    {
        Console.Write("Invalid input. Please enter a valid number: ");
        input = Console.ReadLine();
        validInput = decimal.TryParse(input, out number);
    }

    return number;
}

// Create a pack based on user limitations with valid inputs.
Pack CreatePack()
{
    Console.Write("Enter number of items you want to add for pack: ");
    int count = (int)ValidateInput(Console.ReadLine());

    Console.Write("Enter maximum weight for pack: ");
    decimal weight = ValidateInput(Console.ReadLine());

    Console.Write("Enter maximum volume for pack: ");
    decimal volume = ValidateInput(Console.ReadLine());

    return new Pack(count, weight, volume);
}


// Base class for all items.
public class InventoryItem(decimal weight, decimal volume)
{
    public decimal Weight { get; } = weight;
    public decimal Volume { get; } = volume;
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1m, 0.05m) { }
}
public class Bow : InventoryItem
{
    public Bow() : base(1, 4) { }
}

public class Rope : InventoryItem
{
    public Rope() : base(1, 1.5m) { }
}

public class Water : InventoryItem
{
    public Water() : base(2, 3) { }
}

public class Food : InventoryItem
{
    public Food() : base(1, 0.5m) { }
}

public class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }
}


public class Pack(int numberOfItems, decimal maxWeight, decimal maxVolume)
{
    public int NumberOfItems { get; } = numberOfItems;
    public decimal MaxWeight { get; } = maxWeight;
    public decimal MaxVolume { get; } = maxVolume;

    private InventoryItem[] items = new InventoryItem[numberOfItems];
    
    // Track current values for limitations when adding a new item to items array.
    public int CurrentNumberOfItems { get; private set; } = 0;
    public decimal CurrentWeight { get; private set; } = 0;
    public decimal CurrentVolume { get; private set; } = 0;

    public bool Add(InventoryItem item)
    {
        if(CurrentNumberOfItems >= NumberOfItems) return false;
        if (CurrentWeight + item.Weight > MaxWeight) return false;
        if (CurrentVolume + item.Volume > MaxVolume) return false;

        items[CurrentNumberOfItems] = item;

        CurrentNumberOfItems++;
        CurrentWeight += item.Weight;
        CurrentVolume += item.Volume;

        return true;
    }
}