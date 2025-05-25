
string[] girls = Console.ReadLine().Split(", ");
string[] boys = Console.ReadLine().Split(", ");

string[] girlsResult = new string[3];
string[] boysResult = new string[2];

List<string[]> girlPermutations = new List<string[]>();
List<string[]> boysPermutations = new List<string[]>();

GenerateCombinations(girls, 0, 0, girlsResult, girlPermutations);
GenerateCombinations(boys, 0, 0, boysResult, boysPermutations);

PrintOutput();

void PrintOutput()
{
    foreach (var girls in girlPermutations)
    {
        foreach (var boys in boysPermutations)
        {
            Console.WriteLine($"{string.Join(", ", girls)}, {string.Join(", ", boys)}");
        }
    }
}

void GenerateCombinations(
    string[] people, int index, int start, string[] result, List<string[]> resultPermutations)
{
    if (index == result.Length)
    {
        resultPermutations.Add(result.ToArray());
        return;
    }

    for (int i = start; i < people.Length; i++)
    {
        result[index] = people[i];
        GenerateCombinations(people, index + 1, i + 1, result, resultPermutations);
    }
}