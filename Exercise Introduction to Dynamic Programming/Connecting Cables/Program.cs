namespace Connecting_Cables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()!
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();

            int[] positions = Enumerable.Range(1, numbers.Length).ToArray();
            int[,] matrix = new int[numbers.Length + 1, positions.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (numbers[row - 1] == positions[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: " +
                $"{matrix[numbers.Length, positions.Length]}");
        }
    }
}
