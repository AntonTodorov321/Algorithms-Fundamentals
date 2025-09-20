namespace Socks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstStock = Console.ReadLine()
                                .Split(" ")
                                .Select(int.Parse)
                                .ToArray();

            int[] secondStock = Console.ReadLine()
                                .Split(" ")
                                .Select(int.Parse)
                                .ToArray();

            int[,] matrix = new int[firstStock.Length + 1, secondStock.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (firstStock[row - 1] == secondStock[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }

            Console.WriteLine(matrix[firstStock.Length, secondStock.Length]);
        }
    }
}
