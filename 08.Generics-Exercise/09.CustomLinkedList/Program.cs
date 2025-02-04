namespace _09.CustomLinkedList;

class StartUp
{
    static void Main(string[] args)
    {
      CustomDoublyLinkedList<string> list = new CustomDoublyLinkedList<string>();
      
      list.AddFirst("A");
      list.AddLast("B");
      list.AddLast("C");

      foreach (var num in list)
      {
          Console.WriteLine(num);
      }
    }
}