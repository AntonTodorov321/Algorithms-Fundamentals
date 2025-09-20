namespace TBC
{
    using System;

    internal class Program
    {
        private static char[,] matrix;
        private static HashSet<string> visited;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];
            visited = new HashSet<string>();

            for (int row = 0; row < rows; row++)
            {
                string matrixRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = matrixRow[col];
                }
            }

            int tunnelCounter = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 't' && !visited.Contains($"{row}, {col}"))
                    {
                        ExploreTunnel(row, col);
                        tunnelCounter++;
                    }
                }
            }

            Console.WriteLine(tunnelCounter);
        }

        private static void ExploreTunnel(int row, int col)
        {
            if(row == matrix.GetLength(0) || col == matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 'd')
            {
                return;
            }

            visited.Add($"{row}, {col}");

            ExploreTunnel(row + 1, col + 1);
            ExploreTunnel(row + 1, col);
            ExploreTunnel(row, col + 1);
        }
    }
}
