namespace DuelingTraditions;

public class TicTacToeGame
{
    // Create 2 player and one current player instances for game logic, and easily switching between players.
    private readonly Player playerX = new Player(Square.X);
    private readonly Player playerO = new Player(Square.O);
    private Player currentPlayer;

    // Create game board instance.
    private readonly GameBoard board = new GameBoard();

    // Assign current player to player x initially.
    public TicTacToeGame()
    {
        currentPlayer = playerX;
    }

    public void Play()
    {
        // Game introduction.
        Console.WriteLine("Welcome to Tic-Tac-Toe game!");
        Console.WriteLine("You must play this game with 2 players.");
        Console.WriteLine("Player 1 is 'X' and Player 2 is 'O'.");
        Console.WriteLine("Use keys 1–9 to pick a square, as shown:");
        Console.WriteLine("""
         7 | 8 | 9
        ---+---+---
         4 | 5 | 6
        ---+---+---
         1 | 2 | 3
        """);
        Console.WriteLine("Press any key to start!");
        Console.ReadKey(true);
        Console.Clear();

        // Until one player wins the game or draw happens, loop runs.
        while (!board.IsWin(playerX.Symbol) && !board.IsWin(playerO.Symbol))
        {
            Console.WriteLine($"It is {currentPlayer.Symbol}'s turn.");
            board.ShowBoard();

            // Get player's choice of move and check validity.
            Console.Write("What square do you want to play in? ");
            int input = GetValidInput();

            while (!board.ValidSetSquare(input, currentPlayer.Symbol))
            {
                input = GetValidInput();
            }

            Console.Clear();

            // Check for win.
            if (board.IsWin(currentPlayer.Symbol))
            {
                board.ShowBoard();
                Console.WriteLine($"Player {(currentPlayer.Symbol == Square.X ? "1 (X)" : "2 (O)")} Won!");
                return;
            }

            // Check for draw.
            if (board.IsDraw())
            {
                board.ShowBoard();
                Console.WriteLine("It's a draw!");
                break;
            }

            // Switch player after every turn.
            SwitchPlayer();
        }
    }

    // Change current player between x and o.
    private void SwitchPlayer()
    {
        if (currentPlayer == playerX)
            currentPlayer = playerO;
        else
            currentPlayer = playerX;
    }

    // Get an input between 1 to 9.
    private int GetValidInput()
    {
        while (true)
        {
            string? playerInput = Console.ReadLine();
            bool validInput = int.TryParse(playerInput, out int number);

            if (validInput && (number <= 9 && number >= 1))
                return number;
            else
                Console.Write("Enter a valid number (1 to 9): ");
        }
    }
}
