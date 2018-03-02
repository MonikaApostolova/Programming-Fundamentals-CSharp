using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_3_3.Anonymous_VoxAnonymous_Vox
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"([a-zA-Z]+)(\S+)\1";
            var input = Console.ReadLine();
            var command = Console.ReadLine().Split('{', '}', ' ').Where(a => a.Length > 0).ToArray();
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            var counter = 0;
            foreach (Match match in matches)
            {
                while (counter < command.Length)
                {
                    var currentCommand = command[counter];
                    var start = match.Groups[1].Value;
                    var end = match.Groups[1].Value;
                    var placeholder = match.Groups[2].Value;
                    var fullBefore = start + placeholder + end;
                    var fullAfter = start + currentCommand + end;
                    input = input.Replace(fullBefore, fullAfter);
                    counter++;
                    break;
                }

            }
            Console.WriteLine(string.Join("", input));
        }
    }
}