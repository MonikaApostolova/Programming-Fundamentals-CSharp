using System;

class Exercises
{
    static void Main()
    {
        double firstPointX = double.Parse(Console.ReadLine());
        double firstPointY = double.Parse(Console.ReadLine());
        double secondPointX = double.Parse(Console.ReadLine());
        double secondPointY = double.Parse(Console.ReadLine());
        double[] closestToCenter = FindClosestToCenter(firstPointX, firstPointY, secondPointX, secondPointY);
        PrintResult(closestToCenter);
    }

    private static void PrintResult(double[] closestToCenter)
    {
        Console.WriteLine(string.Format("(" + string.Join(", ", closestToCenter) + ")"));
    }

    private static double[] FindClosestToCenter(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
    {
        double diffFirstPoint = Math.Abs(firstPointX - 0) + Math.Abs(firstPointY - 0);
        double diffSecondPoint = Math.Abs(secondPointX - 0) + Math.Abs(secondPointY - 0);
        if (diffFirstPoint <= diffSecondPoint)
            return new double[2] { firstPointX, firstPointY };
        else
            return new double[2] { secondPointX, secondPointY };
    }
}