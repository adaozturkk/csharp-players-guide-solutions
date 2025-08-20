// Get name from user for true programmer character.
Console.Write("Enter name for True Programmer: ");
string? name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("Invalid name.");
    return;
}

// Create heroes party.
Party heroes = new Party(new Computer());
heroes.Characters.Add(new TrueProgrammer(name));

// Create monsters party.
Party monsters = new Party(new Computer());
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
                PlayTurn(hero, Heroes.Player);
            }

            foreach (var monster in Monsters.Characters)
            {
                PlayTurn(monster, Monsters.Player);
            }
        }
    }

    private void PlayTurn(Character character, IPlayer player)
    {
        Console.WriteLine($"It is {character.Name}'s turn...");
        player.DoAction(character, this).Run(character);
        Console.WriteLine();
    }

    // Get party for a character, if not found throw an exception.
    public Party GetPartyFor(Character character)
    {
        if (Heroes.Characters.Contains(character))
            return Heroes;
        if (Monsters.Characters.Contains(character))
            return Monsters;

        throw new Exception("Invalid character.");
    }

    // Get enemy party for a character using their party.
    public Party GetEnemyPartyFor(Character character)
    {
        var party = GetPartyFor(character);
        return party == Heroes ? Monsters : Heroes;
    }
}

// Base class for characters.
public class Character(string name, string action)
{
    public string Name { get; } = name;
    public string Action { get; } = action;
}

public class Skeleton : Character
{
    public Skeleton() : base("SKELETON", "BONE CRUNCH") { }
}

public class TrueProgrammer : Character
{
    public TrueProgrammer(string name) : base(name, "PUNCH") { }
}

public class Party(IPlayer player)
{
    public List<Character> Characters { get; } = new List<Character>();
    public IPlayer Player { get; } = player;
}

// Interface for players.
public interface IPlayer
{
    IAction DoAction(Character character, Battle battle);
}

public class Computer : IPlayer
{
    public IAction DoAction(Character character, Battle battle)
    {
        Thread.Sleep(500);
        var enemyParty = battle.GetEnemyPartyFor(character);
        var enemy = enemyParty.Characters[0];
        return new Attack(enemy);
    }
}

// Interface for actions.
public interface IAction
{
    void Run(Character character);
}

public class DoNothing : IAction
{
    public void Run(Character character) => Console.WriteLine($"{character.Name} did NOTHING.");
}

public class Attack : IAction
{
    private readonly Character Enemy;

    public Attack(Character enemy)
    {
        Enemy = enemy;
    }

    public void Run(Character character) => Console.WriteLine($"{character.Name} used {character.Action} on {Enemy.Name}.");
}