
int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

ReverseNumbers(0);

void ReverseNumbers(int index)
{
    if (index >= input.Length / 2)
    {
        Console.WriteLine(string.Join(" ", input));
        return;
    }

    Swap(index, input.Length - index - 1);
    ReverseNumbers(index + 1);
}

void Swap(int first, int second)
{
    int temp = input[first];
    input[first] = input[second];
    input[second] = temp;
}