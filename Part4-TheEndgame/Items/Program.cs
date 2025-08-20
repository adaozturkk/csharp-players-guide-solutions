// Get name from user for true programmer character.
using System.IO;

Console.Write("Enter name for True Programmer: ");
string? name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("Invalid name.");
    return;
}

// Get preferred gameplay mode from user and create player instances based on that.
Mode playMode = GetGameplayMode();
IPlayer player1 = null;
IPlayer player2 = null;

switch (playMode)
{
    case Mode.ComputerVsComputer:
        player1 = new Computer();
        player2 = new Computer();
        break;
    case Mode.HumanVsComputer:
        player1 = new Human();
        player2 = new Computer();
        break;
    case Mode.HumanVsHuman:
        player1 = new Human();
        player2 = new Human();
        break;
    default:
        player1 = new Computer();
        player2 = new Computer();
        break;
}

// Create heroes party.
Party heroes = new Party(player1);
heroes.Characters.Add(new TrueProgrammer(name));
heroes.Items.Add(new HealthPotion());
heroes.Items.Add(new HealthPotion());
heroes.Items.Add(new HealthPotion());

// Create monsters party 1.
Party monsters = new Party(player2);
monsters.Characters.Add(new Skeleton());
monsters.Items.Add(new HealthPotion());

// Create monsters party 2.
Party monsters2 = new Party(player2);
monsters2.Characters.Add(new Skeleton());
monsters2.Characters.Add(new Skeleton());
monsters2.Items.Add(new HealthPotion());

// Create monsters party 3.
Party monsters3 = new Party(player2);
monsters3.Characters.Add(new TheUncodedOne());
monsters3.Items.Add(new HealthPotion());

// List of monster parties.
List<Party> monsterParties = new List<Party> { monsters, monsters2, monsters3 };

// Create and run battle unless monsters party wins.
for (int i = 0; i < monsterParties.Count; i++)
{
    Battle battle = new Battle(heroes, monsterParties[i]);
    battle.RunBattle();

    if (!battle.IsHeroesWon)
    {
        Console.WriteLine("Heroes lost! The Uncoded One’s forces prevail.");
        return;
    }
}

// Display win message.
Console.WriteLine("Heroes won! The Uncoded One has been defeated.");

