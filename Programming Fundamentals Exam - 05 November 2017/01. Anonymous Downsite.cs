using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            checked
            {
                var count = int.Parse(Console.ReadLine());
                var tokens = int.Parse(Console.ReadLine());
                var websites = new List<string>();
                decimal TotalLoss = 0;
                var SecurityToken = BigInteger.Pow(tokens, count);
                for (int i = 0; i < count; i++)
                {
                    var input = Console.ReadLine();
                    websites.Add(input);
                }
                foreach (var website in websites)
                {
                    var splited = website.Split(' ').ToArray();
                    var name = splited[0];
                    var visits = long.Parse(splited[1]);
                    var price = decimal.Parse(splited[2]);
                    TotalLoss += price * visits;
                    Console.WriteLine(name);
                }

                Console.WriteLine("Total Loss: {0:F20}", TotalLoss);
                Console.WriteLine("Security Token: {0}", SecurityToken);
            }

        }
    }
}