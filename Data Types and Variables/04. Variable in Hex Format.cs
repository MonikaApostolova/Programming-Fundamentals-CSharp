using System;

class Junk
{
    static void Main()
    {
        var str = Console.ReadLine();
        var result = Convert.ToInt32(str, 16);
        Console.WriteLine(result);
    }
}