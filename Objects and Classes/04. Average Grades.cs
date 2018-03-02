using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.AverageGrades
{
    class Student
    {
        public string Name { get; set; }
        public List<decimal> Grades { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var ListOfStudents = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                Student current = new Student
                {
                    Name = input[0],
                    Grades = input.Skip(1).Select(decimal.Parse).ToList()
                };
                ListOfStudents.Add(current);
            }
            foreach (Student student in ListOfStudents.OrderBy(a => a.Name).ThenByDescending(a => a.Grades.Average()))
            {
                var Average = student.Grades.Average();
                if (Average >= 5)
                    Console.WriteLine("{0} -> {1:f2}", student.Name, Average);
            }
        }
    }
}