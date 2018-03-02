using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine().ToLower();
        int count = int.Parse(Console.ReadLine());
        int index = count;
        bool isMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            char current = text[i];
            if (text[i] == 'p')
            {
                isMatch = true;
                if (index >= text.Length - i)
                    index = text.Length - i - 1;
                string matchedString = text.Substring(i, index + 1);
                Console.WriteLine(matchedString);
                i += index;
            }
        }

        if (!isMatch)
        {
            Console.WriteLine("no");
        }
    }
}