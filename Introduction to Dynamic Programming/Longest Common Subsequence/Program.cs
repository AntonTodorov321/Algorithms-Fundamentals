namespace Longest_Common_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            int[,] matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int r = 1; r < matrix.GetLength(0); r++)
            {
                for (int c = 1; c < matrix.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        matrix[r, c] = matrix[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        matrix[r, c] = Math.Max(matrix[r - 1, c], matrix[r, c - 1]);
                    }
                }
            }

            int row = str1.Length;
            int col = str2.Length;

            Stack<char> commonElements = new Stack<char>();

            while (row > 0 && col > 0)
            {
                if (str1[row - 1] == str2[col - 1])
                {
                    commonElements.Push(str1[row - 1]);

                    row -= 1;
                    col -= 1;
                }
                else if (matrix[row - 1, col] > matrix[row, col - 1])
                {
                    row -= 1;
                }
                else
                {
                    col -= 1;
                }
            }

            Console.WriteLine(string.Join("", commonElements));
        }
    }
}
