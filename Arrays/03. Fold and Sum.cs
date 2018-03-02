using System;
using System.Linq;

public class FoldAndSum
{
    public static void Main()
    {
        double[] inputAray = Console.ReadLine().Split().Where(a => a.Length > 0).Select(double.Parse).ToArray();
        double[] arrayFromSides = GetArrayFromSides(inputAray);
        double[] insideArray = GetInsideArray(inputAray);
        double[] resultArray = ConstructResultArray(arrayFromSides, insideArray);
        Console.WriteLine(string.Join(" ", resultArray));
    }

    private static double[] ConstructResultArray(double[] arrayFromSides, double[] insideArray)
    {
        int length = insideArray.Length;
        double[] resultArray = new double[length];
        for (int index = 0; index < length; index++)
        {
            resultArray[index] = arrayFromSides[index] + insideArray[index];
        }
        return resultArray;
    }

    private static double[] GetInsideArray(double[] inputAray)
    {
        int length = inputAray.Length;
        double skip = (1.0 / 4.0) * length;
        double take = (2.0 / 4.0) * length;
        double[] resultArray = inputAray.Skip((int)skip).Take((int)take).ToArray();
        return resultArray;
    }

    private static double[] GetArrayFromSides(double[] inputAray)
    {
        int length = inputAray.Length;
        double skip = (3.0 / 4.0) * length;
        double[] firstHalf = inputAray.Take(length / 4).Reverse().ToArray();
        double[] secondHalf = inputAray.Skip((int)skip).Reverse().ToArray();
        double[] resultArray = firstHalf.Concat(secondHalf).ToArray();
        return resultArray;
    }
}