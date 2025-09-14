namespace Strings_Mashup
{
    using System;

    internal class Program
    {
        private static char[] letters;
        private static char[] result;

        static void Main(string[] args)
        {
            letters = Console.ReadLine()
                            .Select(x => x)
                            .OrderBy(x => x)
                            .ToArray();

            int n = int.Parse(Console.ReadLine());
            result = new char[n];

            GetCombinations(0, 0);
        }

        private static void GetCombinations(int startIndex, int index)
        {
            if (index == result.Length)
            {
                Console.WriteLine(string.Join("", result));
                return;
            }

            for (int i = startIndex; i < letters.Length; i++)
            {
                result[index] = letters[i];

                GetCombinations(i, index + 1);
            }
        }
    }
}
