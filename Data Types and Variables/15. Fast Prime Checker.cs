using System;
using System.Numerics;

class Junk
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        for (int i = 2; i <= num; i++)
        {
            bool isEven = true;
            for (int delio = 2; delio <= Math.Sqrt(i); delio++)
            {
                if (i % delio == 0)
                {
                    isEven = false;
                    break;
                }

            }
            Console.WriteLine($"{i} -> {isEven}");
        }
    }
}