using System;
using System.Numerics;

class ConvertFromBase10ToBaseN
{
    static void Main()
    {
        string[] inputLine = Console.ReadLine().Split();

        BigInteger baseN = BigInteger.Parse(inputLine[0]);
        BigInteger number = BigInteger.Parse(inputLine[1]);
        int counter = 0;

        BigInteger result = 0;

        while (number > 0)
        {
            BigInteger remainder = number % 10;
            BigInteger converted = remainder * BigInteger.Pow(baseN, counter);
            result += converted;
            counter++;
            number /= 10;
        }

        Console.WriteLine(result);
    }
}