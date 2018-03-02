using System;
using System.Linq;

class SumReversedNumbers
{
    static void Main()
    {
        var listOfNums = Console.ReadLine().Split().Select(int.Parse).ToList();
        int[] bombArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int bombElement = bombArgs[0];
        int bombRadius = bombArgs[1];
        for (int i = 0; i < listOfNums.Count; i++)
        {
            int current = listOfNums[i];
            if (current == bombElement)
            {
                int startIndex = i - bombRadius;
                if (startIndex < 0)
                {
                    startIndex = 0;
                }
                int endIndex = i + bombRadius;
                if (endIndex > listOfNums.Count - 1)
                {
                    endIndex = listOfNums.Count - 1;
                }
                int count = endIndex - startIndex + 1;
                listOfNums.RemoveRange(startIndex, count);
                i = 0;
            }
        }
        int sum = listOfNums.Sum();
        Console.WriteLine(sum);
    }
}