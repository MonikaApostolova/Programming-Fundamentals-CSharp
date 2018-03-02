using System;

class Junk
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var m = int.Parse(Console.ReadLine());
        var find = int.Parse(Console.ReadLine());
        var found = false;
        var counter = 0;
        for (int i = n; i <= m; i++)
        {
            if (found == true)
                break;
            for (int j = n; j <= m; j++)
            {
                var currentSum = j + i;
                {
                    if (currentSum == find)
                    {
                        found = true;
                        Console.WriteLine($"Number found! {j} + {i} = {find}");
                        break;
                    }
                    counter++;
                }
            }
        }
        if (found == false)
        {
            Console.WriteLine($"{counter} combinations - neither equals {find}");
        }
    }
}