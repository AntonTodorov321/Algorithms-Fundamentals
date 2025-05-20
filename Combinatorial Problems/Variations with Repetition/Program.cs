

string[] input = Console.ReadLine().Split(" ");
int k = int.Parse(Console.ReadLine());
string[] result = new string[k];

VariationsWithRepetition(0);

void VariationsWithRepetition(int index)
{
    if (index == result.Length)
    {
        Console.WriteLine(string.Join(" ", result));
        return;
    }

    for (int i = 0; i < input.Length; i++)
    {
        result[index] = input[i];
        VariationsWithRepetition(index + 1);
    }
}