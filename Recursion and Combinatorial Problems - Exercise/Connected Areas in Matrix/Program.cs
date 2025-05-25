
public class Program
{
    private const char VisitedSymbol = 'V';

    private static char[,] matrix;
    private static int areaSize;

    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        matrix = new char[rows, cols];
        List<Area> areas = new List<Area>();

        for (int row = 0; row < rows; row++)
        {
            var matrixRow = Console.ReadLine();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = matrixRow[col];
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                areaSize = 0;

                GetArea(row, col);

                if (areaSize != 0)
                {
                    areas.Add(new Area(areaSize, row, col));
                }
            }
        }

        Area[] sortedAreas = areas.OrderByDescending(a => a.Size)
                                .ThenBy(a => a.Row)
                                .ThenBy(a => a.Col)
                                .ToArray();

        Console.WriteLine($"Total areas found: {areas.Count()}");

        for (int i = 0; i < sortedAreas.Count(); i++)
        {
            Area area = sortedAreas[i];

            Console.WriteLine($"Area #{i + 1} at ({area.Row}, {area.Col}), size: {area.Size}");
        }
    }

    static void GetArea(int row, int col)
    {
        if (!IsCellValid(row, col) || IsWall(row, col) || IsVisited(row, col))
        {
            return;
        }

        matrix[row, col] = VisitedSymbol;
        areaSize++;

        GetArea(row - 1, col);
        GetArea(row + 1, col);
        GetArea(row, col - 1);
        GetArea(row, col + 1);
    }

    private static bool IsVisited(int row, int col)
    {
        return matrix[row, col] == VisitedSymbol;
    }

    private static bool IsWall(int row, int col)
    {
        return matrix[row, col] == '*';
    }

    private static bool IsCellValid(int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) &&
               col >= 0 && col < matrix.GetLength(1);
    }
}

public class Area
{
    public Area(int size, int row, int col)
    {
        this.Size = size;
        this.Row = row;
        this.Col = col;
    }

    public int Size { get; set; }
    public int Row { get; set; }
    public int Col { get; set; }
}