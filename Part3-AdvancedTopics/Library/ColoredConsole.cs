namespace Library
{
    public static class ColoredConsole
    {
        public static string Prompt(string question)
        {
            Console.Write(question + " ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = Console.ReadLine();

            if (input != null)
                return input;
            else
                return "Invalid input";
        }

        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}
