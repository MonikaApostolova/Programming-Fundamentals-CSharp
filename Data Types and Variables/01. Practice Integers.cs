using System;
using System.Numerics;

class Junk
{
    static void Main()
    {
        var num1 = sbyte.Parse(Console.ReadLine());
        var num2 = byte.Parse(Console.ReadLine());
        var num3 = short.Parse(Console.ReadLine());
        var num4 = ushort.Parse(Console.ReadLine());
        var num5 = ulong.Parse(Console.ReadLine());
        var num6 = long.Parse(Console.ReadLine());
        var num7 = BigInteger.Parse(Console.ReadLine());
        Console.WriteLine(num1);
        Console.WriteLine(num2);
        Console.WriteLine(num3);
        Console.WriteLine(num4);
        Console.WriteLine(num5);
        Console.WriteLine(num6);
        Console.WriteLine(num7);
    }
}