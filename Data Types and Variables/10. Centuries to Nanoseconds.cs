using System;
using System.Numerics;

class Junk
{
    static void Main()
    {
        var centuries = byte.Parse(Console.ReadLine());
        var years = 100 * centuries;
        var days = (int)(365.2422 * years);
        var hours = (long)(24 * days);
        var minutes = (BigInteger)(60 * hours);
        var seconds = minutes * 60;
        var milliseconds = seconds * 1000;
        var microseconds = milliseconds * 1000;
        var nanoseconds = microseconds * 1000;
        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
}