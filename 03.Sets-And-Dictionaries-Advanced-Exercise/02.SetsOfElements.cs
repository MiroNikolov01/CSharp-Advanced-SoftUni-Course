namespace _02.SetsOfElements;
internal class Program
{
    /*
 4 3
 1 
 3 
 5 
 7 
 3 
 4 
 5 
     */
    static void Main()
    {
        int[] iterations = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        HashSet<int> nElements = new HashSet<int>();
        HashSet<int> mElements = new HashSet<int>();


        //Optimize it with one cycle by function which return HashSet
        (int n, int m) = (iterations[0], iterations[1]);

        for (int i = 0; i < n; i++)
        {
            nElements.Add(int.Parse(Console.ReadLine()));
        }

        for (int i = 0; i < m; i++)
        {
            mElements.Add(int.Parse(Console.ReadLine()));
        }

        foreach (int element in nElements)
        {
            if(mElements.Contains(element))
                Console.Write(element + " ");
        }

    }
    
}
