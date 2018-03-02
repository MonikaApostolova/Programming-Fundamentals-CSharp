using System;

class SweetDessert
{
    static void Main()
    {
        var cashAviable = decimal.Parse(Console.ReadLine());
        var guests = decimal.Parse(Console.ReadLine());
        var bananaPrice = decimal.Parse(Console.ReadLine());
        var eggPrice = decimal.Parse(Console.ReadLine());
        var berriesPrice = decimal.Parse(Console.ReadLine());
        var sets = Math.Ceiling(guests / 6);
        decimal cashNeeded = ((2 * bananaPrice) * sets) + ((4 * eggPrice) * sets) + ((0.2m * berriesPrice) * sets);
        if (cashNeeded <= cashAviable)
            Console.WriteLine($"Ivancho has enough money - it would cost {cashNeeded:F2}lv.");
        else if (cashNeeded > cashAviable)
            Console.WriteLine($"Ivancho will have to withdraw money - he will need {(cashNeeded - cashAviable):F2}lv more.");
    }
}