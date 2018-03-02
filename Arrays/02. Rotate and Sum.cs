using System;
using System.Linq;

class Rotate¿ndSum
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rotate = int.Parse(Console.ReadLine());
        int[] sum = new int[numbers.Length];

        for (int i = 0; i < rotate; i++)
        {
            int[] newNumbers = new int[numbers.Length];

            for (int index = 0; index <= numbers.Length - 1; index++)
            {
                int lastDigit = numbers[numbers.Length - 1];
                if (index == 0)
                {
                    newNumbers[0] = lastDigit;
                }
                else
                {
                    newNumbers[index] = numbers[index - 1];
                }

                sum[index] = newNumbers[index] + sum[index];
            }

            numbers = newNumbers;
        }

        Console.WriteLine(string.Join(" ", sum));
    }
}