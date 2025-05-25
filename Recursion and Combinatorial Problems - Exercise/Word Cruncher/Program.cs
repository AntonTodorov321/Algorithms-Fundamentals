
string[] syllables = Console.ReadLine().Split(", ");
string target = Console.ReadLine();

Dictionary<string, int> syllableCount = new Dictionary<string, int>();
Dictionary<int, List<string>> syllableIndex = new Dictionary<int, List<string>>();

foreach (var syllable in syllables)
{
    int index = target.IndexOf(syllable);

    if (index == -1)
    {
        continue;
    }

    if (syllableCount.ContainsKey(syllable))
    {
        syllableCount[syllable]++;
        continue;
    }

    syllableCount[syllable] = 1;

    while (index != -1)
    {
        if (!syllableIndex.ContainsKey(index))
        {
            syllableIndex[index] = new List<string>();
        }

        syllableIndex[index].Add(syllable);

        index = target.IndexOf(syllable, index + syllable.Length);
    }
}

WordCruncher(0, new LinkedList<string>());

void WordCruncher(int index, LinkedList<string> result)
{
    if (index == target.Length)
    {
        Console.WriteLine(string.Join(" ", result));
        return;
    }

    if (syllableIndex.ContainsKey(index))
    {
        foreach (var syllable in syllableIndex[index])
        {
            if (syllableCount[syllable] == 0) 
            {
                continue;
            }

            syllableCount[syllable]--;
            result.AddLast(syllable);

            WordCruncher(index + syllable.Length, result);

            result.RemoveLast();
            syllableCount[syllable]++;
        }
    }
}