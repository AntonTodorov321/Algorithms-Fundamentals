namespace Sum_with_Unlimited_Amount_of_Coins
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
            ;
        }

        private static int CountSum(int[] numbers, int target)
        {
            int[] sums = new int[target + 1];
            sums[0] = 1;

            foreach (var number in numbers)
            {
                for (int sum = number; sum < sums.Length; sum++)
                {
                    sums[sum] += sums[sum - number];
                }
            }

            return sums[target];
        }
    }
}
