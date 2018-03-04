using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int[] result = new int[count];
        int bestLength = 0;
        int bestIndex = 0;
        int seqIndex = 1;
        int counter = 1;

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Clone them!")
            {
                break;
            }
            
            int[] currSeq = input.Split(new [] {'!'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int currLength = 0;
            int startIndex = 0;

            for (int i = 0; i < currSeq.Length; i++)
            {
                if (currSeq[i] == 1)
                {
                    currLength++;

                    if (currLength > bestLength)
                    {
                        result = currSeq;
                        bestIndex = startIndex;
                        bestLength = currLength;
                        seqIndex = counter;
                    }

                    else if (currLength == bestLength)
                    {
                        if (startIndex < bestIndex)
                        {
                            result = currSeq;
                            bestIndex = startIndex;
                            bestLength = currLength;
                            seqIndex = counter;
                        }

                        else if (startIndex == bestIndex && currSeq.Sum() > result.Sum())
                        {
                            result = currSeq;
                            bestIndex = startIndex;
                            bestLength = currLength;
                            seqIndex = counter;
                        }
                    }
                }

                else
                {
                    currLength = 0;
                    startIndex = i + 1;
                }

                
            }

            counter++;
        }

        Console.WriteLine($"Best DNA sample {seqIndex} with sum: {result.Sum()}.");
        Console.WriteLine(string.Join(" ", result));
    }
}