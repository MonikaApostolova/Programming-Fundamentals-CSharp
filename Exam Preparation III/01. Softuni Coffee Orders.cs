using System;
using System.Linq;

class CoffeeOrders
{
    static void Main()
    {
        checked
        {
            decimal n = decimal.Parse(Console.ReadLine());
            decimal totalPrice = 0;
            for (int i = 0; i < n; i++)
            {
                var price = decimal.Parse(Console.ReadLine());
                var date = Console.ReadLine().Split('/').ToArray();
                var month = int.Parse(date[1]);
                var year = int.Parse(date[2]);
                decimal capsulesCount = decimal.Parse(Console.ReadLine());

                decimal priceForTheDay = (decimal)(DateTime.DaysInMonth(year, month) * capsulesCount) * price;
                totalPrice += priceForTheDay;
                Console.WriteLine($"The price for the coffee is: ${priceForTheDay:F2}");
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}