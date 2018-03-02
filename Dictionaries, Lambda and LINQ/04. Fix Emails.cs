using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            var emails = new Dictionary<string, string>();
            while (true)
            {
                var name = Console.ReadLine();
                if (name == "stop")
                {
                    break;
                }
                var email = Console.ReadLine();
                var country = GetLetters(email);
                if (country.ToLower() != "uk" && country.ToLower() != "us")
                {
                    emails.Add(name, email);
                }
            }
            foreach (var name in emails.Keys)
            {
                var email = emails[name];
                Console.WriteLine($"{name} -> {email}");
            }
        }
        static string GetLetters(string email)
        {
            var letter = new List<char>();
            foreach (char ch in email)
            {
                letter.Add(ch);
            }
            var result = letter[letter.Count - 2].ToString() + letter[letter.Count - 1].ToString();
            return result;
        }
    }
}