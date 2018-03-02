using System;
using System.Linq;

class LettersChangeNumbers
{
    static void Main()
    {
        checked
        {
            string[] inputLine = Console.ReadLine().Split().Where(a => a.Length > 0).ToArray();
            string alphabet = "0abcdefghijklmnopqrstuvwxyz";

            decimal sum = 0.0m;

            foreach (string numStr in inputLine)
            {
                char firstLetter = numStr.First();
                int firstLetterPosition = alphabet.IndexOf(firstLetter.ToString().ToLower());
                char lastLetter = numStr.Last();
                int lastLetterPosition = alphabet.IndexOf(lastLetter.ToString().ToLower());
                long num = long.Parse(string.Join("", numStr.Skip(1).Take(numStr.Length - 2)));

                if (firstLetter.ToString() == firstLetter.ToString().ToLower())
                {
                    sum += num * firstLetterPosition;
                }

                else
                {
                    sum += (decimal)num / firstLetterPosition;
                }

                if (lastLetter.ToString() == lastLetter.ToString().ToLower())
                {
                    sum += lastLetterPosition;
                }

                else
                {
                    sum -= lastLetterPosition;
                }
            }

            Console.WriteLine($"{sum:f2}");

        }

    }
}