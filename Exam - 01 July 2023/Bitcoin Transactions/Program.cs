namespace Bitcoin_Transactions
{
    using System;

    internal class Program
    {
        private static int[,] matrix;
        private static Stack<string> result;

        static void Main(string[] args)
        {
            string[] firstTransactions = Console.ReadLine().Split().ToArray();
            string[] secondTransactions = Console.ReadLine().Split().ToArray();

            matrix = new int[firstTransactions.Length + 1, secondTransactions.Length + 1];

            LCS(firstTransactions, secondTransactions);

            result = new Stack<string>();
            ReconstructPath(firstTransactions, secondTransactions);

            Console.WriteLine($"[{string.Join(" ", result)}]");
        }

        private static void ReconstructPath(string[] firstTransactions, string[] secondTransactions)
        {
            int row = firstTransactions.Length;
            int col = secondTransactions.Length;

            while (row > 0 && col > 0)
            {
                if (firstTransactions[row - 1] == secondTransactions[col - 1])
                {
                    result.Push(firstTransactions[row - 1]);
                    row--;
                    col--;
                }
                else if (matrix[row - 1, col] > matrix[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }
        }

        private static void LCS(string[] firstTransactions, string[] secondTransactions)
        {
            for (int row = 1; row <= firstTransactions.Length; row++)
            {
                for (int col = 1; col <= secondTransactions.Length; col++)
                {
                    if (firstTransactions[row - 1] == secondTransactions[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }
        }
    }
}
