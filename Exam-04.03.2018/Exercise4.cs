using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var result = new Dictionary<string, List<string>>();
        List<string> users = new List<string>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Lumpawaroo")
            {
                break;
            }

            if (input.Contains("|"))
            {
                string side = input.Split(" | ")[0];
                string name = input.Split(" | ")[1];

                if (!result.ContainsKey(side))
                {
                    if (!users.Contains(name))
                    {
                        result.Add(side, new List<string>() { name });
                        users.Add(name);
                    }
                }

                else
                {
                    if (!result[side].Contains(name))
                    {
                        result[side].Add(name);
                        users.Add(name);
                    }
                }
            }
            else
            {
                string name = input.Split(" -> ")[0];
                string side = input.Split(" -> ")[1];

                if (users.Contains(name))
                {
                    var currSideName = result.First(s => s.Value.Contains(name)).Key;
                    result[currSideName].Remove(name);

                    if (!result.ContainsKey(side))
                    {
                        result.Add(side, new List<string>() { name });
                        users.Add(name);
                        Console.WriteLine($"{name} joins the {side} side!");
                    }

                    else
                    {
                        result[side].Add(name);
                        users.Add(name);
                        Console.WriteLine($"{name} joins the {side} side!");
                    }
                }

                else if (!result.ContainsKey(side))
                {
                    result.Add(side, new List<string>() { name });
                    users.Add(name);
                    Console.WriteLine($"{name} joins the {side} side!");
                }

                else
                {
                    result[side].Add(name);
                    Console.WriteLine($"{name} joins the {side} side!");
                }
            }
        }

        result = result.Where(kvp => kvp.Value.Count > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        foreach (var side in result.OrderByDescending(kvp => kvp.Value.Count).ThenBy(kvp => kvp.Key))
        {
            Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

            foreach (var name in side.Value.OrderBy(n => n))
            {
                Console.WriteLine($"! {name}");
            }
        }
    }
}
