using System;
using System.Collections.Generic;
using System.Linq;

class MaxSequenceOfEqualElements
{
    static void Main()
    {
        var inputLine = Console.ReadLine().Split().Select(int.Parse).ToList();
        var commandLine = Console.ReadLine().Split().Select(int.Parse).ToList();
        var numberOfElementsToTake = commandLine[0];
        var numberOfElementsToDelete = commandLine[1];
        var numberToFind = commandLine[2];
        var resultList = ConstructResultList(inputLine, numberOfElementsToTake);
        DeleteGivenElementsFromList(resultList, numberOfElementsToDelete);
        bool elementIsFound = SearchForElement(resultList, numberToFind);
        if (elementIsFound)
        {
            Console.WriteLine("YES!");
        }
        else
        {
            Console.WriteLine("NO!");
        }
    }

    private static bool SearchForElement(List<int> resultList, int numberToFind)
    {
        if (resultList.Contains(numberToFind))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void DeleteGivenElementsFromList(List<int> resultList, int numberOfElementsToDelete)
    {
        resultList.RemoveRange(0, numberOfElementsToDelete);
    }

    private static List<int> ConstructResultList(List<int> inputLine, int numberOfElementsToTake)
    {
        var resultList = inputLine.Take(numberOfElementsToTake).ToList();
        return resultList;
    }
}