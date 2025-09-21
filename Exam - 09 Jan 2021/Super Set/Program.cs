namespace Super_Set
{
    using System;

    internal class Program
    {
        private static int[] numbers;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine()
                            .Split(", ")
                            .Select(int.Parse)
                            .ToArray();

            for (int i = 0; i <= numbers.Length; i++)
            {
                GenerateSuperSet(0, 0, new int[i]);
            }
        }

        private static void GenerateSuperSet(int index, int start, int[] result)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = start; i < numbers.Length; i++)
            {
                result[index] = numbers[i];

                GenerateSuperSet(index + 1, i + 1, result);
            }
        }
    }
}
