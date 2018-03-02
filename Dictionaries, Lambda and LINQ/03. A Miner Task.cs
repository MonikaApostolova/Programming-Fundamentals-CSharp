using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var dict = new Dictionary<string, int>();
        for (int i = 0; ; i++)
        {
            var resource = Console.ReadLine();
            if (resource == "stop") break;
            var quantity = int.Parse(Console.ReadLine());
            if (dict.ContainsKey(resource))
            {
                dict[resource] += quantity;
            }
            else
            {
                dict.Add(resource, quantity);
            }
        }
        foreach (var p in dict)
        {
            Console.WriteLine($"{p.Key} -> {p.Value}");
        }
    }
}