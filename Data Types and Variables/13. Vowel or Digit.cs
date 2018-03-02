using System;
using System.Numerics;

class Junk
{
    static void Main()
    {
        var input = char.Parse(Console.ReadLine().ToLower());
        var isDigit = Char.IsNumber(input);
        var isVowel = input == 'a' || input == 'o' || input == 'u' || input == 'e' || input == 'i';
        if (isDigit)
            Console.WriteLine("digit");
        else if (isVowel)
            Console.WriteLine("vowel");
        else
            Console.WriteLine("other");
    }
}