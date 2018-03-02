using System;
using System.Numerics;

class Exercises
{
    static void Main()
    {
        long num = long.Parse(Console.ReadLine());
        BigInteger result = Factorial(num);
        long trailingZeros = CountTrailingZeros(result);
        Console.WriteLine(trailingZeros);
    }

    private static long CountTrailingZeros(BigInteger result)
    {
        BigInteger current = 0;
        long output = 0;
        while (current == 0)
        {
            current = result % 10;
            if (current != 0)
                break;
            else
                output++;
            result /= 10;
        }
        return output;
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