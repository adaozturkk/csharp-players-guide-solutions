// Create and run game.
Game game = new Game();
game.CreateGame();

public class Game
{
    private readonly Map map = new Map();
    private readonly Player player = new Player();

    // Track status of activation and win conditions.
    private bool IsActivated = false;
    private bool IsWin = false;

    public void CreateGame()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome to the Fountain of Objects!");
        Console.WriteLine("Your goal is to find the fountain, activate it, and return to entrance.");
        Console.WriteLine("These are the available commands: move north, move south, move east, move west, enable fountain.");
        Console.WriteLine();

        // Until player wins, apply game logic.
        while (!IsWin)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(player.DisplayLocation());

            // Keep track of player's current location.
            Room currentRoom = map.GetRoom(player.Row, player.Column);
            DisplayMessage(currentRoom);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("What do you want to do? ");
            string? actionInput = Console.ReadLine()?.Trim().ToLower();
            ValidateCommand(actionInput);

            // In order to check win condition, update current room after command.
            currentRoom = map.GetRoom(player.Row, player.Column);

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

        Console.ResetColor();
    }

    // Valide player command and according to that change location or enable fountain.
    private void ValidateCommand(string input)
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
            
        if (input == "move north") player.MoveLocation(Direction.North);
        if (input == "move south") player.MoveLocation(Direction.South);
        if (input == "move east") player.MoveLocation(Direction.East);
        if (input == "move west") player.MoveLocation(Direction.West);
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
}

// Create game's map.
public class Map
{
    private readonly Room[,] world = new Room[4, 4];

    // Initially set every room as empty and specify 2 special rooms.
    public Map()
    {
        for (int row = 0; row < world.GetLength(0) ; row++)
            for (int column = 0;  column < world.GetLength(1) ; column++)
                world[row, column] = new Room(row, column, RoomType.Empty);

        world[0, 0] = new Room(0, 0, RoomType.Entrance);
        world[0, 2] = new Room(0, 2, RoomType.Fountain);
    }

    // Get room according to specified row and column.
    public Room GetRoom(int row, int column) => world[row, column]; 
}

public record Room(int Row, int Column, RoomType Type);

public class Player
{
    public int Row { get; private set; }
    public int Column { get; private set; }

    // Move player's direction unless it is not out of the map.
    public void MoveLocation(Direction direction)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        switch (direction)
        {
            case Direction.North:
                if (Row > 0) Row--;
                else Console.WriteLine("You cannot move there.");
                break;
            case Direction.South:
                if (Row < 3) Row++;
                else Console.WriteLine("You cannot move there.");
                break;
            case Direction.East:
                if (Column < 3) Column++;
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
    Fountain
}