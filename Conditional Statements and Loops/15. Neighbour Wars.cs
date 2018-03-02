using System;

class Junk
{
    static void Main()
    {
        var PeshoDamage = int.Parse(Console.ReadLine());
        var GoshoDamage = int.Parse(Console.ReadLine());
        var rounds = 0;
        var PeshoHealth = 100;
        var GoshoHealth = 100;
        while (true)
        {
            if (rounds >= 3 && rounds % 3 == 0)
            {
                GoshoHealth += 10;
                PeshoHealth += 10;
            }
            if (rounds % 2 == 0)
            {
                rounds++;
                GoshoHealth -= PeshoDamage;
                if (GoshoHealth <= 0)
                {
                    Console.WriteLine($"Pesho won in {rounds}th round.");
                    break;
                }
                Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {GoshoHealth} health.");
            }
            else
            {
                rounds++;
                PeshoHealth -= GoshoDamage;
                if (PeshoHealth <= 0)
                {
                    Console.WriteLine($"Gosho won in {rounds}th round.");
                    break;
                }
                Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {PeshoHealth} health.");
            }
        }

    }
}