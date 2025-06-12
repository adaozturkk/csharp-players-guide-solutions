// Gets triangle's baze value and converts to decimal
Console.WriteLine("Enter base of triangle:");
string baseInput = Console.ReadLine();
decimal baseOfTriangle = decimal.Parse(baseInput);

// Gets triangle's height value and converts to decimal
Console.WriteLine("Enter height of triangle:");
string heightInput = Console.ReadLine();
decimal heightOfTriangle = decimal.Parse(heightInput);

// Calculates area of triangle and displays
decimal area = (baseOfTriangle * heightOfTriangle) / 2;
Console.WriteLine("Area = " + area);