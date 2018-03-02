using System;

class Exercises
{
    static void Main()
    {
        var a = long.Parse(Console.ReadLine());
        var b = long.Parse(Console.ReadLine());
        var c = long.Parse(Console.ReadLine());
        var max = GetMax(a, b, c);
        Console.WriteLine(max);
    }

    private static long GetMax(long a, long b, long c)
    {
        long max = 0;
        if (a >= b && a >= c)
            max = a;
        else if (b >= c && b >= a)
            max = b;
        else if (c >= b && c >= a)
            max = c;
        return max;
    }
}