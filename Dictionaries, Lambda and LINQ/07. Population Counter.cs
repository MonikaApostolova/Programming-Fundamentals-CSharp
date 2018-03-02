using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7.PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var input = Console.ReadLine().Split('|').ToArray();
                if (input[0] == "report")
                {
                    break;
                }
                var country = input[1];
                var town = input[0];
                var population = int.Parse(input[2]);
                if (!result.ContainsKey(country))
                {
                    result[country] = new Dictionary<string, double>();
                    if (!result[country].ContainsKey(town))
                    {
                        result[country][town] = population;
                    }
                    else result[country][town] += population;
                }
                else
                {
                    if (!result[country].ContainsKey(town))
                    {
                        result[country][town] = population;
                    }
                    else result[country][town] += population;
                }
            }

            result = result.OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var country in result.Keys)
            {
                var totalPopulation = result[country].Values.Sum();
                Console.WriteLine($"{country} (total population: {totalPopulation})");
                foreach (var Town in result[country].OrderByDescending(c => c.Value))
                {
                    var town = Town.Key;
                    var population = Town.Value;
                    Console.WriteLine($"=>{town}: {population}");
                }
            }
        }
    }
}