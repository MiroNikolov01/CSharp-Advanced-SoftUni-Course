namespace _03.GenericSwapMethodString;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Box<string>> boxCollection = new List<Box<string>>();
        for (int i = 0; i < n; i++)
        {
            string value = Console.ReadLine();
            Box<string> box = new Box<string>(value);
            boxCollection.Add(box);
        }

        int[] positions = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        Swap(positions[0], positions[1], boxCollection);

        foreach (var box in boxCollection)
        {
            Console.WriteLine(box.ToString());
        }
    }

    public static void Swap<T>(int index1, int index2, List<T> boxes)
    {
        (boxes[index1], boxes[index2]) = (boxes[index2], boxes[index1]);
    }
}