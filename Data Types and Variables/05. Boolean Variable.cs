using System;

class Junk
{
    static void Main()
    {
        var str = Console.ReadLine();
        var result = Convert.ToBoolean(str);
        if (result == true)
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
    }
}