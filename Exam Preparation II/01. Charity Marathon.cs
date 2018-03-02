using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int runners = int.Parse(Console.ReadLine());
            int laps = int.Parse(Console.ReadLine());
            int lapLength = int.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            decimal moneyPerKm = decimal.Parse(Console.ReadLine());
            if (runners > trackCapacity * days)
            {
                runners = trackCapacity * days;
            }

            BigInteger meters = (BigInteger)runners * laps * lapLength;
            BigInteger km = (BigInteger)meters / 1000;
            Decimal money = moneyPerKm * (Decimal)km;
            Console.WriteLine("Money raised: {0:F2}", money);
        }
    }
}