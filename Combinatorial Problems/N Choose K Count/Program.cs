
int n = int.Parse(Console.ReadLine());
int k = int.Parse(Console.ReadLine());

Console.WriteLine(GetBinom(n, k));

int GetBinom(int row, int col)
{
    if (row <= 1 || col == 0 || col == row)
    {
        return 1;
    }

    return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
}