namespace Strings_Mashup
{
    using System;
    using System.Security;

    internal class Program
    {
        private static string text;
        private static char[] result;

        static void Main(string[] args)
        {
            text = Console.ReadLine();
            result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                result[i] = text[i];
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index == result.Length)
            {
                Console.WriteLine(string.Join("", result));
                return;
            }

            char currentChar = result[index];

            if (char.IsLetter(currentChar))
            {
                result[index] = char.ToLower(currentChar);
                Permute(index + 1);

                result[index] = char.ToUpper(currentChar);
                Permute(index + 1);
            }
            else
            {
                result[index] = currentChar;
                Permute(index + 1);
            }
        }
    }
}
