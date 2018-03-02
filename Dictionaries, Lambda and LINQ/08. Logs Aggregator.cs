using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new SortedDictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var ip = input[0];
                var user = input[1];
                var duration = int.Parse(input[2]);

                if (!result.ContainsKey(user))
                {
                    result[user] = new Dictionary<string, int>();

                    if (!result[user].ContainsKey(ip))
                    {
                        result[user][ip] = duration;
                    }
                    else result[user][ip] += duration;
                }
                else
                {
                    if (!result[user].ContainsKey(ip))
                    {
                        result[user][ip] = duration;
                    }
                    else result[user][ip] += duration;
                }
            }
            foreach (var User in result)
            {
                var counter = 1;
                var user = User.Key;
                var durationSum = User.Value.Values.Sum();
                Console.Write($"{user}: ");
                Console.Write($"{durationSum} [");
                foreach (var ip in User.Value.OrderBy(c => c.Key))
                {
                    if (counter == User.Value.Count)
                    {
                        Console.Write($"{ip.Key}");
                    }
                    else Console.Write($"{ip.Key}, ");
                    counter++;
                }
                Console.WriteLine("]");
            }
        }
    }
}