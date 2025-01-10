namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int passedCars = 0;
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    int currentGreenLight = greenLightDuration;

                    while (cars.Count > 0 && currentGreenLight > 0)
                    {
                        string currentCar = cars.Dequeue();
                        if (currentGreenLight - currentCar.Length >= 0)
                        {
                            currentGreenLight -= currentCar.Length;
                            passedCars++;
                            continue;
                        }
                        else if (currentGreenLight + freeWindowDuration - currentCar.Length >= 0)
                        {
                            passedCars++;
                            continue;
                        }
                        else
                        {
                            char hitCarChar = currentCar[currentGreenLight + freeWindowDuration];
                            Console.WriteLine($"A crash happened!\n{currentCar} was hit at {hitCarChar}.");
                            return;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }

    }
}
