int[] input = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

Console.WriteLine(GetSumRecursively(input, 0));

int GetSumRecursively(int[] input, int index)
{
    if (index == input.Length - 1)
    {
        return input[index];
    }

    return input[index] + GetSumRecursively(input, index + 1);
}