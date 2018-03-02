using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RageQuit
{
    static void Main()
    {
        var inputLine = Console.ReadLine();
        var result = new StringBuilder();
        var regex = new Regex(@"([^\d]+)(\d+)");
        var matches = regex.Matches(inputLine);
        foreach (Match match in matches)
        {
            var part = match.Groups[1].ToString().ToUpper();
            var times = int.Parse(match.Groups[2].Value);
            for (int i = 0; i < times; i++)
            {
                result.Append(part);
            }
        }
        var uniqueSymbols = result.ToString().Distinct().Count();
        Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
        Console.WriteLine(result);
    }
}