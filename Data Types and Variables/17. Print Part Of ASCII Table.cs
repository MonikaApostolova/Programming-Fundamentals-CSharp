using System;
using System.Collections.Generic;
using System.Numerics;

class Junk
{
    static void Main()
    {
        var start = int.Parse(Console.ReadLine());
        var end = int.Parse(Console.ReadLine());
        var result = new List<char>();
        for (int i = start; i <= end; i++)
        {
            char ch = (char)i;
            result.Add(ch);
        }
        Console.WriteLine(string.Join(" ", result));
    }
}