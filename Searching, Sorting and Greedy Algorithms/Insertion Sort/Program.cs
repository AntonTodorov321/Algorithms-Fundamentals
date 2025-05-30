
int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

InsertionSort();

Console.WriteLine(string.Join(" ", numbers));

void InsertionSort()
{
    for (int i = 1; i < numbers.Length; i++)
    {
        int j = i;

        while (j > 0 && numbers[j] < numbers[j - 1])
        {
            Swap(j, j - 1);
            j--;
        }
    }
}

void Swap(int first, int second)
{
    int temp = numbers[first];
    numbers[first] = numbers[second];
    numbers[second] = temp;
}