using System;
using System.Collections.Generic;
using System.Linq;

class MaxSequenceOfEqualElements
{
    static void Main()
    {
        var listOfNums = Console.ReadLine().Split().Select(double.Parse).ToList();

        while (true)
        {
            var inputLine = Console.ReadLine().Split().ToArray();
            if (inputLine[0] == "Odd")
            {
                ProceedToOdd(listOfNums);
                return;
            }
            if (inputLine[0] == "Even")
            {
                ProceedToEven(listOfNums);
                return;
            }
            var command = inputLine[0];
            switch (command)
            {
                case "Delete":
                    ProceedToDeleteCommand(inputLine, listOfNums);
                    break;
                case "Insert":
                    ProceedToInsertCommand(inputLine, listOfNums);
                    break;
            }
        }
    }

    private static void ProceedToEven(List<double> listOfNums)
    {
        var result = new List<double>();
        foreach (var num in listOfNums)
        {
            if (num % 2 == 0)
            {
                result.Add(num);
            }
        }
        Console.WriteLine(string.Join(" ", result));
    }

    private static void ProceedToOdd(List<double> listOfNums)
    {
        var result = new List<double>();
        foreach (var num in listOfNums)
        {
            if (num % 2 != 0)
            {
                result.Add(num);
            }
        }
        Console.WriteLine(string.Join(" ", result));
    }

    private static void ProceedToInsertCommand(string[] inputLine, List<double> listOfNums)
    {
        var elementToInsert = double.Parse(inputLine[1]);
        var index = int.Parse(inputLine[2]);
        listOfNums.Insert(index, elementToInsert);
    }

    private static void ProceedToDeleteCommand(string[] inputLine, List<double> listOfNums)
    {
        var elementToDelete = double.Parse(inputLine[1]);
        for (int i = 0; i < listOfNums.Count; i++)
        {
            if (listOfNums[i] == elementToDelete)
            {
                listOfNums.Remove(listOfNums[i]);
                i--;
            }
        }
    }
}