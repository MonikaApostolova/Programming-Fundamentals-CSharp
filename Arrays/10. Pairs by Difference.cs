using System;
using System.Linq;

class IndexOfLetters
{
    static void Main()
    {
        checked
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int index = 0; index < inputArray.Length - 1; index++)
            {
                int current = inputArray[index];
                for (int secondIndex = index + 1; secondIndex < inputArray.Length; secondIndex++)
                {
                    int next = inputArray[secondIndex];
                    if (Math.Abs(current - next) == diff)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}