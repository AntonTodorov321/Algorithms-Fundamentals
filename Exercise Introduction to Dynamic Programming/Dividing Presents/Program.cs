namespace Dividing_Presents
{
    using System;

    internal class Program
    {
        private static Dictionary<int, int> sums;
        private static List<int> smallerSums;
        private static int[] nums;

        static void Main(string[] args)
        {
            nums = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            smallerSums = new List<int>();
            sums = new Dictionary<int, int>() { { 0, 0 } };

            GetAllSums();

            int totalSum = nums.Sum();
            int middleSum = totalSum / 2;
            int smallerSum = 0;

            for (int sum = middleSum; sum >= 0; sum--)
            {
                if (sums.ContainsKey(sum))
                {
                    smallerSum = sum;
                    break;
                }
            }

            int biggerSum = totalSum - smallerSum;
            int difference = biggerSum - smallerSum;

            GetSmallerSums(smallerSum);

            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Alan:{smallerSum} Bob:{biggerSum}");
            Console.WriteLine($"Alan takes: {string.Join(" ", smallerSums)}");
            Console.WriteLine($"Bob takes the rest.");
        }

        private static void GetSmallerSums(int target)
        {
            while (target != 0)
            {
                int lastAdded = sums[target];

                smallerSums.Add(lastAdded);
                target -= lastAdded;
            }
        }

        private static void GetAllSums()
        {
            foreach (var num in nums)
            {
                List<int> currentSums = sums.Keys.ToList();

                foreach (var sum in currentSums)
                {
                    int key = sum + num;

                    if (!sums.ContainsKey(key))
                    {
                        sums[key] = num;
                    }
                }
            }
        }
    }
}
