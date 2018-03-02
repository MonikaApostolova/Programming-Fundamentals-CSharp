using System;
using System.Numerics;

class Exercises
{
    static void Main()
    {
        long num = long.Parse(Console.ReadLine());
        BigInteger result = Factorial(num);
        Console.WriteLine(result);
    }

    private static BigInteger Factorial(long num)
    {
        BigInteger result = 1;
        for (int i = 1; i <= num; i++)
        {
            result *= i;
        }
        return result;
    }
}