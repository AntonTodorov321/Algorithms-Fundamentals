namespace Move_Down_Right
{
    using System;
    using System.Numerics;

    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            Console.WriteLine(UniquePaths(rows, cols));
        }

        private static BigInteger UniquePaths(int rows, int cols)
        {
            int totalMoves = rows + cols - 2;
            int smallerSide = Math.Min(rows - 1, cols - 1);

            BigInteger result = 1;

            for (int i = 1; i <= smallerSide; i++)
            {
                result *= totalMoves - (smallerSide - i);
                result /= i;
            }

            return result;
        }
    }
}
