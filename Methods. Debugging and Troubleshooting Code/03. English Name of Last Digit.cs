using System;
using System.Linq;

class Exercises
{
    static void Main()
    {
        var num = Console.ReadLine();
        string nameOfLastDigit = DigitToSting(num);
        Console.WriteLine(nameOfLastDigit);
    }

    private static string DigitToSting(string num)
    {
        var digit = num.ToCharArray().Last();
        if (digit == '0')
            return "zero";
        else if (digit == '1')
            return "one";
        else if (digit == '2')
            return "two";
        else if (digit == '3')
            return "three";
        else if (digit == '4')
            return "four";
        else if (digit == '5')
            return "five";
        else if (digit == '6')
            return "six";
        else if (digit == '7')
            return "seven";
        else if (digit == '8')
            return "eight";
        else
            return "nine";
    }
}