using System;

public class Program
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        for (int i = 1; i <= num; i++)
        {
            bool isDevidableBySeven = NumberIsDividableBySeven(i);
            bool hasEvenDigit = NumberHasEvenDigit(i);
            bool isSymmetric = NumberIsSymmetric(i);
            if (isDevidableBySeven && hasEvenDigit && isSymmetric)
                Console.WriteLine(i);
        }
    }

    private static bool NumberHasEvenDigit(int num)
    {
        int current = num;
        while (num > 0)
        {
            current = num % 10;
            if (current % 2 == 0)
                return true;
            num /= 10;
        }
        return false;
    }

    private static bool NumberIsDividableBySeven(int num)
    {
        int sum = 0;
        int current = num;
        while (num > 0)
        {
            current = num % 10;
            sum += current;
            num /= 10;
        }
        if (sum % 7 == 0)
            return true;
        else
            return false;
    }

    private static bool NumberIsSymmetric(int num)
    {

        string str = num.ToString();
        if (str.Length < 4 && str[0] == str[str.Length - 1])
        {
            return true;
        }
        else if (str.Length < 6 &&
                 (str[0] == str[str.Length - 1] && str[1] == str[str.Length - 2]))
        {
            return true;
        }
        else if (str.Length < 8 &&
                 (str[0] == str[str.Length - 1] && str[1] == str[str.Length - 2]
                                                && str[2] == str[str.Length - 3]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
