// Start game.
TicTacToeGame game = new TicTacToeGame();
game.Play();

public class TicTacToeGame
{
    // Create 2 player and one current player instances for game logic, and easily switching between players.
    private readonly Player playerX = new Player(Square.X);
    private readonly Player playerO = new Player(Square.O);
    private Player currentPlayer;

    // Create game board instance.
    private readonly GameBoard board  = new GameBoard();

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

public class Player(Square symbol)
{
    public Square Symbol { get; } = symbol;
}

public class GameBoard()
{
    private readonly Square[] Squares =
    {
        Square.Empty, Square.Empty, Square.Empty,
        Square.Empty, Square.Empty, Square.Empty,
        Square.Empty, Square.Empty, Square.Empty
    };

    // Created for easily converting squares array elements to numpad form.
    private readonly int[] numberPadToIndex =
    {
        6, 7, 8,
        3, 4, 5,
        0, 1, 2 
    };

    // Print current board.
    public void ShowBoard()
    {
        Console.WriteLine($"""
         {GetSymbol(Squares[0])} | {GetSymbol(Squares[1])} | {GetSymbol(Squares[2])} 
        ---+---+---
         {GetSymbol(Squares[3])} | {GetSymbol(Squares[4])} | {GetSymbol(Squares[5])} 
        ---+---+---
         {GetSymbol(Squares[6])} | {GetSymbol(Squares[7])} | {GetSymbol(Squares[8])} 
        """);
    }

    // As long as the square is empty, let player to make a move.
    public bool ValidSetSquare(int squareId, Square symbol)
    {
        int index = numberPadToIndex[squareId - 1];

        if (Squares[index] == Square.Empty)
        {
            Squares[index] = symbol;
            return true;
        }
        else
        {
            Console.Write("You can't choose a square that is already chosen. Write another number: ");
            return false;
        }
    }

    // Check win conditions.
    public bool IsWin(Square symbol)
    {
        if (Squares[0] == symbol && Squares[1] == symbol && Squares[2] == symbol) return true;
        if (Squares[3] == symbol && Squares[4] == symbol && Squares[5] == symbol) return true;
        if (Squares[6] == symbol && Squares[7] == symbol && Squares[8] == symbol) return true;
        if (Squares[0] == symbol && Squares[3] == symbol && Squares[6] == symbol) return true;
        if (Squares[1] == symbol && Squares[4] == symbol && Squares[7] == symbol) return true;
        if (Squares[2] == symbol && Squares[5] == symbol && Squares[8] == symbol) return true;
        if (Squares[0] == symbol && Squares[4] == symbol && Squares[8] == symbol) return true;
        if (Squares[2] == symbol && Squares[4] == symbol && Squares[6] == symbol) return true;

        return false;
    }

    // If each square is full and no win detected before, return true (draw condition).
    public bool IsDraw()
    {
        int xCount = 0;
        int oCount = 0;

        foreach (Square square in Squares)
        {
            if (square == Square.X)
                xCount++;
            else if (square == Square.O)
                oCount++;
        }

        if ((xCount == 5 && oCount == 4) || (xCount == 4 && oCount == 5))
            return true;

        return false;
    }

    // Convert enums to string for better visual representation to console.
    public string GetSymbol(Square square)
    {
        return square switch
        {
            Square.X => "X",
            Square.O => "O",
            _ => " "
        };
    }
}

// Enumeration for square values.
public enum Square
{
    X,
    O,
    Empty
}