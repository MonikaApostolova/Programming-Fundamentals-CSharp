using System;

class Junk
{
    static void Main()
    {
        var char1 = char.Parse(Console.ReadLine());
        var char2 = char.Parse(Console.ReadLine());
        var char3 = char.Parse(Console.ReadLine());
        var result = string.Format(char3.ToString() + char2.ToString() + char1.ToString());
        Console.WriteLine(result);
    }
}