namespace _08.BalancedParentheses;
internal class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Stack<char> stack = new Stack<char>();
        Console.WriteLine(IsBalanced(stack, input) ? "YES":"NO");
    }
    static bool IsBalanced(Stack<char> stack, string input)
    {
        Dictionary<char, char> parts = new Dictionary<char, char>()
        {
            {'{','}' },
            {'[',']' },
            {'(',')' },
        };
        for (int i = 0; i < input.Length; i++)
        {
            if (parts.ContainsKey(input[i]))
            {
                stack.Push(input[i]);
            }
            else if (parts.ContainsValue(input[i]))
            {
                if (stack.Count == 0 || parts[stack.Pop()] != input[i])
                {
                    return false;
                }
            }

        }
        return stack.Count == 0;
    }
}

