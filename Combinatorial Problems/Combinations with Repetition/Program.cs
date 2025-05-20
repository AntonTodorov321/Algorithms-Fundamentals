
string[] input = Console.ReadLine().Split();
int k = int.Parse(Console.ReadLine());
string[] result = new string[k];
bool[] used = new bool[input.Length];

Combinations(0, 0);

void Combinations(int index, int startIndex)
{
    if (index == result.Length)
    {
        Console.WriteLine(string.Join(" ", result));
        return;
    }

    for (int i = startIndex; i < input.Length; i++)
    {
        result[index] = input[i];
        Combinations(index + 1, i);

    }
}