Robot robot = new Robot();

// Get commands from user and apply them.
Console.WriteLine("Enter 3 commands (on, off, north, south, west, east).");

for (int count = 0; count < robot.Commands.Length; count++)
{
    string? commandInput = Console.ReadLine()?.ToLower().Trim();

    RobotCommand command = commandInput switch
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
    if(command != null)
        robot.Commands[count] = command;
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
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

// Abstract base class for robot commands.
public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

// --------- Commands ---------
public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y += 1;
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y -= 1;
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X -= 1;
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X += 1;
    }
}