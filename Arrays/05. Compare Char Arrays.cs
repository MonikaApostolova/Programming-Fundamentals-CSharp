using System;
using System.Linq;

public class CompareCharArrays
{
    public static void Main()
    {
        string firstWord = string.Join("", Console.ReadLine().Split().Select(char.Parse).ToArray());
        string secondWord = string.Join("", Console.ReadLine().Split().Select(char.Parse).ToArray());
        string[] result = new string[2]
        {
            firstWord,
            secondWord
        };
        result = result.OrderBy(w => w).ToArray();
        Console.WriteLine(result[0]);
        Console.WriteLine(result[1]);
    }
}