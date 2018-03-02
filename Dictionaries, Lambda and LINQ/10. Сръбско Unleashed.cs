using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class SrabskotoUnleashed
{
    static void Main()
    {
        var regex = new Regex(@"^(.+)\s\@(.+)\s([0-9]+)\s([0-9]+)$");
        var result = new List<Event>();

        while (true)
        {
            string inputLine = Console.ReadLine();

            if (inputLine == "End")
            {
                break;
            }

            bool isMatch = regex.IsMatch(inputLine);

            if (isMatch)
            {
                var match = regex.Match(inputLine);
                string singer = match.Groups[1].Value;
                string venue = match.Groups[2].Value;
                double ticketPrice = double.Parse(match.Groups[3].Value);
                long ticketsCount = long.Parse(match.Groups[4].Value);
                double totalMoney = ticketPrice * ticketsCount;

                if (result.Where(ev => ev.Venue == venue).Count() > 0)
                {
                    var eventFromList = result.Where(ev => ev.Venue == venue).First();
                    if (eventFromList.SingersAndMoney.ContainsKey(singer))
                    {
                        eventFromList.SingersAndMoney[singer] += totalMoney;
                    }
                    else
                    {
                        eventFromList.SingersAndMoney.Add(singer, totalMoney);
                    }
                }
                else
                {
                    result.Add(new Event() { Venue = venue, SingersAndMoney = new Dictionary<string, double>() { { singer, totalMoney } } });
                }
            }
        }

        foreach (var ev in result)
        {
            Console.WriteLine(ev.Venue);
            foreach (var singerAndMoney in ev.SingersAndMoney.OrderByDescending(sm => sm.Value))
            {
                Console.WriteLine($"#  {singerAndMoney.Key} -> {singerAndMoney.Value}");
            }
        }
    }
}
class Event
{
    public string Venue { get; set; }

    public Dictionary<string, double> SingersAndMoney { get; set; }
}