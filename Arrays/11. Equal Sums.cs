using System;
using System.Collections.Generic;
using System.Linq;

class IndexOfLetters
{
    static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToList();
        var result = new List<int>();

        for (int i = 0; i < input.Count; i++)
        {
            int index = i;
            int[] firstHalf = input.Take(index).ToArray();
            int[] secondHalf = input.Skip(index + 1).ToArray();
            if (firstHalf.Sum() == secondHalf.Sum())
            {
                result.Add(index);
            }
        }
        if (result.Count > 0)
        {
            Console.WriteLine(string.Join(" ", result));
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}