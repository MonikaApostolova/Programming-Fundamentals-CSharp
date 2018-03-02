using System;
using System.Collections.Generic;
using System.Linq;

public class FootballLeague
{
    public static void Main(string[] args)
    {
        string key = Console.ReadLine();

        Dictionary<string, long> goalStat = new Dictionary<string, long>();
        Dictionary<string, long> pointStat = new Dictionary<string, long>();

        while (true)
        {
            string[] encryptedResult = Console.ReadLine()
                .Trim()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (encryptedResult[0].Equals("final"))
            {
                break;
            }

            long[] gameResult = encryptedResult
                .Last()
                .Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            string[] teamsNames = new string[encryptedResult.Length - 1];

            for (int i = 0; i < teamsNames.Length; i++)
            {
                int leftNameIndex = encryptedResult[i].IndexOf(key) + key.Length;
                int rightNameIndex = encryptedResult[i].LastIndexOf(key);
                teamsNames[i] = string.Join(string.Empty, encryptedResult[i]
                    .Substring(leftNameIndex, rightNameIndex - leftNameIndex)
                    .Trim()
                    .ToUpper()
                    .Reverse());
            }

            if (teamsNames.Length > 2)
            {
                teamsNames = RemoveGarbage(teamsNames);
            }

            for (int i = 0; i < 2; i++)
            {
                AddPoints(goalStat, teamsNames[i], gameResult[i]);
            }

            if (gameResult[0] == gameResult[1])
            {
                AddPoints(pointStat, teamsNames[0], 1);
                AddPoints(pointStat, teamsNames[1], 1);
            }
            else if (gameResult[0] > gameResult[1])
            {
                AddPoints(pointStat, teamsNames[0], 3);
                AddPoints(pointStat, teamsNames[1], 0);
            }
            else
            {
                AddPoints(pointStat, teamsNames[0], 0);
                AddPoints(pointStat, teamsNames[1], 3);
            }
        }

        Console.WriteLine("League standings:");
        int number = 1;
        foreach (var team in pointStat.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{number}. {team.Key} {team.Value}");
            number++;
        }

        Console.WriteLine("Top 3 scored goals:");
        number = 1;
        foreach (var team in goalStat.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(3))
        {
            Console.WriteLine($"- {team.Key} -> {team.Value}");
        }
    }

    private static void AddPoints(Dictionary<string, long> teamPoints, string teamName, long points)
    {
        if (!teamPoints.ContainsKey(teamName))
        {
            teamPoints[teamName] = points;
        }
        else
        {
            teamPoints[teamName] += points;
        }
    }

    private static string[] RemoveGarbage(string[] encryptedResult)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < encryptedResult.Length; i++)
        {
            bool isName = true;

            for (int j = 0; j < encryptedResult[i].Length; j++)
            {
                if (!char.IsLetter(encryptedResult[i][j]))
                {
                    isName = false;
                    break;
                }
            }

            if (isName)
            {
                result.Add(encryptedResult[i]);
            }
        }

        return result.ToArray();
    }
}