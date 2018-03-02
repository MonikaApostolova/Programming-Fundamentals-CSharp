using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            var singers = Console.ReadLine().Split(' ', ',').Where(a => a.Length > 0).ToArray();
            var songs = Console.ReadLine().Split(',').Select(a => a.Trim()).ToArray();
            var result = new Dictionary<string, List<string>>();
            while (true)
            {
                var input = Console.ReadLine().Split(',').Select(a => a.Trim()).ToArray();
                if (input[0] == "dawn")
                    break;
                var currentSinger = input[0];
                var currentSong = input[1];
                var award = input[2];
                if (singers.Contains(currentSinger) && songs.Contains(currentSong))
                {
                    bool checker = checkIfResultContainsSinger(result, input);
                    if (checker == true)
                    {
                        if (!result[currentSinger].Contains(award))
                            result[currentSinger].Add(award);
                    }
                    else
                    {
                        result.Add(currentSinger, new List<string>());
                        result[currentSinger].Add(award);
                    }
                }
            }
            if (result.Keys.Count == 0)
            {
                Console.WriteLine("No awards");
            }
            foreach (var pair in result.OrderByDescending(a => a.Value.Count).ThenBy(a => a.Key))
            {
                var singer = pair.Key;
                var countOfAwards = pair.Value.Count();
                Console.WriteLine("{0}: {1} awards", singer, countOfAwards);
                foreach (var song in pair.Value.OrderBy(a => a))
                {
                    Console.WriteLine("--{0}", song);
                }
            }
        }


        private static bool checkIfResultContainsSinger(Dictionary<string, List<string>> result, string[] input)
        {
            var currentSinger = input[0];
            var currentSong = input[1];
            if (result.ContainsKey(currentSinger))
                return true;
            else return false;
        }
    }
}