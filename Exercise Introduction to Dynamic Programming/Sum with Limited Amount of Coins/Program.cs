namespace Sum_with_Limited_Amount_of_Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(CountSum(numbers, target));
        }

        private static int CountSum(int[] numbers, int target)
        {
            int count = 0;
            HashSet<int> sums = new HashSet<int>() { 0 };

            foreach (var number in numbers)
            {
                HashSet<int> currentSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    int currentSum = sum + number;

                    if (currentSum == target)
                    {
                        count++;
                    }

                    currentSums.Add(currentSum);
                }

                sums = sums.Union(currentSums).ToHashSet();
            }

            return count;
        }
    }
}
