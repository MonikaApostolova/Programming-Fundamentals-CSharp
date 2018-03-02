using System;
using System.Text;

class UnicodeCharacters
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        StringBuilder result = new StringBuilder();

        foreach (char ch in inputLine)
        {
            result.Append("\\u" + ((int)ch).ToString("X4").ToLower());
        }

        Console.WriteLine(result);
    }
}