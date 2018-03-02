using System;
using System.Collections.Generic;
using System.Linq;

class HandsOfCards
{
    static void Main()
    {
        var result = new List<Player>();
        while (true)
        {
            string[] inputLine = Console.ReadLine().Split(':').Where(a => a.Length > 0).ToArray();
            Dictionary<string, int> powers = new Dictionary<string, int>()
            {
                { "2", 2},{ "3", 3},{ "4", 4},{ "5", 5},{ "6", 6},{ "7", 7},{ "8", 8},{ "9", 9},{ "10", 10},{ "J", 11},{ "Q", 12},
                { "K", 13},{ "A", 14}
            };
            Dictionary<string, int> types = new Dictionary<string, int>()
            {
                { "S", 4}, { "H", 3}, { "D", 2}, { "C", 1}
            };

            if (inputLine[0] == "JOKER")
            {
                break;
            }

            string playerName = inputLine[0];
            List<string> playerCards = inputLine[1].Split(' ', ',').Where(a => a.Length > 0).ToList();
            playerCards = playerCards.Distinct().ToList();

            if (result.Where(pl => pl.Name == playerName).Count() > 0)
            {
                Player playerFromList = result.Where(pl => pl.Name == playerName).First();
                foreach (var card in playerFromList.Deck)
                {
                    if (playerCards.Contains(card))
                    {
                        playerCards.Remove(card);
                    }
                }
                foreach (var card in playerCards)
                {
                    KeyValuePair<string, int> cardPower = powers.Where(p => p.Key == card.Substring(0, card.Length - 1)).First();
                    KeyValuePair<string, int> cardType = types.Where(p => p.Key == card.Substring(card.Length - 1, 1)).First();
                    int cardPoints = cardPower.Value + cardType.Value;
                    playerFromList.Points += cardPower.Value * cardType.Value;
                }
            }
            else
            {
                int cardPoints = 0;
                foreach (var card in playerCards)
                {
                    KeyValuePair<string, int> cardPower = powers.Where(p => p.Key == card.Substring(0, card.Length - 1)).First();
                    KeyValuePair<string, int> cardType = types.Where(p => p.Key == card.Substring(card.Length - 1, 1)).First();
                    cardPoints += cardPower.Value * cardType.Value;
                }
                result.Add(new Player() { Name = playerName, Deck = playerCards, Points = cardPoints });
            }
        }
        foreach (Player player in result)
        {
            Console.WriteLine($"{player.Name}: {player.Points}");
        }
    }
}
class Player
{
    public string Name { get; set; }

    public List<string> Deck { get; set; }

    public int Points { get; set; }
}