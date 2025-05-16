int input = int.Parse(Console.ReadLine());

Generate01(0, new int[input]);

void Generate01(int index, int[] arr)
{
    for (int i = 0; i <= 1; i++)
    {
        if (index == arr.Length)
        {
            Console.WriteLine(string.Join("", arr));
            return;
        }

        arr[index] = i;
        Generate01(index + 1, arr);
    }
}