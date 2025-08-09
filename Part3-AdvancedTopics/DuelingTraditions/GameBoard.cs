namespace DuelingTraditions;

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
