Console.WriteLine(Add(1, 9));
Console.WriteLine(Add(1.5, 3.7));
Console.WriteLine(Add("hello", "world"));
Console.WriteLine(Add(DateTime.Now, TimeSpan.FromHours(1)));

dynamic Add(dynamic a, dynamic b) => a + b;