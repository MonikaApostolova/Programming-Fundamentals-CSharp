using System;

class Junk
{
    static void Main()
    {
        var firstName = Console.ReadLine();
        var lastName = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());
        var gender = char.Parse(Console.ReadLine());
        var perID = long.Parse(Console.ReadLine());
        var employeeNum = long.Parse(Console.ReadLine());
        Console.WriteLine($"First name: {firstName}");
        Console.WriteLine($"Last name: {lastName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Gender: {gender}");
        Console.WriteLine($"Personal ID: {perID}");
        Console.WriteLine($"Unique Employee number: {employeeNum}");
    }
}