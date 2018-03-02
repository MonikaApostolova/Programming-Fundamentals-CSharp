using System;

class Junk
{
    static void Main()
    {
        string figureType = Console.ReadLine().ToLower();
        if (figureType == "triangle")
            ProceedToTriangle();
        else if (figureType == "square")
            ProceedToSquare();
        else if (figureType == "rectangle")
            ProceedToRectangle();
        else if (figureType == "circle")
            ProceedToCircle();
    }

    private static void ProceedToCircle()
    {
        double radius = double.Parse(Console.ReadLine());
        double area = Math.PI * radius * radius;
        Console.WriteLine($"{area:F2}");
    }

    private static void ProceedToRectangle()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double area = a * b;
        Console.WriteLine($"{area:F2}");
    }

    private static void ProceedToSquare()
    {
        double a = double.Parse(Console.ReadLine());
        double area = a * a;
        Console.WriteLine($"{area:F2}");
    }

    private static void ProceedToTriangle()
    {
        double side = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        double area = 0.5 * (side * height);
        Console.WriteLine($"{area:F2}");
    }
}