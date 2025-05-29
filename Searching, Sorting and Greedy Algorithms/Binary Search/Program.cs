
int[] elements = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

int searchingElement = int.Parse(Console.ReadLine());

Console.WriteLine(BinarySearch());

int BinarySearch()
{
    int start = 0;
    int end = elements.Length - 1;

    while (start <= end)
    {
        int middle = (start + end) / 2;

        if (elements[middle] > searchingElement)
        {
            end = middle - 1;
        }
        else if (elements[middle] < searchingElement)
        {
            start = middle + 1;
        }
        else
        {
            return middle;
        }
    }

    return -1;
}