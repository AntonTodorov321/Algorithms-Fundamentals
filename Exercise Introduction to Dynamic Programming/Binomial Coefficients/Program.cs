namespace Binomial_Coefficients
{
    using System;
    using System.Numerics;

    internal class Program
    {
        private static Dictionary<string, long> memo; 
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            memo = new Dictionary<string, long>();

            Console.WriteLine(GetBinom(row, col));
        }

        private static long GetBinom(int row, int col)
        {
            if (col == 0 || row == col)
            {
                return 1;
            }

            string key = $"{row}-{col}";

            if(memo.ContainsKey(key))
            {
                return memo[key];
            }

            long sum = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            memo[key] = sum;

            return sum;
        }
    }
}
