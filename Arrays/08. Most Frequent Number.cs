using System;
using System.Linq;
using System.Collections.Generic;

class MostFrequentNumber
{
    static void Main()
    {
        long[] array = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var dictionaryOfNums = new Dictionary<long, int>();
        for (int index = 0; index < array.Length; index++)
        {
            long current = array[index];
            if (dictionaryOfNums.ContainsKey(current))
            {
                dictionaryOfNums[current]++;
            }
            else
            {
                dictionaryOfNums.Add(current, 1);
            }
        }
        dictionaryOfNums = dictionaryOfNums.OrderByDescending(num => num.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        KeyValuePair<long, int> number = dictionaryOfNums.First();
        Console.WriteLine(number.Key);
    }
}