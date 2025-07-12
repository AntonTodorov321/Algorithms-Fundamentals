namespace Fibonacci
{
    using System;

    internal class Program
    {
        private static Dictionary<int, long> memo = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long fibonacci = Fibonacci(n);

            Console.WriteLine(fibonacci);
        }

        private static long Fibonacci(int n)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            if (n < 2)
            {
                return n;
            }

            long result = Fibonacci(n - 1) + Fibonacci(n - 2);
            memo[n] = result;

            return result;
        }
    }
}
