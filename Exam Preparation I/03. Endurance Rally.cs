using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            var racers = Console.ReadLine().Split(' ').ToArray();
            var track = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var stops = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int racer = 0; racer < racers.Length; racer++)
            {
                double fuel = racers[racer].ToCharArray().First();
                int position = 0;
                for (int currentPoint = 0; currentPoint < track.Length; currentPoint++)
                {
                    //Add
                    if (stops.Contains(currentPoint))
                    {
                        fuel += track[currentPoint];
                    }
                    //Remove
                    else
                    {
                        fuel -= track[currentPoint];
                    }

                    if (fuel <= 0)
                        break;
                    position++;
                }
                if (fuel <= 0)
                    Console.WriteLine("{0} - reached {1}", racers[racer], position);
                else
                    Console.WriteLine("{0} - fuel left {1:F2}", racers[racer], fuel);
            }
        }
    }
}