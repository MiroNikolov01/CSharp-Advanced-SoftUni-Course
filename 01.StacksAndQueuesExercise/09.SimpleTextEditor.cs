using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace _09.SimpleTextEditor
{
    public class Program
    {
        public static void Main()
        {
            string text = string.Empty;
            Stack<char> stack = new Stack<char>();

            Stack<(string operation, string content)> undoStack = new Stack<(string, string)>();
                    
            int operations = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < operations; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (arguments[0])
                {
                    case "1":
                        AppendString(undoStack, stack, arguments[1]);
                        break;
                    case "2":
                        EraseString(undoStack, stack, int.Parse(arguments[1]));
                        break;
                    case "3":
                        ReturnIndexPosition(stack, int.Parse(arguments[1]));
                        break;
                    case "4":
                        UndoOperations(stack, undoStack);
                        break;
                }
            }
        }

        public static void UndoOperations(Stack<char> stack, Stack<(string operation, string content)> undoStack)
        {
            if (undoStack.Count == 0) return;
            var lastOperation = undoStack.Pop();

            if (lastOperation.operation == "append")
            {
                string toRemove = lastOperation.content;
                for (int i = 0; i < toRemove.Length; i++)
                {
                    stack.Pop();
                }
            }
            else if (lastOperation.operation == "erase")
            {
                string toRestore = lastOperation.content;
                for (int i = toRestore.Length - 1; i >= 0; i--)
                {
                    stack.Push(toRestore[i]);
                }
            }
        }

        public static void ReturnIndexPosition(Stack<char> stack, int count)
        {
            Stack<char> tempStack = new Stack<char>();
            StringBuilder textBuilder = new StringBuilder();

            while (stack.Count > 0)
            {
                char ch = stack.Pop();
                textBuilder.Append(ch);
                tempStack.Push(ch);
            }
            string text = textBuilder.ToString();
            text = new string(text.ToCharArray().Reverse().ToArray());

            if (text.Length >= count)
            {
                Console.WriteLine(text[count - 1]);
            }

            int lenght = tempStack.Count;
            for (int i = 0; i < lenght; i++)
            {
                char temp = tempStack.Pop();
                stack.Push(temp);
            }
        }

        public static void EraseString(Stack<(string operation, string content)> undoStack, Stack<char> stack, int count)
        {
            if (stack.Count == 0 || stack.Count < count) return;

            string erased = string.Empty;

            for (int i = 0; i < count; i++)
            {
                erased += stack.Pop();
            }

            undoStack.Push(("erase", erased));
        }

        public static void AppendString(Stack<(string operation, string content)> undoStack, Stack<char> stack, string argument)
        {
            char[] charText = argument.ToCharArray();
            for (int j = 0; j < charText.Length; j++)
            {
                stack.Push(charText[j]);
            }

            undoStack.Push(("append", argument));
        }
    }
}
