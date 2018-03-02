using System;
using System.Linq;

class LargestCommonEnd
{
    static void Main()
    {
        string[] firstArray = Console.ReadLine().Split(' ').ToArray();
        string[] secondArray = Console.ReadLine().Split(' ').ToArray();

        string[] firstArrayReversed = new string[firstArray.Length];
        string[] secondArrayReversed = new string[secondArray.Length];

        for (int index = 0; index < firstArray.Length; index++)
        {
            firstArrayReversed[index] = firstArray[firstArray.Length - 1 - index];
        }

        for (int index = 0; index < secondArray.Length; index++)
        {
            secondArrayReversed[index] = secondArray[secondArray.Length - 1 - index];
        }

        int countFromLeft = 0;
        int countFromRight = 0;

        for (int index = 0; index < Math.Min(firstArray.Length, secondArray.Length); index++)
        {
            if (firstArray[index] == secondArray[index])
            {
                countFromLeft++;
            }
            else break;
        }

        for (int index = 0; index < Math.Min(firstArrayReversed.Length, secondArrayReversed.Length); index++)
        {
            if (firstArrayReversed[index] == secondArrayReversed[index])
            {
                countFromRight++;
            }
            else break;
        }

        Console.WriteLine(Math.Max(countFromLeft, countFromRight));
    }
}