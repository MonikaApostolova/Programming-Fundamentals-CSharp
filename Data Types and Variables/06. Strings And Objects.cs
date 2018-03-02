using System;

class Junk
{
    static void Main()
    {
        var str1 = Console.ReadLine();
        var str2 = Console.ReadLine();
        var result = string.Format(str1 + " " + str2);
        Console.WriteLine(result);
    }
}