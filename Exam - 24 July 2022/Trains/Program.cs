namespace Trains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arrival = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .OrderBy(x => x)
                .ToArray();

            var departure = Console.ReadLine()
              .Split()
              .Select(double.Parse)
              .OrderBy(x => x)
              .ToArray();

            int arrivalIndex = 0;
            int departureIndex = 0;

            int allPlatforms = 0;
            int currentPlatforms = 0;

            while (arrivalIndex < arrival.Length)
            {
                if (arrival[arrivalIndex] < departure[departureIndex])
                {
                    currentPlatforms++;
                    arrivalIndex++;

                    if(currentPlatforms > allPlatforms)
                    {
                        allPlatforms = currentPlatforms;
                    }
                }
                else
                {
                    currentPlatforms--;
                    departureIndex++;
                }
            }

            Console.WriteLine(allPlatforms);
        }
    }
}
