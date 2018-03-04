using System;

class Program
{
    static void Main()
    {
        double money = double.Parse(Console.ReadLine());
        int studentCount = int.Parse(Console.ReadLine());
        double sabersPrice = double.Parse(Console.ReadLine());
        double robesPrice = double.Parse(Console.ReadLine());
        double beltPrice = double.Parse(Console.ReadLine());
        int freeBelts = studentCount / 6;


        double totalRobesPirce = robesPrice * studentCount;

        double totalBeltPrice = (studentCount - freeBelts) * beltPrice;

        double totalSabersPrice = Math.Ceiling(studentCount + (studentCount * 0.1)) * sabersPrice;

        double totalPrice = totalSabersPrice + totalRobesPirce + totalBeltPrice;

        if (totalPrice > money)
        {
            Console.WriteLine($"Ivan Cho will need {totalPrice - money:f2}lv more.");
        }

        else
        {
            Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
        }
    }
}