using System;
using System.Collections.Generic;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> students = new Dictionary<int, string>();

            string studentName;

            while ((studentName = Console.ReadLine()) != "end")
            {
                students.Add(students.Count + 1, studentName);
            }

            Print(students);
        }

        private static void Print(Dictionary<int, string> students)
        {
            foreach (var kvp in students)
            {
                Console.WriteLine(kvp.Key + ". " + kvp.Value);
            }
        }
    }
}
