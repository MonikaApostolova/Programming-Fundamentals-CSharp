using System;
using System.Linq;

class MagicExchangeableWords
{
    static void Main()
    {
        string[] inputLine = Console.ReadLine().Split();

        string firstStr = string.Join("", inputLine[0].Distinct());
        string seconStr = string.Join("", inputLine[1].Distinct());

        if (firstStr.Length == seconStr.Length)
        {
            Console.WriteLine("true");
        }

        else
        {
            Console.WriteLine("false");
        }
    }
}