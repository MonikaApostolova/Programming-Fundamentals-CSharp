using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Regex keyRegex = new Regex(@"[sSTtAaRr]");
        Regex planetRegex = new Regex(@"\@([a-zA-Z]+)[^@\-!:>]*\:([0-9]+)[^@\-!:>]*\!(A|D)\![^@\-!:>]*\-\>[0-9]+");

        List<StringBuilder> afterDecrypting = new List<StringBuilder>();
        List<string> attacked = new List<string>();
        List<string> destroyed = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string current = Console.ReadLine();
            int key = keyRegex.Matches(current).Count;

            StringBuilder newString = new StringBuilder();

            foreach (char ch in current)
            {
                char changed = (char)(ch - key);
                newString.Append(changed);
            }

            afterDecrypting.Add(newString);
        }

        foreach (var planet in afterDecrypting)
        {
            Match match = planetRegex.Match(planet.ToString());

            string name = match.Groups[1].Value;
            string type = match.Groups[3].Value;

            if (type == "A")
            {
                attacked.Add(name);
            }

            if (type == "D")
            {
                destroyed.Add(name);
            }
        }

        Console.WriteLine($"Attacked planets: {attacked.Count}");

        foreach (var planet in attacked.OrderBy(a => a))
        {
            Console.WriteLine($"-> {planet}");
        }

        Console.WriteLine($"Destroyed planets: {destroyed.Count}");

        foreach (var planet in destroyed.OrderBy(a => a))
        {
            Console.WriteLine($"-> {planet}");
        }
    }
}