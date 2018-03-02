using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Phrases =
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product.",
            };
            string[] Events =
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself",
                "I am very satisfied.",
                "I feel great!"
            };
            string[] Authors =
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };
            string[] Cities =
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };
            Random random = new Random();
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var Phrase = Phrases[random.Next(0, Phrases.Length)];
                var Event = Events[random.Next(0, Events.Length)];
                var Author = Authors[random.Next(0, Authors.Length)];
                var City = Cities[random.Next(0, Cities.Length)];
                Console.WriteLine("{0} {1} {2} – {3}.",
                    Phrase, Event, Author, City);
            }
        }
    }
}