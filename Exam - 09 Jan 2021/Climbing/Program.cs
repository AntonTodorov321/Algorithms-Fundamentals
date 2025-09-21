namespace Climbing
{
    using System;

    internal class Program
    {
        private static int[,] matrix;
        private static int[,] allSums;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];
            allSums = new int[rows, cols];

            FillMatrix(rows, cols);
            FillAllSums(rows, cols);

            Console.WriteLine(allSums[0, 0]);

            Console.WriteLine(string.Join(" ", FindPath()));
        }

        private static List<int> FindPath()
        {
            List<int> path = new List<int>();

            int row = matrix.GetLength(0) - 1;
            int col = matrix.GetLength(1) - 1;

            path.Add(matrix[row, col]);

            while (row > 0 && col > 0)
            {
                if (allSums[row - 1, col] > allSums[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }

                path.Add(matrix[row, col]);
            }

            while (row > 0)
            {
                row--;
                path.Add(matrix[row, col]);
            }

            while (col > 0)
            {
                col--;
                path.Add(matrix[row, col]);
            }

            return path;
        }

        private static void FillAllSums(int rows, int cols)
        {
            allSums[rows - 1, cols - 1] = matrix[rows - 1, cols - 1];

            for (int row = rows - 2; row >= 0; row--)
            {
                allSums[row, cols - 1] = matrix[row, cols - 1] + allSums[row + 1, cols - 1];
            }

            for (int col = cols - 2; col >= 0; col--)
            {
                allSums[rows - 1, col] = matrix[rows - 1, col] + allSums[rows - 1, col + 1];
            }

            for (int row = matrix.GetLength(0) - 2; row >= 0; row--)
            {
                for (int col = matrix.GetLength(1) - 2; col >= 0; col--)
                {
                    allSums[row, col] =
                        Math.Max(allSums[row + 1, col], allSums[row, col + 1]) + matrix[row, col];
                }
            }
        }

        private static void FillMatrix(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }
    }
}
