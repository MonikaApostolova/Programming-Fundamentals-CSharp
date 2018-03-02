using System;
using System.Linq;

class IntersectionOfCircles
{
    static void Main()
    {
        int[] firstCircleData = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] secondCircleData = Console.ReadLine().Split().Select(int.Parse).ToArray();

        bool intersect = Intersect(firstCircleData, secondCircleData);

        if (intersect)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }

    private static bool Intersect(int[] firstCircleData, int[] secondCircleData)
    {
        int x1 = firstCircleData[0];
        int y1 = firstCircleData[1];
        int x2 = secondCircleData[0];
        int y2 = secondCircleData[1];
        int r1 = firstCircleData[2];
        int r2 = secondCircleData[2];

        double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

        if (distance <= r1 + r2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}