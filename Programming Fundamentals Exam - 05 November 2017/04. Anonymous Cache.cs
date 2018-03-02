using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var dataSets = new List<string>();
        var storage = new Dictionary<string, Dictionary<string, long>>();
        while (true)
        {
            var input = Console.ReadLine().Split(' ', '-', '>', '|').Where(a => a.Length > 0).ToArray();
            if (input[0] == "thetinggoesskrra")
                break;
            if (input.Length == 1)
            {
                dataSets.Add(input[0]);
            }
            else
            {
                var dataKey = input[0];
                var dataSize = long.Parse(input[1]);
                var dataSet = input[2];
                if (storage.ContainsKey(dataSet))
                {
                    storage[dataSet].Add(dataKey, dataSize);
                }
                else
                {
                    storage.Add(dataSet, new Dictionary<string, long>());
                    storage[dataSet].Add(dataKey, dataSize);
                }
            }
        }
        storage = storage.OrderByDescending(a => a.Value.Values.Sum()).ToDictionary(a => a.Key, a => a.Value);
        foreach (var item in storage)
        {
            var dataSet = item.Key.ToString();
            if (dataSets.Contains(dataSet))
            {
                var sum = item.Value.Values.Sum();
                Console.WriteLine("Data Set: {0}, Total Size: {1}", dataSet, sum);
                foreach (var key in item.Value)
                {
                    var dataKey = key.Key;
                    Console.WriteLine("$.{0}", dataKey);
                }
                break;
            }
        }
    }
}