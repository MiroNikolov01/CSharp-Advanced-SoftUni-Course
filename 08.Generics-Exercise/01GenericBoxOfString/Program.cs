﻿namespace _01.GenericBoxOfString;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            Box<string> box = new Box<string>(s);
            Console.WriteLine(box.ToString());
          
        }
    }
}