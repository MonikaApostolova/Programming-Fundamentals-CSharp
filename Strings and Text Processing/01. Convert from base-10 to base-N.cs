using System;
using System.Collections.Generic;
using System.Numerics;

class ConvertFromBase10ToBaseN
{
    static void Main()
    {
        string[] inputLine = Console.ReadLine().Split();

        BigInteger baseN = BigInteger.Parse(inputLine[0]);
        BigInteger base10 = BigInteger.Parse(inputLine[1]);

        Stack<BigInteger> result = new Stack<BigInteger>();

        while (base10 > 0)
        {
            BigInteger remainder = base10 % baseN;
            result.Push(remainder);
            base10 /= baseN;
        }

        while (result.Count > 0)
        {
            Console.Write(result.Pop());
        }

        Console.WriteLine();
    }
}