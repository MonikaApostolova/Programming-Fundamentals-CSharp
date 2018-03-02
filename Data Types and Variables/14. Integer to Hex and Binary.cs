using System;
using System.Numerics;

class Junk
{
    static void Main()
    {
        var input = decimal.Parse(Console.ReadLine().ToLower());
        var hex = Convert.ToString((int)input, 16).ToUpper();
        var binary = Convert.ToString((int)input, 2);
        Console.WriteLine(hex);
        Console.WriteLine(binary);
    }
}