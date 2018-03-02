using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex3
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ', ',').Where(a => a.Length > 0).ToArray();
            var healthRegex = new Regex(@"[^0-9\+\-\*\/\.]");
            var damageRegex = new Regex(@"\+?\-?[0-9]+(?:\.[0-9]*)?");
            var demons = new List<Demon>();
            foreach (var demon in input)
            {
                var Name = demon;
                var health = healthRegex.Matches(Name);
                var Health = 0;
                foreach (Match match in health)
                {
                    var point = char.Parse(match.Value);
                    Health += point;
                }
                var damage = damageRegex.Matches(Name);
                var Damage = 0.0;
                foreach (Match match in damage)
                {
                    var point = double.Parse(match.Value);
                    Damage += point;
                }
                foreach (char ch in Name)
                {
                    if (ch == '*')
                    {
                        Damage = Damage * 2;
                    }
                    if (ch == '/')
                    {
                        Damage = Damage / 2;
                    }
                }
                var currentDemon = new Demon()
                {
                    Name = Name,
                    Health = Health,
                    Damage = Damage
                };
                demons.Add(currentDemon);
            }
            foreach (var demon in demons.OrderBy(a => a.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }
    }

    class Demon
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }
    }
}
