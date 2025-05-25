

List<string> friends = Console.ReadLine().TrimEnd().Split(", ").ToList();
string[] fixedFriends = new string[friends.Count];
bool[] fixedFriendsPosition = new bool[friends.Count];

while (true)
{
    string[] command = Console.ReadLine().Split(" - ");

    if (command[0] == "generate")
    {
        break;
    }

    string fried = command[0];
    int position = int.Parse(command[1]) - 1;

    fixedFriends[position] = fried;
    fixedFriendsPosition[position] = true;

    friends.Remove(fried);
}

GenerateFriendsPosition(0);

void GenerateFriendsPosition(int index)
{
    if (index == friends.Count)
    {
        PrintFriends();
        return;
    }

    GenerateFriendsPosition(index + 1);

    for (int i = index + 1; i < friends.Count; i++)
    {
        Swap(index, i);
        GenerateFriendsPosition(index + 1);
        Swap(index, i);
    }
}

void PrintFriends()
{
    int nonStaticIndex = 0;

    for (int i = 0; i < fixedFriends.Length; i++)
    {
        if (!fixedFriendsPosition[i])
        {
            fixedFriends[i] = friends[nonStaticIndex++];
        }
    }

    Console.WriteLine(string.Join(" ", fixedFriends));
}

void Swap(int first, int second)
{
    string temp = friends[first];
    friends[first] = friends[second];
    friends[second] = temp;
}