namespace Subset_sum_with_repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = [2, 7];
            int target = 325;

            bool[] sums = new bool[target + 1];
            sums[0] = true;

            for (int sum = 0; sum < sums.Length; sum++)
            {
                if (!sums[sum])
                {
                    continue;
                }

                foreach (var num in nums)
                {
                    int newSum = num + sum;

                    if (newSum > target)
                    {
                        continue;
                    }

                    sums[newSum] = true;
                }
            }

            List<int> subset = new List<int>();

            while (target > 0)
            {
                foreach (var num in nums)
                {
                    int prevSum = target - num;

                    if (prevSum >= 0 && sums[prevSum])
                    {
                        subset.Add(num);
                        target = prevSum;

                        if (target == 0)
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", subset));
        }
    }
}
