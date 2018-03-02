using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Snowballs
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var snowballsCollection = new List<Snowball>();
        for (int i = 0; i < n; i++)
        {
            int snow = int.Parse(Console.ReadLine());
            int time = int.Parse(Console.ReadLine());
            int quality = int.Parse(Console.ReadLine());
            var currentSnowball = new Snowball()
            {
                Snow = snow,
                Time = time,
                Quality = quality
            };
            snowballsCollection.Add(currentSnowball);
        }
        var result = snowballsCollection.OrderByDescending(ball => ball.Value).ThenByDescending(ball => ball.Snow).First();
        Console.WriteLine($"{result.Snow} : {result.Time} = {result.Value} ({result.Quality})");
    }
}
class Snowball
{
    public int Snow { get; set; }

    public int Time { get; set; }

    public int Quality { get; set; }

    public BigInteger Value { get { return BigInteger.Pow((Snow / Time), Quality); } }
}