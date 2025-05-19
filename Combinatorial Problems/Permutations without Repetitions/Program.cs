bool[] used;
string[] input;
string[] result;

input = Console.ReadLine().Split();
result = new string[input.Length];
used = new bool[input.Length];

Permute(0);

void Permute(int index)
{
    if (index == result.Length)
    {
        Console.WriteLine(string.Join(" ", result));
        return;
    }

    for (int i = 0; i < input.Length; i++)
    {
        if (!used[i])
        {
            result[index] = input[i];
            used[i] = true;

            Permute(index + 1);

            used[i] = false;
        }
    }
}