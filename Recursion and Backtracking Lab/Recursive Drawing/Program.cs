int input = int.Parse(Console.ReadLine());
RecursiveDrawing(input);

void RecursiveDrawing(int count)
{
    if(count == 0)
    {
        return;
    }

    Console.WriteLine(new string('*', count));

    RecursiveDrawing(count - 1);

    Console.WriteLine(new string('#', count));
}