using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Snowflake
{
    static void Main()
    {
        var surfaceRegex = new Regex(@"^[^0-9a-zA-Z]+$");
        var mantleRegex = new Regex(@"^[0-9_]+$");
        var coreRegex = new Regex(@"^[a-zA-Z]+$");
        var fullRegex = new Regex(@"^[^0-9a-zA-Z]+[0-9_]+([a-zA-Z]+)[0-9_]+[^0-9a-zA-Z]+$");
        var surface = Console.ReadLine();
        var mantle = Console.ReadLine();
        var full = Console.ReadLine();
        var mantleSecond = Console.ReadLine();
        var surfaceSecond = Console.ReadLine();
        var isValid = surfaceRegex.IsMatch(surface) && surfaceRegex.IsMatch(surfaceSecond) && mantleRegex.IsMatch(mantle) &&
                      mantleRegex.IsMatch(mantleSecond) && fullRegex.IsMatch(full);
        if (isValid)
        {
            var lenght = fullRegex.Match(full).Groups[1].Length;
            Console.WriteLine("Valid");
            Console.WriteLine(lenght);
        }
        else Console.WriteLine("Invalid");
    }
}