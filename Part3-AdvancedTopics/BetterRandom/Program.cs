Random random = new Random();

Console.WriteLine(random.NextDouble(10));
Console.WriteLine(random.NextString("up", "down", "left", "right"));
Console.WriteLine(random.CoinFlip(0.75));

// Extensions for random.
public static class RandomExtensions
{
    public static double NextDouble(this Random random, int max)
    {
        return random.NextDouble() * max;
    }

    public static string NextString(this Random random, params string[] texts)
    {
        return texts[random.Next(texts.Length)];
    }

    public static bool CoinFlip(this Random random, double headsProbability = 0.5)
    {
        return random.NextDouble() < headsProbability;
    }
}