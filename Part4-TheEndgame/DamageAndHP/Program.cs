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
public class Character(string name, Attack attack, int maxHP)
{
    public string Name { get; } = name;
    public Attack Attack { get; } = attack;
    public int MaxHP { get; } = maxHP;
    public int CurrentHP { get; set; } = maxHP;

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP < 0) CurrentHP = 0;
    }
}

public class Skeleton : Character
{
    private static Random random = new Random();
    public Skeleton() : base("SKELETON", new Attack("BONE CRUNCH", () => random.Next(2)), 5) { }
}

public class TrueProgrammer : Character
{
    public TrueProgrammer(string name) : base(name, new Attack("PUNCH", () => 1), 25) { }
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
        var enemy = battle.GetEnemyPartyFor(character).Characters[0];
        return new AttackAction(enemy, character.Attack);
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

public class AttackAction : IAction
{
    private readonly Character Enemy;
    private readonly Attack Attack;

    public AttackAction(Character enemy, Attack attack)
    {
        Enemy = enemy;
        Attack = attack;
    }

    public void Run(Character character)
    {
        Console.WriteLine($"{character.Name} used {Attack.Name} on {Enemy.Name}.");

        // Calculate and display damage.
        int damage = Attack.GiveDamage();
        Enemy.TakeDamage(damage);
       
        Console.WriteLine($"{Attack.Name} dealt {damage} to {Enemy.Name}.");
        Console.WriteLine($"{Enemy.Name} is now at {Enemy.CurrentHP}/{Enemy.MaxHP} HP.");
    }
}

public class Attack(string name, Func<int> GiveDamage)
{
    public string Name { get; } = name;
    private readonly Func<int> giveDamage = GiveDamage;
    public int GiveDamage() => giveDamage();
}