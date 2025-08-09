// Get word from user.
Console.Write("Enter a word using lowercase letters: ");
string? word = Console.ReadLine();

// Get total time elapsed to understand how long it took to create same word.
DateTime before = DateTime.Now;
int count = await RandomlyRecreateAsync(word);

DateTime after = DateTime.Now;
TimeSpan timeSpan = after - before;

Console.WriteLine($"Total attempts made: {count}.");
Console.WriteLine($"Time span = {timeSpan.TotalSeconds:F2} seconds.");

// Return number of attempts to make the same word with generating random letters.
int RandomlyRecreate(string word)
{
    Random random = new();
    int length = word.Length;
    int count = 0;
    
    while (true)
    {
        string newWord = "";

        for (int i = 0; i < length; i++)
            newWord += (char)('a' + random.Next(26));

        count++;

        if (newWord == word)
            break;
    }

    return count;
}

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() => RandomlyRecreate(word));
}