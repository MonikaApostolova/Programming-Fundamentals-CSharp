using System;
using System.Linq;

class Exercises
{
    static void Main()
    {
        var num = long.Parse(Console.ReadLine());
        long check = IsPrime(num);
        bool isPrime = false;
        if (check == 1)
            isPrime = true;
        Console.WriteLine(isPrime);
    }

    private static long IsPrime(long number)
    {
        if (number <= 1) return 0;
        long i;
        for (i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return 0;
        }
        return 1;
    }
}