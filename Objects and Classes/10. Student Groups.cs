using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var townRegex = new Regex(@"(.+)\s\=\>\s([0-9]+)\s\w+");
        var studentRegex = new Regex(@"(.+)\s*\|\s*(.+\@.+\.[^ ]*)\s*\|\s*([0-9]+\-.{3}\-[0-9]{4})");

        List<Town> towns = new List<Town>();
        string inputLine = Console.ReadLine();
        Town townFromList = new Town();

        while (inputLine != "End")
        {
            if (townRegex.IsMatch(inputLine))
            {
                Match townMatch = townRegex.Match(inputLine);
                string townName = townMatch.Groups[1].Value;
                int seatsCount = int.Parse(townMatch.Groups[2].Value);
                Town currentTown = new Town() { Name = townName, Seats = seatsCount, Students = new List<Student>() };
                townFromList = currentTown;
                towns.Add(currentTown);
                inputLine = Console.ReadLine();
            }

            else if (studentRegex.IsMatch(inputLine))
            {
                Match studentMatch = studentRegex.Match(inputLine);
                string studentName = studentMatch.Groups[1].Value;
                string studentEmail = studentMatch.Groups[2].Value;
                DateTime studentRegDate = DateTime.ParseExact(studentMatch.Groups[3].Value, "d-MMM-yyyy", CultureInfo.InvariantCulture);
                Student currentStudent = new Student() { Name = studentName, Email = studentEmail, RegDate = studentRegDate };
                townFromList.Students.Add(currentStudent);
                inputLine = Console.ReadLine();
            }
        }

        List<Group> groups = DistributeStudentsIntoGroups(towns);
        Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");

        foreach (Group group in groups)
        {
            Console.WriteLine($"{group.Town.Name} => {string.Join(", ", group.Students.Select(st => st.Email))}");
        }
    }

    private static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
    {
        var groups = new List<Group>();
        foreach (Town town in towns.OrderBy(t => t.Name))
        {
            IEnumerable<Student> students = town.Students.OrderBy(st => st.RegDate).ThenBy(st => st.Email).ThenBy(st => st.Name);
            while (students.Any())
            {
                var group = new Group();
                group.Town = town;
                group.Students = students.Take(group.Town.Seats).ToList();
                students = students.Skip(group.Town.Seats);
                groups.Add(group);
            }
        }
        return groups;
    }
}
class Student
{
    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime RegDate { get; set; }
}
class Town
{
    public string Name { get; set; }

    public List<Student> Students { get; set; }

    public int Seats { get; set; }
}
class Group
{
    public Town Town { get; set; }

    public List<Student> Students { get; set; }
}