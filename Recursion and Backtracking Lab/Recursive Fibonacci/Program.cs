
int num = int.Parse(Console.ReadLine());

Console.WriteLine(GetFibonacci(num));

long GetFibonacci(int num)
{
    if (num <= 1)
    {
        return 1;
    }

    return GetFibonacci(num - 1) + GetFibonacci(num - 2);
}