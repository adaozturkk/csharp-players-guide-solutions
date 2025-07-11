Coordinate a = new Coordinate(1, 2);
Coordinate b = new Coordinate(2, 2);
Coordinate c = new Coordinate(3, 3);
Coordinate d = new Coordinate(3, 2);
Coordinate e = new Coordinate(3, 2);

Console.WriteLine(a.IsAdjacent(b));
Console.WriteLine(a.IsAdjacent(d));
Console.WriteLine(d.IsAdjacent(e));
Console.WriteLine(c.IsAdjacent(d));

public struct Coordinate
{
    public int Row { get; }
    public int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    // Check if two coordinates are adjacanet to each other or not.
    public bool IsAdjacent(Coordinate coordinate)
    {
        if ((Row == coordinate.Row) && (Math.Abs(Column - coordinate.Column) == 1)) return true;
        if ((Column == coordinate.Column) && (Math.Abs(Row - coordinate.Row) == 1)) return true;

        return false;
    }
}