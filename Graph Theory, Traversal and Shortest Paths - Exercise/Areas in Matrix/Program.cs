
int rows = int.Parse(Console.ReadLine());
int cols = int.Parse(Console.ReadLine());

char[,] graph = new char[rows, cols];
bool[,] visited = new bool[rows, cols];
SortedDictionary<char, int> areas = new SortedDictionary<char, int>();

int areasCount = 0;

for (int row = 0; row < rows; row++)
{
    string rowData = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        graph[row, col] = rowData[col];
    }
}

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        if (visited[row, col])
        {
            continue;
        }

        char currentElement = graph[row, col];

        DFS(row, col, currentElement);
        areasCount++;

        if (!areas.ContainsKey(currentElement))
        {
            areas[currentElement] = 0;
        }

        areas[currentElement]++;
    }
}

Console.WriteLine($"Areas: {areasCount}");

foreach (var kvp in areas)
{
    Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
}

void DFS(int row, int col, int element)
{
    if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1))
    {
        return;
    }

    if (visited[row, col])
    {
        return;
    }

    if (graph[row, col] != element)
    {
        return;
    }

    visited[row, col] = true;

    DFS(row - 1, col, element);
    DFS(row + 1, col, element);
    DFS(row, col + 1, element);
    DFS(row, col - 1, element);
}