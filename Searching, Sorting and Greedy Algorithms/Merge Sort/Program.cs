
int[] numbers = Console.ReadLine()
                   .Split(" ")
                   .Select(int.Parse)
                   .ToArray();

int[] sorted = MergeSort(numbers);
Console.WriteLine(string.Join(" ", sorted));

int[] MergeSort(int[] numbers)
{
    if (numbers.Length == 1)
    {
        return numbers;
    }

    int[] left = numbers.Take(numbers.Length / 2).ToArray();
    int[] right = numbers.Skip(numbers.Length / 2).ToArray();

    return Merge(MergeSort(left), MergeSort(right));
}

int[] Merge(int[] left, int[] right)
{
    int[] merged = new int[left.Length + right.Length];

    int leftIndex = 0;
    int rightIndex = 0;
    int mergedIndex = 0;

    while (leftIndex < left.Length && rightIndex < right.Length)
    {
        if (left[leftIndex] < right[rightIndex])
        {
            merged[mergedIndex++] = left[leftIndex++];
        }
        else
        {
            merged[mergedIndex++] = right[rightIndex++];
        }
    }

    for (int i = leftIndex; i < left.Length; i++)
    {
        merged[mergedIndex++] = left[i];
    }

    for (int i = rightIndex; i < right.Length; i++)
    {
        merged[mergedIndex++] = right[i];
    }

    return merged;
}