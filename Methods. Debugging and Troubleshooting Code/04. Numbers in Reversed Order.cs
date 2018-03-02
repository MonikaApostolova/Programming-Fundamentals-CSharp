using System;
using System.Linq;

class Exercises
{
    static void Main()
    {
        var num = Console.ReadLine().ToCharArray();
        var result = Reverse(num);
        Console.WriteLine(string.Join("", result));
    }

    private static char[] Reverse(char[] num)
    {
        var result = new char[num.Length];
        result = num.Reverse().ToArray();
        return result;
    }
}