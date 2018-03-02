using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var Phonebook = new SortedDictionary<string, string>();
            while (true)
            {
                var current = Console.ReadLine().Split().ToArray();
                if (current[0] == "A")
                {
                    if (!Phonebook.ContainsKey(current[1]))
                    {
                        Phonebook.Add(current[1], current[2]);
                    }
                    else
                    {
                        Phonebook[current[1]] = current[2];
                    }
                }
                else if (current[0] == "S")
                {
                    if (Phonebook.ContainsKey(current[1]))
                    {
                        Console.WriteLine($"{current[1]} -> {Phonebook[current[1]]}");
                    }
                    else Console.WriteLine("Contact {0} does not exist.", current[1]);
                }
                else if (current[0] == "END")
                {
                    break;
                }
                else if (current[0] == "ListAll")
                {
                    foreach (var key in Phonebook.Keys)
                    {
                        var value = Phonebook[key];
                        Console.WriteLine($"{key} -> {value}");
                    }
                }
            }
        }
    }
}