using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expresion = Console.ReadLine();

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < expresion.Length; i++)
            {
                if (expresion[i] == '(')
                {
                    stack.Push(i);
                }
                if (expresion[i] == ')')
                {
                    for (int j = stack.Pop(); j <= i; j++)
                    {
                        Console.Write($"{expresion[j]}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
