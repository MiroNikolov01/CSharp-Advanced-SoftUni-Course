﻿using System.Reflection.Metadata;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] operations = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            // N for Push
            int n = operations[0];
            // S for Pop
            int s = operations[1];
            // X for if number is in stack print True if not Print Smallest Element , else 0 if empty  
            int x = operations[2];

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int j = 0; j < s; j++)
            {
                stack.Pop();
            }
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count <= 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }


        }
    }
}