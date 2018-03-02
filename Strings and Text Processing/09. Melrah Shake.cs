using System;

class MelrahShake
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = Console.ReadLine();

        while (true)
        {
            int firstMatchIndex = input.IndexOf(pattern);

            if (firstMatchIndex >= 0)
            {
                input = input.Remove(firstMatchIndex, pattern.Length);
            }

            int lastMatchIndex = input.LastIndexOf(pattern);

            if (lastMatchIndex >= 0)
            {
                input = input.Remove(lastMatchIndex, pattern.Length);
            }

            if (firstMatchIndex >= 0 && lastMatchIndex >= 0 && pattern.Length > 0)
            {
                Console.WriteLine($"Shaked it.");
                if (pattern.Length > 0)
                {
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                }
            }
            else
            {
                Console.WriteLine($"No shake.");
                Console.WriteLine(input);
                break;
            }
        }
    }
}