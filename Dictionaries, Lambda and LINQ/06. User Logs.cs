using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var input = Console.ReadLine().Split().ToList();
                if (input[0] == "end")
                {
                    break;
                }
                var ip = input[0].Replace("IP=", "");
                var user = input[2].Replace("user=", "");

                if (!users.ContainsKey(user))
                {
                    users.Add(user, new Dictionary<string, int>());
                }
                if (!users[user].ContainsKey(ip))
                {
                    users[user][ip] = 1;
                }
                else
                {
                    users[user][ip] += 1;
                }
            }

            foreach (var user in users.Keys)
            {
                Console.WriteLine($"{user}:");
                var counter = 0;
                foreach (var ipOccurance in users[user])
                {
                    var ip = ipOccurance.Key;
                    var occurance = ipOccurance.Value;
                    counter++;
                    if (counter == users[user].Values.Count)
                    {
                        Console.Write($"{ip} => {occurance}.");
                    }
                    else Console.Write($"{ip} => {occurance}, ");
                }
                Console.WriteLine();
            }
        }
    }
}