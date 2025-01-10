namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (command[0])
                {
                    case "1":
                        stack.Push(int.Parse(command[1]));
                        break;
                    case "2":
                        if (IsNotEmpty(stack))
                        {
                            stack.Pop();
                        }
                            break;
                    case "3":
                        if (IsNotEmpty(stack))
                        {
                            Console.WriteLine(stack.Max());
                        }
                            break;
                    case "4":
                        if (IsNotEmpty(stack))
                        {
                            Console.WriteLine(stack.Min());
                        }
                            break;
                }
            }
            if (IsNotEmpty(stack))
            {
                Console.WriteLine(string.Join(", ",stack));
            }
        }
        static bool IsNotEmpty(Stack<int> stack)
        {
            return stack.Count > 0;
        }
    }
}
