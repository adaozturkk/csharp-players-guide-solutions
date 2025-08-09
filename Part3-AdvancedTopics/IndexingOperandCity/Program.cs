BlockCoordinate block = new(4, 3);
Console.WriteLine(block[0]);
Console.WriteLine(block[1]);

public record BlockCoordinate(int Row, int Column)
{
    public int this[int index]
    {
        get
        {
            if (index == 0) return Row;
            if (index == 1) return Column;
            else throw new IndexOutOfRangeException();
        }
    }
}
public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction { North, East, South, West }