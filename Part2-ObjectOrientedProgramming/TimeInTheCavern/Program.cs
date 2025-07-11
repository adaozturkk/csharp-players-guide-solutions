// Create and run game.
Game game = new Game();
game.CreateGame();

public class Game
{
    private Map map;
    private readonly Player player = new Player();

    // Track status of activation and win conditions.
    private bool IsActivated = false;
    private bool IsWin = false;
    private bool IsLose = false;

    public void CreateGame()
    {
        // Get time when game starts.
        DateTime currentTime = DateTime.Now;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome to the Fountain of Objects!");
        Console.WriteLine("Your goal is to find the fountain, activate it, and return to entrance.");
        Console.WriteLine("These are the available commands: move north, move south, move east, move west, enable fountain.");

        Console.WriteLine();

        // Create map based on player's size choice.
        map = new Map(GetWorldSize());

        Console.WriteLine();

        // Until player win or lose, apply game logic.
        while (!IsWin && !IsLose)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(player.DisplayLocation());

            // Keep track of player's current location.
            Room currentRoom = map.GetRoom(player.Row, player.Column);
            DisplayMessage(currentRoom);

            // If current room is adjacent to a pit, display message.
            DisplayAdjacentMessage(map.IsAdjacent(currentRoom));

            // Ask user a valid command and apply it.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("What do you want to do? ");
            string? actionInput = Console.ReadLine()?.Trim().ToLower();
            ValidateCommand(actionInput, map);

            // In order to check win or lose condition, update current room after command.
            currentRoom = map.GetRoom(player.Row, player.Column);

            // If user lose, display lose message.
            if (CheckLose(currentRoom))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You fall into a pit and die! Game Over.");

                IsLose = true;
            }

            // If user won, display win message.
            if (CheckWin(currentRoom))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine(player.DisplayLocation());
                DisplayMessage(currentRoom);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You win!");

                IsWin = true;
            }
        }

        // Display how much time player spent through game.
        DisplayTimeElapsed(currentTime);

        Console.ResetColor();
    }

    // Valide player command and according to that change location or enable fountain.
    private void ValidateCommand(string input, Map map)
    {
        while (input == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter a valid command.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            input = Console.ReadLine()?.Trim().ToLower();
        }

        Room currentRoom = map.GetRoom(player.Row, player.Column);

        if ((input == "enable fountain") && (currentRoom.Type == RoomType.Fountain))
        {
            IsActivated = true;
            return;
        }

        if (input == "move north") player.MoveLocation(Direction.North, map);
        if (input == "move south") player.MoveLocation(Direction.South, map);
        if (input == "move east") player.MoveLocation(Direction.East, map);
        if (input == "move west") player.MoveLocation(Direction.West, map);
    }

    // Based on player's current location, display message.
    private void DisplayMessage(Room room)
    {
        if (room.Type == RoomType.Entrance)
        {
            if (!IsActivated)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You see light coming from the cavern entrance.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
            }
        }

        if (room.Type == RoomType.Fountain)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if (!IsActivated) Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
            else Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
        }
    }

    // Check win conditions and return result.
    private bool CheckWin(Room room) => (room.Type == RoomType.Entrance) && IsActivated;

    // To create map instance, get a valid world size from player.
    private string GetWorldSize()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Before we begin, choose your world size: small (4x4), medium (6x6), or large (8x8).");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter size (small/medium/large): ");

        string[] sizes = ["small", "medium", "large"];
        string? sizeInput;

        while (true)
        {
            sizeInput = Console.ReadLine()?.ToLower().Trim();

            if (sizeInput != null && sizes.Contains(sizeInput))
            {
                break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter a valid size: ");
        }

        return sizeInput;
    }

    // Display message if it is adjacent.
    private void DisplayAdjacentMessage(bool adjacent)
    {
        if (adjacent)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
        }
    }

    // Check lose conditions and return result.
    private bool CheckLose(Room room) => (room.Type == RoomType.Pit);

    // Display time spent through game.
    private void DisplayTimeElapsed(DateTime startTime)
    {
        TimeSpan timeSpan = DateTime.Now - startTime;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"You spent {timeSpan.Minutes} minutes {timeSpan.Seconds} seconds in the Cavern.");
    }
}

