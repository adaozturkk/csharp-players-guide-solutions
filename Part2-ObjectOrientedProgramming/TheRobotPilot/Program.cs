// Declare initial healths and round number.
int manticoreHealth = 10;
int cityHealth = 15;
int currentRound = 1;

// Create a random distance.
Random random = new Random();
int stationDistance = random.Next(100);

//Console.WriteLine("Player 2, it is your turn.");

// Apply game logic until manticore or city health is 0.
while (manticoreHealth > 0 && cityHealth > 0)
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"STATUS: Round: {currentRound} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");

    int damage = CalculateDamage(currentRound);
    Console.WriteLine($"The cannon is expected to deal {damage} damage this round. ");

    Console.Write("Enter desired cannon range: ");
    int targetRange = int.Parse(Console.ReadLine());

    CalculateDistance(stationDistance, targetRange);

    // Manticore gets damage if station distance is same with cannon range.
    if (targetRange == stationDistance)
        manticoreHealth -= damage;

    // If manticore is alive, city gets damage.
    bool isManticoreAlive = manticoreHealth > 0;
    if (isManticoreAlive)
        cityHealth -= 1;

    currentRound++;
    Console.ForegroundColor = ConsoleColor.Gray;
}

// Display winner of game.
if (manticoreHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("The city has been destroyed. The Manticore and the Uncoded One have won.");
}

// METHODS

// Calculate damage according to divisibility of round number.
int CalculateDamage(int round)
{
    if (round % 3 == 0 && round % 5 == 0)
        return 10;
    else if (round % 3 == 0 || round % 5 == 0)
        return 3;
    else
        return 1;
}

// According to users cannon range decide on location.
void CalculateDistance(int stationDistance, int targetRange)
{
    if (targetRange > stationDistance)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("That round OVERSHOT the target.");
    }

    else if (targetRange < stationDistance)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("That round FELL SHORT of the target.");
    }

    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("That round was a DIRECT HIT!");
    }

}