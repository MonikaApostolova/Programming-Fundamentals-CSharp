using System;

class Junk
{
    static void Main()
    {
        var first = char.Parse(Console.ReadLine());
        var second = char.Parse(Console.ReadLine());
        var skip = char.Parse(Console.ReadLine());
        for (char i = first; i <= second; i++)
        {
            for (char j = first; j <= second; j++)
            {
                for (char k = first; k <= second; k++)
                {
                    if (i == skip || j == skip || k == skip)
                        continue;
                    else
                        Console.Write($"{i}{j}{k} ");
                }
            }
        }
    }
}