// Create game's map.
public class Map
{
    public readonly Room[,] world;

    // Initially set every room as empty and specify entrance, fountain, and pit rooms for each map size.
    public Map(string size)
    {
        string Size = size;

        switch (size)
        {
            case "small":
                world = new Room[4, 4];
                break;
            case "medium":
                world = new Room[6, 6];
                break;
            case "large":
                world = new Room[8, 8];
                break;
        }

        for (int row = 0; row < world.GetLength(0); row++)
            for (int column = 0; column < world.GetLength(1); column++)
                world[row, column] = new Room(row, column, RoomType.Empty);

        if (size == "small")
        {
            world[0, 0] = new Room(0, 0, RoomType.Entrance);
            world[0, 2] = new Room(0, 2, RoomType.Fountain);
            world[2, 1] = new Room(2, 1, RoomType.Pit);
        }

        if (size == "medium")
        {
            world[0, 0] = new Room(0, 0, RoomType.Entrance);
            world[2, 4] = new Room(2, 4, RoomType.Fountain);
            world[2, 1] = new Room(2, 1, RoomType.Pit);
            world[4, 3] = new Room(4, 3, RoomType.Pit);
        }

        if (size == "large")
        {
            world[0, 0] = new Room(0, 0, RoomType.Entrance);
            world[4, 6] = new Room(4, 6, RoomType.Fountain);
            world[1, 3] = new Room(1, 3, RoomType.Pit);
            world[1, 6] = new Room(1, 6, RoomType.Pit);
            world[6, 1] = new Room(6, 1, RoomType.Pit);
        }
    }

    // Get room according to specified row and column.
    public Room GetRoom(int row, int column) => world[row, column];

    // Check if location is adjacent to pits.
    public bool IsAdjacent(Room location)
    {
        int row = location.Row;
        int col = location.Column;

        if (row > 0 && GetRoom(row - 1, col).Type == RoomType.Pit) return true;
        if (row > 0 && col > 0 && GetRoom(row - 1, col - 1).Type == RoomType.Pit) return true;
        if (row > 0 && col < world.GetLength(1) - 1 && GetRoom(row - 1, col + 1).Type == RoomType.Pit) return true;
        if (col > 0 && GetRoom(row, col - 1).Type == RoomType.Pit) return true;
        if (col < world.GetLength(1) - 1 && GetRoom(row, col + 1).Type == RoomType.Pit) return true;
        if (row < world.GetLength(0) - 1 && GetRoom(row + 1, col).Type == RoomType.Pit) return true;
        if (col > 0 && row < world.GetLength(0) - 1 && GetRoom(row + 1, col - 1).Type == RoomType.Pit) return true;
        if (col < world.GetLength(1) - 1 && row < world.GetLength(0) - 1 && GetRoom(row + 1, col + 1).Type == RoomType.Pit) return true;

        return false;
    }
}

public record Room(int Row, int Column, RoomType Type);

public class Player
{
    public int Row { get; private set; }
    public int Column { get; private set; }

    // Move player's direction unless it is not out of the map.
    public void MoveLocation(Direction direction, Map map)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        switch (direction)
        {
            case Direction.North:
                if (Row > 0) Row--;
                else Console.WriteLine("You cannot move there.");
                break;
            case Direction.South:
                if (Row < map.world.GetLength(0) - 1) Row++;
                else Console.WriteLine("You cannot move there.");
                break;
            case Direction.East:
                if (Column < map.world.GetLength(1) - 1) Column++;
                else Console.WriteLine("You cannot move there.");
                break;
            case Direction.West:
                if (Column > 0) Column--;
                else Console.WriteLine("You cannot move there.");
                break;
        }
    }

    public string DisplayLocation()
    {
        return $"You are in the room at (Row={Row}, Column={Column}).";
    }
}

public enum Direction
{
    North,
    South,
    West,
    East
}

public enum RoomType
{
    Entrance,
    Empty,
    Fountain,
    Pit
}