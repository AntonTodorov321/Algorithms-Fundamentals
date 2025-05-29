

int[] elements = Console.ReadLine()
                  .Split(" ")
                  .Select(int.Parse)
                  .ToArray();

SelectionSort();

Console.WriteLine(string.Join(" ", elements));

void SelectionSort()
{
    for (int i = 0; i < elements.Length; i++)
    {
        int minIndex = i;

        for (int j = i + 1; j < elements.Length; j++)
        {
            if (elements[j] < elements[minIndex])
            {
                minIndex = j;
            }
        }

        Swap(i, minIndex);
    }
}

void Swap(int first, int second)
{
    int temp = elements[first];
    elements[first] = elements[second];
    elements[second] = temp;
}