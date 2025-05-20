
string[] input = Console.ReadLine().Split(" ");
int k = int.Parse(Console.ReadLine());
string[] result = new string[k];
bool[] used = new bool[input.Length];

Variations(0);

void Variations(int index)
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
            Variations(index + 1);
            used[i] = false;
        }
    }
}