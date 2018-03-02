using System;
using System.Linq;

class Exercises
{
    static void Main()
    {
        var index = int.Parse(Console.ReadLine());
        var num = FindNum(index);
        Console.WriteLine(num);
    }

    private static int FindNum(int index)
    {
        var f1 = 0;
        var f2 = 1;
        var fNext = 0;
        for (int i = 1; i <= index; i++)
        {
            fNext = f1 + f2;
            f1 = f2;
            f2 = fNext;
        }
        return f2;
    }
}