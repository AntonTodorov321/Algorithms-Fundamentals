namespace Minimum_Edit_Distance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int replaceCost = int.Parse(Console.ReadLine()!);
            int insertCost = int.Parse(Console.ReadLine()!);
            int deleteCost = int.Parse(Console.ReadLine()!);

            string firstString = Console.ReadLine()!;
            string secondString = Console.ReadLine()!;

            int[,] matrix = new int[firstString.Length + 1, secondString.Length + 1];

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = matrix[0, col - 1] + insertCost;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = matrix[row - 1, 0] + deleteCost;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (firstString[row - 1] == secondString[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }
                    else
                    {
                        int delete = matrix[row - 1, col] + deleteCost;
                        int insert = matrix[row, col - 1] + insertCost;
                        int replace = matrix[row - 1, col - 1] + replaceCost;

                        matrix[row, col] = Math.Min(Math.Min(delete, insert), replace);
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: " +
                $"{matrix[firstString.Length, secondString.Length]}");
        }
    }
}
