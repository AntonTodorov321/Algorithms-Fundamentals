namespace Bank_Robbery
{
    using System;

    internal class Program
    {
        private static int[] deposits;

        static void Main(string[] args)
        {
            deposits = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToArray();

            int totalSum = deposits.Sum();
            int depositAmount = totalSum / 2;

            List<int> firstSums = GetSums(depositAmount);
            firstSums.Sort();

            List<int> secondSums = new List<int>();

            foreach (var deposit in deposits)
            {
                if (!firstSums.Contains(deposit))
                {
                    secondSums.Add(deposit);
                }
            }

            secondSums.Sort();

            Console.WriteLine(string.Join(" ", firstSums));
            Console.WriteLine(string.Join(" ", secondSums));
        }

        private static List<int> GetSums(int destination)
        {
            Dictionary<int, int> sums = new Dictionary<int, int>() { { 0, 0 } };

            foreach (var deposit in deposits)
            {
                List<int> newSums = sums.Keys.ToList();

                foreach (var sum in newSums)
                {
                    int newSum = deposit + sum;

                    if (!sums.ContainsKey(newSum))
                    {
                        sums[newSum] = deposit;
                    }

                    if(newSum == destination)
                    {
                        return GetSumPath(sums, destination);
                    }
                }
            }

            return new List<int>();
        }

        private static List<int> GetSumPath(Dictionary<int, int> sums, int destination)
        {
            List<int> result = new List<int>();

            while (destination != 0)
            {
                int currentSum = sums[destination];

                result.Add(currentSum);
                destination -= currentSum;
            }

            return result;
        }
    }
}
