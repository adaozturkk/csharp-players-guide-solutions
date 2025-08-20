// Get name from user for true programmer character.
Console.Write("Enter name for True Programmer: ");
string? name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("Invalid name.");
    return;
}

// Create heroes party.
Party heroes = new Party();
heroes.Characters.Add(new TrueProgrammer(name));

// Create monsters party.
Party monsters = new Party();
monsters.Characters.Add(new Skeleton());

// Create and run battle.
Battle battle = new Battle(heroes, monsters);
battle.RunBattle();

public class Battle(Party heroes, Party monsters)
{
    private Party Heroes { get; } = heroes;
    private Party Monsters { get; } = monsters;

    public void RunBattle()
    {
        while (true)
        {
            foreach (var hero in Heroes.Characters)
            {
                PlayTurn(hero);
            }

            foreach (var monster in Monsters.Characters)
            {
                PlayTurn(monster);
            }
        }
    }

    private void PlayTurn(Character character)
    {
        Console.WriteLine($"It is {character.Name}'s turn...");
        character.TakeTurn();

        Console.WriteLine();
        Thread.Sleep(500);
    }
}

public class Character(string name)
{
    public string Name { get; } = name;
    public void TakeTurn() => Console.WriteLine($"{Name} did NOTHING.");
}

public class Skeleton : Character
{
    public Skeleton() : base("SKELETON") {}
}

public class TrueProgrammer : Character
{
    public TrueProgrammer(string name) : base(name) {}
}

public class Party()
{
    public List<Character> Characters { get; } = new List<Character>();
}