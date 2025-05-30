

int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

BubbleSort();

Console.WriteLine(string.Join(" ", numbers));

void BubbleSort()
{
    int sortedCount = 0;
    bool isSorted = false;

    while (!isSorted)
    {
        isSorted = true;

        for (int j = 1; j < numbers.Length - sortedCount; j++)
        {
            int i = j - 1;

            if (numbers[i] > numbers[j])
            {
                isSorted = false;
                Swap(i, j);
            }

        }

        sortedCount++;
    }
}

void Swap(int first, int second)
{
    int temp = numbers[first];
    numbers[first] = numbers[second];
    numbers[second] = temp;
}