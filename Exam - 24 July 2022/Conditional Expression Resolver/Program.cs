namespace Conditional_Expression_Resolver
{
    using System;
    using System.Dynamic;

    internal class Program
    {
        static void Main(string[] args)
        {
            char[] expression = Console.ReadLine()
                .Split()
                .Select(x => x[0])
                .ToArray();

            Console.WriteLine(ParseExpression(expression, 0));
        }

        private static int ParseExpression(char[] expression, int index)
        {
            char currentChar = expression[index];

            if (char.IsDigit(currentChar))
            {
                return currentChar - '0';
            }

            if (currentChar == 't')
            {
                return ParseExpression(expression, index + 2);
            }

            int foundCondition = 0;

            for (int i = index + 2; i < expression.Length; i++)
            {
                char current = expression[i];

                if (current == '?')
                {
                    foundCondition += 1;
                }
                else if (current == ':')
                {
                    foundCondition -= 1;

                    if (foundCondition < 0)
                    {
                        return ParseExpression(expression, i + 1);
                    }
                }
            }

            return -1;
        }
    }
}
