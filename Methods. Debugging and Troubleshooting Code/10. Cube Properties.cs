using System;

class Junk
{
    static void Main()
    {
        double side = double.Parse(Console.ReadLine());
        double result = 0.0;
        string command = Console.ReadLine();
        if (command == "face")
            result = ProceedToFaceCommand(side);
        else if (command == "space")
            result = ProceedToSpaceCommand(side);
        else if (command == "volume")
            result = ProceedToVolumeCommand(side);
        else if (command == "area")
            result = ProceedToAreaCommand(side);
        Console.WriteLine($"{result:F2}");
    }

    private static double ProceedToAreaCommand(double side)
    {
        return 6 * Math.Pow(side, 2);
    }

    private static double ProceedToVolumeCommand(double side)
    {
        return Math.Pow(side, 3);
    }

    private static double ProceedToFaceCommand(double side)
    {
        return Math.Sqrt(2 * Math.Pow(side, 2));
    }

    private static double ProceedToSpaceCommand(double side)
    {
        return Math.Sqrt(3 * Math.Pow(side, 2));
    }
}