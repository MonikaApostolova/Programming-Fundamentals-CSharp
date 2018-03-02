using System;

class CharacterMultiplier
{
    static void Main()
    {
        string[] inputLine = Console.ReadLine().Split();
        string firstStr = inputLine[0];
        string secondStr = inputLine[1];

        long result = CalculateSumOfCharacters(firstStr, secondStr);

        Console.WriteLine(result);
    }

    private static long CalculateSumOfCharacters(string firstStr, string secondStr)
    {
        long sum = 0;

        if (firstStr.Length == secondStr.Length)
        {
            for (int index = 0; index < firstStr.Length; index++)
            {
                char firstCh = firstStr[index];
                char secondCh = secondStr[index];

                sum += (firstCh * secondCh);
            }
        }

        else
        {
            string longerStr = secondStr;
            string shorterStr = firstStr;

            if (firstStr.Length > secondStr.Length)
            {
                longerStr = firstStr;
                shorterStr = secondStr;
            }

            int indexCounter = 0;

            for (int index = 0; index < shorterStr.Length; index++)
            {
                char firstCh = firstStr[index];
                char secondCh = secondStr[index];

                sum += (firstCh * secondCh);
                indexCounter++;
            }

            for (int index = indexCounter; index < longerStr.Length; index++)
            {
                char currentCh = longerStr[index];

                sum += currentCh;
            }
        }

        return sum;
    }
}