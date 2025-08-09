BlockCoordinate block = new BlockCoordinate(4, 3);
BlockOffset offset = new BlockOffset(2, 0);
BlockCoordinate result = block + offset;
Console.WriteLine($"{result.Row}, {result.Column}");

BlockCoordinate block2 = new BlockCoordinate(4, 3);
BlockCoordinate result2 = block2 + Direction.East;
Console.WriteLine($"{result2.Row}, {result2.Column}");

public record BlockCoordinate(int Row, int Column)
{
    // Change coordinate according to offset values.
    public static BlockCoordinate operator +(BlockCoordinate coordinate, BlockOffset offset) => 
        new BlockCoordinate(coordinate.Row + offset.RowOffset, coordinate.Column + offset.ColumnOffset);

    // Change coordinate according to directions.
    public static BlockCoordinate operator +(BlockCoordinate coordinate, Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockCoordinate(coordinate.Row - 1, coordinate.Column),
            Direction.East => new BlockCoordinate(coordinate.Row, coordinate.Column + 1),
            Direction.South => new BlockCoordinate(coordinate.Row + 1, coordinate.Column),
            Direction.West => new BlockCoordinate(coordinate.Row, coordinate.Column - 1),
        };
    }
}
public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction { North, East, South, West }