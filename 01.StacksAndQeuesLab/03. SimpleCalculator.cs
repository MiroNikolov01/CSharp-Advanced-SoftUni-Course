namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .Reverse()
                .ToArray();
            Stack<string> stack = new Stack<string>(input);
            int result = int.Parse(stack.Pop());
            while (stack.Count > 0)
            {
                char operation = char.Parse(stack.Pop());
                int number = int.Parse(stack.Pop());
                switch (operation)
                {
                    case '+':
                        result += number;
                        break;
                    case '-':
                        result -= number;
                        break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
