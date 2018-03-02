using System;

class Junk
{
    static void Main()
    {
        var num1 = int.Parse(Console.ReadLine());
        var num2 = int.Parse(Console.ReadLine());
        var c = num1;
        Console.WriteLine("Before:");
        Console.WriteLine($"a = {num1}");
        Console.WriteLine($"b = {num2}");
        num1 = num2;
        num2 = c;
        Console.WriteLine("After:");
        Console.WriteLine($"a = {num1}");
        Console.WriteLine($"b = {num2}");
    }
}