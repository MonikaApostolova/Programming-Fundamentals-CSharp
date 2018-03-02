using System;
using System.Collections.Generic;
using System.Linq;

class TeamworkProjects
{
    static void Main()
    {
        int countOfTeams = int.Parse(Console.ReadLine());
        var listOfCreators = new List<string>();
        var result = new List<Team>();

        for (int i = 0; i < countOfTeams; i++)
        {
            string[] inputLine = Console.ReadLine().Split('-');
            string creatorName = inputLine[0];
            string teamName = inputLine[1];
            if (result.Where(t => t.Name == teamName).Count() == 0 && !listOfCreators.Contains(creatorName))
            {
                result.Add(new Team() { Name = teamName, Creator = creatorName, Members = new List<string>() });
                listOfCreators.Add(creatorName);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }
            else if (result.Where(t => t.Name == teamName).Count() > 0)
            {
                Console.WriteLine($"Team {teamName} was already created!");
            }
            else if (listOfCreators.Contains(creatorName))
            {
                Console.WriteLine($"{creatorName} cannot create another team!");
            }
        }

        while (true)
        {
            string[] inputLine = Console.ReadLine().Split('-', '>').Where(a => a.Length > 0).ToArray();
            if (inputLine[0] == "end of assignment")
                break;
            string memberName = inputLine[0];
            string teamName = inputLine[1];

            if (result.Where(t => t.Name == teamName).Count() > 0)
            {
                Team teamFromList = result.Where(t => t.Name == teamName).First();
                if (result.Where(t => t.Members.Contains(memberName)).Count() > 0 || result.Where(t => t.Creator == memberName).Count() > 0)
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                }
                else if (result.Where(t => t.Creator == memberName).Count() == 0)
                {
                    teamFromList.Members.Add(memberName);
                }
            }
            else
            {
                Console.WriteLine($"Team {teamName} does not exist!");
            }
        }

        bool disbandIsWritten = false;

        foreach (Team team in result.OrderByDescending(t => t.Members.Count()).ThenBy(t => t.Name))
        {


            if (team.Members.Count > 0)
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(name => name))
                {
                    Console.WriteLine($"-- {member}");
                }
                continue;
            }
            if (disbandIsWritten == false)
            {
                Console.WriteLine($"Teams to disband:");
                disbandIsWritten = true;
            }
            Console.WriteLine($"{team.Name}");

        }
        if (disbandIsWritten == false)
        {
            Console.WriteLine($"Teams to disband:");
        }
    }
}
class Team
{
    public string Name { get; set; }

    public string Creator { get; set; }

    public List<string> Members { get; set; }
}