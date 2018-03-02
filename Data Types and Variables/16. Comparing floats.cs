using System;
using System.Numerics;

class Junk
{
    static void Main()
    {
        var a = double.Parse(Console.ReadLine());
        var b = double.Parse(Console.ReadLine());
        var differance = Math.Abs(a - b);
        bool areEqual = differance < 0.000001;
        Console.WriteLine(areEqual);
    }
}