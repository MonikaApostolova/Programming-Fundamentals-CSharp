using System;
using System.Linq;

class SumReversedNumbers
{
    static void Main()
    {
        var listOfNums = Console.ReadLine().Split().Select(long.Parse).ToList();
        for (int index = 0; index < listOfNums.Count; index++)
        {
            long currentNum = long.Parse(string.Join("", listOfNums[index].ToString().Reverse()));
            listOfNums[index] = currentNum;
        }
        long sum = listOfNums.Sum();
        Console.WriteLine(sum);
    }
}