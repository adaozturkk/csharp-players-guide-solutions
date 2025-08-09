int[] numbers = [1, 9, 2, 8, 3, 7, 4, 6, 5];

// Test all 3 methods.

var list1 = ApplyOperations(numbers);
foreach (var number in list1)
    Console.WriteLine(number);

var list2 = ApplyKeyword(numbers);
foreach (var number in list2)
    Console.WriteLine(number);

var list3 = ApplyMethod(numbers);
foreach (var number in list3)
    Console.WriteLine(number);

IEnumerable<int> ApplyOperations(int[] input)
{
    List<int> list = new List<int>();

    foreach (int number in numbers)
    {
        if (number % 2 == 0)
            list.Add(number);
    }

    int[] newNumbers = list.ToArray();
    Array.Sort(newNumbers);

    for (int count = 0; count < newNumbers.Length; count++)
        newNumbers[count] *= 2;

    return newNumbers;
}

IEnumerable<int> ApplyKeyword(int[] input)
{
    return from i in input
           where i % 2 == 0
           orderby i
           select i * 2;
}

IEnumerable<int> ApplyMethod(int[] input)
{
    return input
        .Where(i =>  i % 2 == 0)
        .OrderBy(i => i)
        .Select(i => i * 2);
}