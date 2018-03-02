using System;
using System.Numerics;

class Junk
{
    static void Main()
    {
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());
        var area = width * height;
        var perimeter = width * 2 + height * 2;
        var diagonal = Math.Sqrt(width * width + height * height);
        Console.WriteLine(perimeter);
        Console.WriteLine(area);
        Console.WriteLine(diagonal);
    }
}