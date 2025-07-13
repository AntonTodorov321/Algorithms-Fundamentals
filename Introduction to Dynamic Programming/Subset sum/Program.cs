namespace Subset_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 3, 5, 1, 4, 2 };
            int target = 20;

            Dictionary<int, int> possibleSums = GetAllPossibleSums(nums);

            if (possibleSums.ContainsKey(target))
            {
                List<int> subset = FindSubset(possibleSums, target);
                Console.WriteLine(string.Join(" ", subset));
            }
            else
            {
                Console.WriteLine("Can not make the given target with these numbers");
            }

        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            List<int> subset = new List<int>();

            while (target > 0)
            {
                int currentNum = sums[target];

                subset.Add(currentNum);
                target -= currentNum;
            }

            return subset;
        }

        private static Dictionary<int, int> GetAllPossibleSums(int[] nums)
        {
            Dictionary<int, int> sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in nums)
            {
                int[] currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    int newSum = sum + num;

                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(sum + num, num);
                    }
                }
            }

            return sums;
        }
    }
}
