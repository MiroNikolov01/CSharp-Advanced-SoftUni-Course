namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songQueue = new Queue<string>(songs);
            
            while (songQueue.Count > 0)
            {
                string command = Console.ReadLine();
                if (command.Contains("Add"))
                {
                   var tokens = command.Split("Add ");
                    AddSong(songQueue, tokens[1]);
                }
                else if (command.Contains("Play"))
                {
                    PlaySong(songQueue);
                }
                else if(command.Contains("Show"))
                {
                    ShowSong(songQueue);
                }

            }
            Console.WriteLine("No more songs!");
        }
        static void PlaySong(Queue<string> queue)
        {
            queue.Dequeue();
        }
        static void AddSong(Queue<string> queue, string song)
        {
            if (queue.Contains(song))
            {
                Console.WriteLine($"{song} is already contained!");
                return;
            }
            queue.Enqueue(song);
        }
        static void ShowSong(Queue<string> queue)
        {
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
