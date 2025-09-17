namespace Universes
{
    using System;
    using System.Security;

    internal class Program
    {
        private static Dictionary<string, List<string>> universe;
        private static HashSet<string> visitedPlanets;

        static void Main(string[] args)
        {
            int planetCount = int.Parse(Console.ReadLine());

            universe = new Dictionary<string, List<string>>();
            visitedPlanets = new HashSet<string>();

            for (int i = 0; i < planetCount; i++)
            {
                string[] planets = Console.ReadLine()
                                    .Split(" - ").ToArray();

                string from = planets[0];
                string to = planets[1];

                if (!universe.ContainsKey(from))
                {
                    universe[from] = new List<string>();
                }

                if (!universe.ContainsKey(to))
                {
                    universe[to] = new List<string>();
                }

                universe[from].Add(to);
                universe[to].Add(from);
            }

            int universeCount = 0;

            foreach (var planet in universe.Keys)
            {
                if (!visitedPlanets.Contains(planet))
                {
                    BFS(planet);
                    universeCount++;
                }
            }

            Console.WriteLine(universeCount);
        }

        private static void BFS(string planet)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(planet);

            visitedPlanets.Add(planet);

            while (queue.Count > 0)
            {
                string currentPlanet = queue.Dequeue();

                foreach (var child in universe[currentPlanet])
                {
                    if (!visitedPlanets.Contains(child))
                    {
                        queue.Enqueue(child);
                        visitedPlanets.Add(child);
                    }
                }
            }
        }
    }
}
