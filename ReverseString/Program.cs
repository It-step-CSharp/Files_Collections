using System;
using System.Collections.Generic;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversed = new Stack<char>(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                reversed.Push(input[i]);
            }
            int length = reversed.Count;
            for (int i = 0; i < length; i++)
            {
                Console.Write(reversed.Pop());
            }
            Console.WriteLine();
        }
    }
}
