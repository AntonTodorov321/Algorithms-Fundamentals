int rows = int.Parse(Console.ReadLine());
int cols = int.Parse(Console.ReadLine());

char[,] matrix = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    string matrixData = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = matrixData[col];
    }
}

FindAllPathsRecursively(matrix, 0, 0, string.Empty, new List<string>());

void FindAllPathsRecursively
    (char[,] matrix, int row, int col, string direction, List<string> directions)
{
    if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
    {
        return;
    }

    if (matrix[row, col] == 'e')
    {
        directions.Add(direction);
        Console.WriteLine(string.Join("", directions));
        directions.RemoveAt(directions.Count - 1);
        return;
    }

    if (matrix[row, col] == '*' || matrix[row, col] == 'V')
    {
        return;
    }

    directions.Add(direction);
    matrix[row, col] = 'V';

    FindAllPathsRecursively(matrix, row - 1, col, "U", directions); //Up
    FindAllPathsRecursively(matrix, row + 1, col, "D", directions); //Down
    FindAllPathsRecursively(matrix, row, col + 1, "R", directions); //Right
    FindAllPathsRecursively(matrix, row, col - 1, "L", directions); //Left

    matrix[row, col] = '-';
    directions.RemoveAt(directions.Count - 1);
}