// Get a valid gameplay mode from user.
Mode GetGameplayMode()
{
    Console.WriteLine("Choose gameplay mode from the list below.");
    Console.WriteLine("Human vs Computer");
    Console.WriteLine("Computer vs Computer");
    Console.WriteLine("Human vs Human");
    Console.Write("Your choice: ");
    string? choice = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(choice))
    {
        Console.Write("Enter a valid mode: ");
        choice = Console.ReadLine();
    }

    return choice.Trim().ToLower() switch
    {
        "human vs computer" => Mode.HumanVsComputer,
        "computer vs computer" => Mode.ComputerVsComputer,
        "human vs human" => Mode.HumanVsHuman,
        _ => GetGameplayMode()
    };
}

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
                var hero = Heroes.Characters[i];
                DisplayStatus(hero);

                PlayTurn(hero, Heroes.Player);

                if (Monsters.Characters.Count == 0)
                {
                    IsHeroesWon = true;
                    return;
                }
            }

            // Monsters' turn.
            for (int i = 0; i < Monsters.Characters.Count; i++)
            {
                var monster = Monsters.Characters[i];
                DisplayStatus(monster);

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

    private void DisplayStatus(Character character)
    {
        Console.WriteLine("============================================= BATTLE ============================================");

        // Display heroes.
        for (int i = 0; i < Heroes.Characters.Count; i++)
        {
            var hero = Heroes.Characters[i];

            if (!hero.IsAlive)
                continue;

            if (character == hero)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine($"{hero.Name,-45} ({hero.CurrentHP,3}/{hero.MaxHP,-3})");

            Console.ResetColor();
        }

        Console.WriteLine("---------------------------------------------- VS -----------------------------------------------");

        // Display monsters.
        for (int i = 0; i < Monsters.Characters.Count; i++)
        {
            var monster = Monsters.Characters[i];

            if (!monster.IsAlive)
                continue;

            if (monster == character)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine($"                                          {monster.Name,45} ({monster.CurrentHP,3}/{monster.MaxHP,-3})");

            Console.ResetColor();
        }

        Console.WriteLine("=================================================================================================");
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

public class TheUncodedOne : Character
{
    private static Random random = new Random();
    public TheUncodedOne() : base("THE UNCODED ONE", new Attack("UNRAVELING", () => random.Next(3)), 15) { }
}

public class Party(IPlayer player)
{
    public List<Character> Characters { get; } = new List<Character>();
    public List<Item> Items { get; } = new List<Item>();
    public IPlayer Player { get; } = player;
}

// Interface for players.
public interface IPlayer
{
    IAction DoAction(Character character, Battle battle);
}

public class Computer : IPlayer
{
    private static Random random = new Random();
    public IAction DoAction(Character character, Battle battle)
    {
        Thread.Sleep(500);
        var party = battle.GetPartyFor(character);

        if ((character.CurrentHP < character.MaxHP / 2) && party.Items.Any())
        {
            if (random.Next(100) < 25)
            {
                return new UseItem(party.Items[0]);
            }
        }

        var enemy = battle.GetEnemyPartyFor(character).Characters[0];
        return new AttackAction(enemy, character.Attack);
    }
}

public class Human : IPlayer
{
    public IAction DoAction(Character character, Battle battle)
    {
        Thread.Sleep(500);
        var party = battle.GetPartyFor(character);

        Console.WriteLine($"1 - Standard Attack ({character.Attack.Name})");
        Console.WriteLine("2 - Do Nothing");

        if (party.Items.Any())
        {
            Console.WriteLine("3 - Use Health Potion");
        }

        Console.Write("What do you want to do? ");
        string? choice = Console.ReadLine();

        var validChoices = party.Items.Any() ? new[] { "1", "2", "3" } : new[] { "1", "2" };
        while (string.IsNullOrWhiteSpace(choice) || !validChoices.Contains(choice))
        {
            Console.Write("Invalid number. Try again: ");
            choice = Console.ReadLine();
        }

        switch (choice)
        {
            case "1":
                return new AttackAction(battle.GetEnemyPartyFor(character).Characters[0], character.Attack);
            case "2":
                return new DoNothing();
            case "3":
                if (party.Items.Any())
                    return new UseItem(party.Items[0]);
                else
                    return new DoNothing();
            default:
                return new DoNothing();
        }
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

public class UseItem : IAction
{
    public Item Item { get; }
    public UseItem(Item item)
    {
        Item = item;
    }
    public void Run(Character character, Battle battle)
    {
        Item.UseItem(character);
        battle.GetPartyFor(character).Items.Remove(Item);
    }
}

public class Attack(string name, Func<int> GiveDamage)
{
    public string Name { get; } = name;
    private readonly Func<int> giveDamage = GiveDamage;
    public int GiveDamage() => giveDamage();
}

// Base class for items.
public abstract class Item(string name)
{
    public string Name { get; } = name;
    public abstract void UseItem(Character character);
}

public class HealthPotion : Item
{
    public HealthPotion() : base("HEALTH POTION") { }
    public override void UseItem(Character character)
    {
        character.CurrentHP += 10;
        int difference = 0;

        if (character.CurrentHP > character.MaxHP)
        {
            difference = character.CurrentHP - character.MaxHP;
            character.CurrentHP = character.MaxHP;
        }

        Console.WriteLine($"{character.Name} drinks a potion and restores {10 - difference} HP.");
    }
}

// Enumeration for gameplay modes.
public enum Mode
{
    HumanVsComputer,
    ComputerVsComputer,
    HumanVsHuman
}