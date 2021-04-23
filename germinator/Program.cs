using System;
using germinator_lib;

namespace germinator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());

            var unusedstartingCoordinates = Console.ReadLine();

            var germinator = new Germinator();

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandLine = Console.ReadLine();
                var direction = commandLine[0];
                var numberOfSteps = int.Parse(commandLine.Split(" ")[1]);

                germinator.Move(direction, numberOfSteps);
            }

            Console.WriteLine($"=> Cleaned: {germinator.NumberOfTilesCleaned}");
        }
    }
}
