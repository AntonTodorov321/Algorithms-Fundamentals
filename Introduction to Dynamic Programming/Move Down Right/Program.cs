namespace Move_Down_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int[,] dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int col = 1; col < cols; col++)
            {
                dp[0, col] = dp[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                dp[row, 0] = dp[row - 1, 0] + matrix[row, 0];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    int upper = dp[row - 1, col];
                    int left = dp[row, col - 1];

                    dp[row, col] = Math.Max(upper, left) + matrix[row, col];
                }
            }

            int r = rows - 1;
            int c = cols - 1;
            Stack<string> path = new Stack<string>();

            while (r > 0 && c > 0)
            {
                path.Push($"[{r}, {c}]");

                int upper = dp[r - 1, c];
                int left = dp[r, c - 1];

                if (upper > left)
                {
                    r -= 1;
                }
                else
                {
                    c -= 1;
                }
            }

            while (r > 0)
            {
                path.Push($"[{r}, {c}]");
                r -= 1;
            }

            while (c > 0)
            {
                path.Push($"[{r}, {c}]");
                c -= 1;
            }

            path.Push($"[{r}, {c}]");

            Console.WriteLine(string.Join(" ", path));
        }
    }
}
