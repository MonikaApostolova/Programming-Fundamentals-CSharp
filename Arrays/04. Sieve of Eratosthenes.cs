using System;

public class SieveOfEratosthenes
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        bool[] array = new bool[num + 1];
        for (int i = 0; i <= num; i++)
        {
            array[i] = true;
        }

        array[0] = false;
        array[1] = false;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == true)
            {
                for (int j = 2; (j * i) <= num; j++)
                {
                    array[j * i] = false;
                }
            }
        }
        for (int j = 2; j <= num; j++)
        {
            if (array[j] == true)
            { Console.Write(j + " "); }
        }
        Console.WriteLine();
    }
}