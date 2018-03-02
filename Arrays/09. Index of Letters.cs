using System;

class IndexOfLetters
{
    static void Main()
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string input = Console.ReadLine();
        foreach (char ch in input)
        {
            int index = alphabet.IndexOf(ch);
            Console.WriteLine($"{ch} -> {index}");
        }
    }
}