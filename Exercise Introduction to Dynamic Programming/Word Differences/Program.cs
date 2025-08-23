namespace Word_Differences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine()!;
            string secondString = Console.ReadLine()!;

            int[,] matrix = new int[firstString.Length + 1, secondString.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = row;
            }

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0,col] = col;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (firstString[col - 1] == secondString[row - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }
                    else
                    {
                        matrix[row, col] = Math.Min(matrix[row - 1, col], matrix[row, col - 1]) + 1;
                    }
                }
            }

            Console.WriteLine($"Deletions and Insertions: {matrix[firstString.Length, secondString.Length]}");
        }
    }
}
