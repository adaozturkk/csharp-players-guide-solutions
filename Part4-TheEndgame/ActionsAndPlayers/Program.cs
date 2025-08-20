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
        player.DoAction(character).Run(character);
        Console.WriteLine();
    }
}

// Base class for characters.
public class Character(string name)
{
    public string Name { get; } = name;
}

public class Skeleton : Character
{
    public Skeleton() : base("SKELETON") { }
}

public class TrueProgrammer : Character
{
    public TrueProgrammer(string name) : base(name) { }
}

public class Party(IPlayer player)
{
    public List<Character> Characters { get; } = new List<Character>();
    public IPlayer Player { get; } = player;
}

// Interface for players.
public interface IPlayer
{
    IAction DoAction(Character character);
}

public class Computer : IPlayer
{
    public IAction DoAction(Character character)
    {
        Thread.Sleep(500);
        return new DoNothing();
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