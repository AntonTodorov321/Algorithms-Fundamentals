
int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

QuickSort(0, numbers.Length - 1);

Console.WriteLine(string.Join(" ", numbers));

void QuickSort(int start, int end)
{
    if (start >= end)
    {
        return;
    }

    int pivot = start;
    int left = start + 1;
    int right = end;

    while (left <= right)
    {
        if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot])
        {
            Swap(left, right);
        }

        if (numbers[left] <= numbers[pivot])
        {
            left++;
        }

        if (numbers[right] >= numbers[pivot])
        {
            right--;
        }
    }

    Swap(pivot, right);

    bool isLeftArraySmaller = right - 1 - start < end - right + 1;

    if (isLeftArraySmaller)
    {
        QuickSort(start, right - 1);
        QuickSort(right + 1, end);
    }
    else
    {
        QuickSort(right + 1, end);
        QuickSort(start, right - 1);
    }
}

void Swap(int first, int second)
{
    int temp = numbers[first];
    numbers[first] = numbers[second];
    numbers[second] = temp;
}