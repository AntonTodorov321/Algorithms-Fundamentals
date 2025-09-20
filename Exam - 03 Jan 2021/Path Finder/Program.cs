namespace Path_Finder
{
    using System;
    using System.Numerics;

    internal class Program
    {
        private static List<int>[] graph;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];
            FillGraph();

            int pathsToSearch = int.Parse(Console.ReadLine());
            CheckPaths(pathsToSearch);
        }

        private static void CheckPaths(int pathsToSearch)
        {
            for (int i = 0; i < pathsToSearch; i++)
            {
                int[] path = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();

                int node = path[0];

                bool isFound = true;

                for (int j = 1; j < path.Length; j++)
                {
                    if (!graph[node].Contains(path[j]))
                    {
                        Console.WriteLine("no");
                        isFound = false;
                        break;
                    }

                    node = path[j];
                }

                if (isFound)
                {
                    Console.WriteLine("yes");
                }
            }
        }

        private static void FillGraph()
        {
            for (int i = 0; i < graph.Length; i++)
            {
                string childrenData = Console.ReadLine();
                graph[i] = new List<int>();

                if (string.IsNullOrEmpty(childrenData))
                {
                    continue;
                }

                if (childrenData.Length == 1)
                {
                    graph[i].Add(int.Parse(childrenData));
                    continue;
                }

                List<int> children = childrenData
                                .Split(" ")
                                .Select(int.Parse)
                                .ToList();

                graph[i] = children;
            }
        }
    }
}
