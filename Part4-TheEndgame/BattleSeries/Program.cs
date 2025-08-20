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

// Create monsters party 1.
Party monsters = new Party(new Computer());
monsters.Characters.Add(new Skeleton());

// Create monsters party 2.
Party monsters2 = new Party(new Computer());
monsters2.Characters.Add(new Skeleton());
monsters2.Characters.Add(new Skeleton());

// List of monster parties.
List<Party> monsterParties = new List<Party> { monsters, monsters2 };

// Create and run battle unless monsters party wins.
for (int i = 0; i < monsterParties.Count; i++)
{
    Battle battle = new Battle(heroes ,monsterParties[i]);
    battle.RunBattle();

    if (!battle.IsHeroesWon)
    {
        Console.WriteLine("Heroes lost! The Uncoded One’s forces prevail.");
        return;
    }
}

// Display win message.
Console.WriteLine("Heroes won! The Uncoded One has been defeated.");

public class Battle(Party heroes, Party monsters)
{
    private Party Heroes { get; } = heroes;
    private Party Monsters { get; } = monsters;
    public bool IsHeroesWon { get; private set; } = false;

    public void RunBattle()
    {
        while (Heroes.Characters.Count > 0 && Monsters.Characters.Count > 0)
        {
            // Heroes' turn.
            for (int i = 0; i < Heroes.Characters.Count; i++)
            {
                PlayTurn(Heroes.Characters[i], Heroes.Player);

                if (Monsters.Characters.Count == 0)
                {
                    IsHeroesWon = true;
                    return;
                }
            }

            // Monsters' turn.
            for (int i = 0; i < Monsters.Characters.Count; i++)
            {
                PlayTurn(Monsters.Characters[i], Monsters.Player);

                if (Heroes.Characters.Count == 0)
                {
                    return;
                }
            }
        }
    }

    private void PlayTurn(Character character, IPlayer player)
    {
        Console.WriteLine($"It is {character.Name}'s turn...");
        player.DoAction(character, this).Run(character, this);
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
    public bool IsAlive { get; private set; } = true;

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;

        // If HP becomes 0 or lower, character dies.
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
            IsAlive = false;
        }
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
    void Run(Character character, Battle battle);
}

public class DoNothing : IAction
{
    public void Run(Character character, Battle battle) => Console.WriteLine($"{character.Name} did NOTHING.");
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

    public void Run(Character character, Battle battle)
    {
        Console.WriteLine($"{character.Name} used {Attack.Name} on {Enemy.Name}.");

        // Calculate and display damage.
        int damage = Attack.GiveDamage();
        Enemy.TakeDamage(damage);

        Console.WriteLine($"{Attack.Name} dealt {damage} to {Enemy.Name}.");
        Console.WriteLine($"{Enemy.Name} is now at {Enemy.CurrentHP}/{Enemy.MaxHP} HP.");

        if (!Enemy.IsAlive)
        {
            battle.GetPartyFor(Enemy).Characters.Remove(Enemy);
            Console.WriteLine($"{Enemy.Name} was defeated!");
        }
    }
}

public class Attack(string name, Func<int> GiveDamage)
{
    public string Name { get; } = name;
    private readonly Func<int> giveDamage = GiveDamage;
    public int GiveDamage() => giveDamage();
}