using System;
using System.Collections.Generic;
using System.Linq;

class CommandInterpreter
{
    static void Main()
    {
        checked
        {
            var input = Console.ReadLine().Split().Where(a => a.Length > 0).ToList();
            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine == "end")
                    break;
                var command = inputLine.Split().Where(a => a.Length > 0).ToArray();
                bool isValid = true;
                if (command[0] == "reverse")
                    isValid = ProceedToReverse(command, input);
                else if (command[0] == "sort")
                    isValid = ProceedToSort(command, input);
                else if (command[0] == "rollLeft" && int.Parse(command[1]) >= 0)
                    ProceedToRollLeft(command, input);
                else if (command[0] == "rollRight" && int.Parse(command[1]) >= 0)
                    ProceedToRollRight(command, input);
                else Console.WriteLine("Invalid input parameters.");
                if (isValid == false) Console.WriteLine("Invalid input parameters.");
            }
            Console.WriteLine("[" + string.Join(", ", input) + "]");
        }

    }

    private static void ProceedToRollRight(string[] command, List<string> input)
    {
        var count = Math.Abs(int.Parse(command[1]));
        for (int i = 0; i < count; i++)
        {
            var elementToRoll = input.Last();
            input.RemoveAt(input.Count - 1);
            input.Insert(0, elementToRoll);
        }
    }

    private static void ProceedToRollLeft(string[] command, List<string> input)
    {
        var count = Math.Abs(int.Parse(command[1]));
        for (int i = 0; i < count; i++)
        {
            var elementToRoll = input.First();
            input.RemoveAt(0);
            input.Add(elementToRoll);
        }
    }

    private static bool ProceedToSort(string[] command, List<string> input)
    {
        var start = int.Parse(command[2]);
        var count = int.Parse(command[4]);
        bool paramsAreValid = start >= 0 && start < input.Count && count >= 0 && start + count <= input.Count;
        if (paramsAreValid)
        {
            var partToSort = input.Skip(start).Take(count).ToList();
            partToSort.Sort();
            input.RemoveRange(start, count);
            input.InsertRange(start, partToSort);
        }
        return paramsAreValid;
    }

    private static bool ProceedToReverse(string[] command, List<string> input)
    {
        var start = int.Parse(command[2]);
        var count = int.Parse(command[4]);
        bool paramsAreValid = start >= 0 && start < input.Count && count >= 0 && start + count <= input.Count;
        if (paramsAreValid)
        {
            var partToReverse = input.Skip(start).Take(count).ToList();
            partToReverse.Reverse();
            input.RemoveRange(start, count);
            input.InsertRange(start, partToReverse);
        }
        return paramsAreValid;
    }
}