Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Yellow };

Rank[] ranks = { Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight,
    Rank.Nine, Rank.Ten, Rank.Dollar, Rank.Percent, Rank.Caret, Rank.Ampersand };

// Display whole deck of cards.
for(int colorCount = 0; colorCount < colors.Length; colorCount++)
{
    for (int rankCount = 0; rankCount < ranks.Length; rankCount++)
    {
        DisplayCard(new Card(colors[colorCount], ranks[rankCount]));
    }
}

void DisplayCard(Card card) => Console.WriteLine($"The {card.Color} {card.Rank}");

public class Card(Color color, Rank rank)
{
    public Color Color { get; } = color;
    public Rank Rank { get; } = rank;

    public bool IsSymbol
    {
        get
        {
            return Rank == Rank.Dollar || Rank == Rank.Percent || Rank == Rank.Caret || Rank == Rank.Ampersand;
        }
    }

    public bool IsNumber
    {
        get
        {
            return !IsSymbol;
        }
    }
}

public enum Color
{
    Red,
    Green,
    Blue,
    Yellow
}

public enum Rank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Dollar,
    Percent,
    Caret,
    Ampersand
}