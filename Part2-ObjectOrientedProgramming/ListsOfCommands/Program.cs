Robot robot = new Robot();

// Get commands from user and apply them.
Console.WriteLine("Enter commands (on, off, north, south, west, east), when you want to exit write stop.");

// Unless user writes stop, constantly add commands.
while (true)
{
    string? commandInput = Console.ReadLine()?.ToLower().Trim();

    if (commandInput == "stop") break;

    IRobotCommand command = commandInput switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "west" => new WestCommand(),
        "east" => new EastCommand(),
        _ => null
    };

    // Check for null input.
    if (command != null)
        robot.Commands.Add(command);
    else
        Console.WriteLine("Invalid command.");
}

Console.WriteLine();
robot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand?> Commands { get; } = new List<IRobotCommand?>();

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

// Interface for robot commands.
public interface IRobotCommand
{
    void Run(Robot robot);
}

// --------- Commands ---------
public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y += 1;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y -= 1;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X -= 1;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X += 1;
    }
}