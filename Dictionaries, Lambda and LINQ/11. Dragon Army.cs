using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, Dictionary<string, List<int>>>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().ToArray();
                var type = line[0];
                var name = line[1];
                var damage = line[2];
                var health = line[3];
                var armor = line[4];

                if (damage == "null")
                {
                    damage = "45";
                }
                if (health == "null")
                {
                    health = "250";
                }
                if (armor == "null")
                {
                    armor = "10";
                }

                if (!result.ContainsKey(type))
                {
                    result[type] = new Dictionary<string, List<int>>();
                    result[type][name] = new List<int>();
                    result[type][name].Add(int.Parse(damage));
                    result[type][name].Add(int.Parse(health));
                    result[type][name].Add(int.Parse(armor));
                }
                else
                {
                    if (!result[type].ContainsKey(name))
                    {
                        result[type][name] = new List<int>();
                        result[type][name].Add(int.Parse(damage));
                        result[type][name].Add(int.Parse(health));
                        result[type][name].Add(int.Parse(armor));
                    }
                    else
                    {
                        result[type][name][0] = int.Parse(damage);
                        result[type][name][1] = int.Parse(health);
                        result[type][name][2] = int.Parse(armor);
                    }
                }
            }
            foreach (var TypeNameStats in result)
            {
                var type = TypeNameStats.Key;
                var allStats = TypeNameStats.Value.Values.ToArray();
                double damageAv = 0;
                double healthAv = 0;
                double armorAv = 0;
                for (int i = 0; i < allStats.Length; i++)
                {
                    var r = 0;
                    damageAv += allStats[i][r];
                    healthAv += allStats[i][r + 1];
                    armorAv += allStats[i][r + 2];
                }
                damageAv /= allStats.Length;
                healthAv /= allStats.Length;
                armorAv /= allStats.Length;
                Console.WriteLine($"{type}::({damageAv:f2}/{healthAv:f2}/{armorAv:f2})");
                foreach (var Type in TypeNameStats.Value.OrderBy(c => c.Key))
                {
                    var name = Type.Key;
                    var stats = Type.Value;
                    Console.WriteLine($"-{name} -> damage: {stats[0]}, health: {stats[1]}, armor: {stats[2]}");
                }
            }
        }
    }
}