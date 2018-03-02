using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class MentorGroup
{
    static void Main()
    {
        var result = new List<User>();

        while (true)
        {
            string[] inputLine = Console.ReadLine().Split(' ').Where(a => a.Length > 0).ToArray();
            if (inputLine[0] == "end")
                break;
            string username = inputLine[0];
            if (inputLine.Length > 1)
            {
                List<DateTime> dates = inputLine[1]
                    .Split(',')
                    .Where(a => a.Length > 0)
                    .Select(a => DateTime.ParseExact(a, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                    .ToList();
                if (result.Where(u => u.Name == username).Count() > 0)
                {
                    User userFromList = result.Where(u => u.Name == username).First();
                    userFromList.Dates.AddRange(dates);
                }
                else
                {
                    User userToAdd = new User() { Name = username, Dates = new List<DateTime>(), Comments = new List<string>() };
                    userToAdd.Dates.AddRange(dates);
                    result.Add(userToAdd);
                }
            }
            else
            {
                result.Add(new User() { Name = username, Comments = new List<string>(), Dates = new List<DateTime>() });
            }
        }

        while (true)
        {
            string[] inputLine = Console.ReadLine().Split('-').Where(a => a.Length > 0).ToArray();
            if (inputLine[0] == "end of comments")
                break;
            string username = inputLine[0];
            if (result.Where(u => u.Name == username).Count() > 0 && inputLine.Length > 1)
            {
                User userFromList = result.Where(u => u.Name == username).First();
                userFromList.Comments.Add(inputLine[1]);
            }
        }

        foreach (User user in result.OrderBy(u => u.Name))
        {
            Console.WriteLine($"{user.Name}");
            Console.WriteLine($"Comments:");
            foreach (string comment in user.Comments)
            {
                Console.WriteLine($"- {comment}");
            }
            Console.WriteLine($"Dates attended:");
            foreach (DateTime date in user.Dates.OrderBy(u => u.Date))
            {
                Console.WriteLine($"-- {date:dd/MM/yyyy}");
            }
        }
    }
}
class User
{
    public string Name { get; set; }

    public List<DateTime> Dates { get; set; }

    public List<string> Comments { get; set; }
}