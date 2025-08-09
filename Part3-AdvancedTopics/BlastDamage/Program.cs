using System.Numerics;

Console.WriteLine(ComputeDamage(20.0, 18.0));
Console.WriteLine(ComputeDamage(20f, 18f));
Console.WriteLine(ComputeDamage(20m, 18m));
Console.WriteLine(ComputeDamage(20, 18));

T ComputeDamage<T> (T initialDamage, T distance) where T : INumberBase<T> => initialDamage / (distance * distance);