CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();

public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }
    public event EventHandler Ripened;
    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot! 
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke(this, EventArgs.Empty);
        }
    }
}

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnRipened;
    }

    private void OnRipened(object sender, EventArgs e) => Console.WriteLine("“A charberry fruit has ripened!");
}

public class Harvester
{
    private CharberryTree _tree;

    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        tree.Ripened += OnRipened;
    }

    private void OnRipened(object sender, EventArgs e)
    {
        Console.WriteLine("A charberry fruit has harvested!");
        _tree.Ripe = false;
    }
}