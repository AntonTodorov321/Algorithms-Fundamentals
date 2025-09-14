namespace Bitcoin_Miners
{
    using System;

    internal class Program
    {
        private static int counter;
        private static int pool;
        private static int transactionToTake;

        static void Main(string[] args)
        {
            pool = int.Parse(Console.ReadLine());
            transactionToTake = int.Parse(Console.ReadLine());

            GetAllPossibleTransactions(0, 1);

            Console.WriteLine(counter);
        }

        private static void GetAllPossibleTransactions(int index, int startIndex)
        {
            if (index == transactionToTake)
            {
                counter++;
                return;
            }

            for (int i = startIndex; i <= pool; i++)
            {
                GetAllPossibleTransactions(index + 1, i + 1);
            }
        }
    }
}
