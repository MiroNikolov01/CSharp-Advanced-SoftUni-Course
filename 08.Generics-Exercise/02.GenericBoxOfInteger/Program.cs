﻿namespace _02.GenericBoxOfInteger;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>(num);
            
            Console.WriteLine(box.ToString());
          
        }
    }
}