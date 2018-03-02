using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();
            while (true)
            {
                var command = Console.ReadLine().Split().ToArray();
                if (command[0] == "merge")
                {
                    var startIndex = int.Parse(command[1]);
                    var endIndex = int.Parse(command[2]);
                    if (startIndex < 0)
                        startIndex = 0;
                    if (endIndex > input.Count - 1)
                        endIndex = input.Count - 1;
                    if (endIndex < 0)
                        endIndex = 0;
                    if (startIndex > input.Count - 1)
                        startIndex = input.Count - 1;
                    var elementsToMerge = input.Skip(startIndex).Take(endIndex - startIndex + 1).ToList();
                    input[startIndex] = string.Join("", elementsToMerge);
                    input.RemoveRange(startIndex + 1, endIndex - startIndex);
                }
                else if (command[0] == "divide")
                {
                    var index = int.Parse(command[1]);
                    var parts = int.Parse(command[2]);
                    var elementToDivide = input[index];
                    var LenghtNewElement = elementToDivide.Length / parts;
                    var newElement = new List<string>();
                    for (int i = 0; i < parts; i++)
                    {
                        if (i == parts - 1)
                        {
                            newElement.Add(elementToDivide.Substring(i * LenghtNewElement));
                        }
                        else
                        {
                            newElement.Add(elementToDivide.Substring(i * LenghtNewElement, LenghtNewElement));
                        }
                    }
                    input.RemoveAt(index);
                    input.InsertRange(index, newElement);
                }
                else break;
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}