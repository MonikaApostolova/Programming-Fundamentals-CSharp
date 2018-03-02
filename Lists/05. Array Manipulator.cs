using System;
using System.Collections.Generic;
using System.Linq;

class ArrayManipulator
{
    static void Main()
    {
        var numList = Console.ReadLine().Split().Select(long.Parse).ToList();
        var commandLine = Console.ReadLine().Split().ToArray();
        while (true)
        {
            string commandName = commandLine[0];
            if (commandName == "print")
            {
                Print(numList);
                return;
            }
            switch (commandName)
            {
                case "add":
                    ProceedToAdd(numList, commandLine);
                    break;
                case "addMany":
                    ProceedToAddMany(numList, commandLine);
                    break;
                case "contains":
                    ProceedToContains(numList, commandLine);
                    break;
                case "remove":
                    ProceedToRemove(numList, commandLine);
                    break;
                case "shift":
                    ProceedToShift(numList, commandLine);
                    break;
                case "sumPairs":
                    numList = ProceedToSumPairs(numList);
                    break;
            }
            commandLine = Console.ReadLine().Split().ToArray();
        }
    }

    private static void ProceedToAddMany(List<long> numList, string[] commandLine)
    {
        int index = int.Parse(commandLine[1]);
        List<long> elements = commandLine.Skip(2).Select(long.Parse).ToList();
        if (index >= 0 && index <= numList.Count)
        {
            numList.InsertRange(index, elements);
        }
    }

    private static void Print(List<long> numList)
    {
        Console.WriteLine(string.Format("[" + string.Join(", ", numList) + "]"));
    }

    private static List<long> ProceedToSumPairs(List<long> numList)
    {
        var resultList = new List<long>();

        if (numList.Count == 1)
        {
            resultList.Add(numList[0]);
            return resultList;
        }

        for (int index = 0; index < numList.Count - 1; index += 2)
        {
            long newNum = 0;
            newNum = numList[index] + numList[index + 1];
            resultList.Add(newNum);
        }

        if (numList.Count % 2 != 0)
        {
            resultList.Add(numList[numList.Count - 1]);
        }

        return resultList;
    }

    private static void ProceedToShift(List<long> numList, string[] commandLine)
    {
        int positions = int.Parse(commandLine[1]);
        for (int i = 0; i < positions; i++)
        {
            long elementToShift = numList.First();
            numList.RemoveAt(0);
            numList.Add(elementToShift);
        }
    }

    private static void ProceedToRemove(List<long> numList, string[] commandLine)
    {
        int index = int.Parse(commandLine[1]);
        if (index >= 0 && index < numList.Count)
        {
            numList.RemoveAt(index);
        }
    }

    private static void ProceedToContains(List<long> numList, string[] commandLine)
    {
        long element = long.Parse(commandLine[1]);
        if (numList.Contains(element))
        {
            Console.WriteLine(numList.IndexOf(element));
        }
        else
        {
            Console.WriteLine(-1);
        }
    }

    private static void ProceedToAdd(List<long> numList, string[] commandLine)
    {
        int index = int.Parse(commandLine[1]);
        long element = long.Parse(commandLine[2]);
        if (index >= 0 && index <= numList.Count)
        {
            numList.Insert(index, element);
        }
    }
}