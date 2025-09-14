namespace Chainalysis
{
    internal class Program
    {
        static Dictionary<string, List<string>> graph;

        static void Main(string[] args)
        {
            int transactions = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();

            for (int i = 0; i < transactions; i++)
            {
                string[] transactionElements = Console.ReadLine()
                                              .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string from = transactionElements[0];
                string to = transactionElements[1];
                string amount = transactionElements[2];

                if (!graph.ContainsKey(from))
                {
                    graph[from] = new List<string>();
                }

                if (!graph.ContainsKey(to))
                {
                    graph[to] = new List<string>();
                }

                graph[from].Add(to);
                graph[to].Add(from);
            }

            HashSet<string> visited = new HashSet<string>();
            int groups = 0;

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    groups++;
                    DFS(node, visited);
                }
            }

            Console.WriteLine(groups);

        }
        private static void DFS(string node, HashSet<string> visited)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child, visited);
            }
        }
    }
}
