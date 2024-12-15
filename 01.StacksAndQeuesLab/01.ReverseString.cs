namespace _01.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine()
                .ToCharArray();
            Stack<char> stack = new Stack<char>(input);
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
