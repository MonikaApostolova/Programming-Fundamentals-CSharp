using System;

class Exercises
{
    static void Main()
    {
        var name = Console.ReadLine();
        Print(name);
    }

    private static void Print(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}