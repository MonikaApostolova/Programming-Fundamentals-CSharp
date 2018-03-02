using System;
using System.Collections.Generic;

class Primes_in_Given_Range
{
    static void Main()
    {
        int startNumber = int.Parse(Console.ReadLine());
        int stopNumber = int.Parse(Console.ReadLine());
        var result = GetPrimeNumbers(startNumber, stopNumber);
        Console.WriteLine(string.Join(", ", result));
    }
    private static List<int> GetPrimeNumbers(int start, int stop)
    {
        var result = new List<int>();
        for (int i = start; i <= stop; i++)
        {
            bool isPrime = true;
            if (i < 2) isPrime = false;
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                result.Add(i);
            }
        }
        return result;
    }
}