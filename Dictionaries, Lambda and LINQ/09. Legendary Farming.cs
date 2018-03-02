using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    private const int QuantityForLegendaryItem = 250;
    private static readonly Dictionary<string, string> MaterialLegendaryItemTable =
        new Dictionary<string, string>
        {
            { "shards", "Shadowmourne"},
            { "fragments", "Valanyr"},
            { "motes", "Dragonwrath"}
        };

    public static void Main()
    {
#if DEBUG
        Console.SetIn(new StreamReader("../../input.txt"));
#endif
        string legendaryItem = null;
        var junkMaterialQuantityPair = new SortedDictionary<string, int>();
        var keyMaterialQuantityPair = new SortedDictionary<string, int>()
        {
            { "shards", 0 }, { "fragments", 0 }, { "motes", 0 }
        };

        string input = Console.ReadLine();
        while (!string.IsNullOrEmpty(input))
        {
            string[] material = input.Split()
                .Where((element, index) => index % 2 != 0)
                .Select(element => element.ToLower())
                .ToArray();

            int[] quantity = input.Split()
                .Where((element, index) => index % 2 == 0)
                .Select(int.Parse)
                .ToArray();

            legendaryItem =
                UpdateMaterialQuantities(keyMaterialQuantityPair, junkMaterialQuantityPair,
                    material, quantity);
            if (legendaryItem != null)
                break;

            input = Console.ReadLine();
        }

        DisplayOutput(keyMaterialQuantityPair, junkMaterialQuantityPair, legendaryItem);
    }

    private static void DisplayOutput(SortedDictionary<string, int> keyMaterialQuantityPair, SortedDictionary<string, int> junkMaterialQuantityPair, string legendaryItem)
    {
        Console.WriteLine($"{legendaryItem} obtained!");
        Console.WriteLine(string.Join("\n", keyMaterialQuantityPair
            .OrderByDescending(pair => pair.Value)
            //.ThenBy(pair => pair.Key)
            .Select(pair => $"{pair.Key}: {pair.Value}")
            .ToArray()));
        Console.WriteLine(string.Join("\n", junkMaterialQuantityPair
            .Select(pair => $"{pair.Key}: {pair.Value}")
            .ToArray()));
    }

    private static string UpdateMaterialQuantities(SortedDictionary<string, int> keyMaterialQuantityPair, SortedDictionary<string, int> junkMaterialQuantityPair, string[] material, int[] quantity)
    {
        for (int index = 0; index < material.Length; index++)
        {
            if (keyMaterialQuantityPair.ContainsKey(material[index]))
            {
                keyMaterialQuantityPair[material[index]] += quantity[index];
                if (keyMaterialQuantityPair[material[index]] >= QuantityForLegendaryItem)
                {
                    keyMaterialQuantityPair[material[index]] -= QuantityForLegendaryItem;
                    return MaterialLegendaryItemTable[material[index]];
                }
            }
            else
            {
                junkMaterialQuantityPair[material[index]] =
                    (junkMaterialQuantityPair.ContainsKey(material[index]))
                        ? quantity[index] + junkMaterialQuantityPair[material[index]]
                        : quantity[index];
            }
        }

        return null;
    }
}