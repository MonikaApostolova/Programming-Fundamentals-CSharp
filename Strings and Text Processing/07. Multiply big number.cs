using System;
using System.Numerics;

class MultiplyBigNumbers
{
    static void Main()
    {
        BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
        BigInteger secondNum = BigInteger.Parse(Console.ReadLine());
        BigInteger sum = firstNum * secondNum;

        Console.WriteLine(sum);
    }
}