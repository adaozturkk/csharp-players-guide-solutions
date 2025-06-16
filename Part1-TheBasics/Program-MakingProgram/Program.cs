// Get unit and type from user to use in program.
Console.Write("Enter preferred unit: ");
string? unitInput = Console.ReadLine();

Console.Write("Enter preffered type: ");
string? typeInput  = Console.ReadLine();

// Display program.
string program = $$"""
    Console.WriteLine("Enter the width (in {{unitInput}}) of the triangle: "); 
    {{typeInput}} width = {{typeInput}}.Parse(Console.ReadLine()); 
    Console.WriteLine("Enter the height (in {{unitInput}}) of the triangle: "); 
    {{typeInput}} height = {{typeInput}}.Parse(Console.ReadLine()); 
    {{typeInput}} result = width * height / 2; 
    Console.WriteLine($"{result} square {{unitInput}}"); 
    """;

Console.WriteLine(program);