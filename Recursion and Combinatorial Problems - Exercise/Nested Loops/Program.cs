
int n = int.Parse(Console.ReadLine());
int[] output = new int[n];

Permute(0);

void Permute(int index)
{
    if (index == n)
    {
        Console.WriteLine(string.Join(" ", output));
        return;
    }

    for (int i = 1; i <= n; i++)
    {
        output[index] = i;
        Permute(index + 1);
    }
}