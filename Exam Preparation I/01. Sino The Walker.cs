using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DebbugingSpace
{
    class Program
    {
        static void Main(string[] args)
        {

            List<BigInteger> timeLeaving = Console.ReadLine().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse).ToList();

            BigInteger hours = timeLeaving[0];
            BigInteger minutes = timeLeaving[1];
            BigInteger seconds = timeLeaving[2];

            BigInteger timeLeavingInSeconds = hours * 3600 + minutes * 60 + seconds;

            BigInteger numberOfSteps = BigInteger.Parse(Console.ReadLine());
            BigInteger timeInSecondsPerStep = BigInteger.Parse(Console.ReadLine());

            BigInteger timeWalkingInSeconds = timeInSecondsPerStep * numberOfSteps;

            BigInteger totalTimeInSeconds = timeLeavingInSeconds + timeWalkingInSeconds;

            BigInteger arriveHour = (totalTimeInSeconds / 3600) % 24;
            BigInteger arriveMinute = (totalTimeInSeconds / 60) % 60;
            BigInteger arriveSecond = totalTimeInSeconds % 60;

            Console.WriteLine("Time Arrival: {0:00}:{1:00}:{2:00}", arriveHour, arriveMinute, arriveSecond);
        }
    }
}