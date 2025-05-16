int num = int.Parse(Console.ReadLine());

Console.WriteLine(GetFactorielRecursively(num));

int GetFactorielRecursively(int num)
{
    if (num == 1)
    {
        return 1;
    }

    return num * GetFactorielRecursively(num - 1);
}