using System;
using System.Collections.Generic;
using System.Linq;

class P04_LongestIncreasingSubsequenceV2
{
    static void Main()
    {
        var numList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var count = numList.Count;
        var lengths = new int[count].Select(n => n = 1).ToArray();
        var previousLongestEndIndex = lengths.Select(n => n = -1).ToArray();
        var bestLength = 0;
        var lastIndex = -1;
        for (int p = 1; p < count; p++)
        {
            var anchorNum = numList[p];
            for (int j = 0; j < p; j++)
            {
                var currentNum = numList[j];
                if (currentNum < anchorNum && lengths[j] == lengths[p])
                {
                    lengths[p]++;
                    previousLongestEndIndex[p] = j;
                }

                if (lengths[p] > bestLength)
                {
                    bestLength = lengths[p];
                    lastIndex = p;
                }
            }
        }

        var maxSubsequenceIndex = Array.IndexOf(lengths, lengths.Max());
        var maxSubcequence = new List<int>();
        for (int i = maxSubsequenceIndex; i >= 0;)
        {
            maxSubcequence.Add(numList[i]);
            i = previousLongestEndIndex[i];
        }
        maxSubcequence.Reverse();
        Console.WriteLine(string.Join(" ", maxSubcequence));
    }
}