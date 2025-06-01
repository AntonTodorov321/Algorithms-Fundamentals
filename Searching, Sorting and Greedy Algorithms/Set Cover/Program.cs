
HashSet<int> universe = Console.ReadLine()!
                        .Split(", ")
                        .Select(int.Parse)
                        .ToHashSet();

int numberOfSets = int.Parse(Console.ReadLine()!);  
List<int[]> sets = new List<int[]>();
List<int[]> result = new List<int[]>();

for (int i = 0; i < numberOfSets; i++)
{
    int[] set = Console.ReadLine()!
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

    sets.Add(set);
}

Universe();

Console.WriteLine($"Sets to take ({result.Count}):");

foreach (var set in result)
{
    Console.WriteLine(string.Join(", ", set));
}

void Universe()
{
    while (universe.Count > 0)
    {
        int[] set = sets
            .OrderByDescending(set => set.Count(s => universe.Contains(s)))
            .FirstOrDefault()!;

        result.Add(set);
        sets.Remove(set);

        foreach (var number in set)
        {
            universe.Remove(number);
        }
    }
}