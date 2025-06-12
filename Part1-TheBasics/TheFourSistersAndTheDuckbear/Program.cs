// Asks user total number of eggs gathered and stores as integer
Console.WriteLine("What is the number of chocolate eggs gathered today?");
int numberOfEggs = int.Parse(Console.ReadLine());

int numberOfSisters = 4;

// Calculates each sisters and duckbears share of eggs and displays
int duckbearsEggs = numberOfEggs % numberOfSisters;
int sisterEggs = (numberOfEggs - duckbearsEggs) / numberOfSisters;

Console.WriteLine("Each sister gets " + sisterEggs + " eggs.");
Console.WriteLine("Duckbear gets " + duckbearsEggs + " eggs.");