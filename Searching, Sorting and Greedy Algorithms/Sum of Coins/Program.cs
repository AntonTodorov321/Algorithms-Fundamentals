
Queue<int> coins = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(num => num));

int target = int.Parse(Console.ReadLine());
Dictionary<int, int> coinsToTake = new Dictionary<int, int>();

SumOfCoins();

void SumOfCoins()
{
    int index = 0;

    while (index < coins.Count && target > 0)
    {
        int coin = coins.Dequeue();
        int count = target / coin;

        if (count > 0)
        {
            coinsToTake.Add(coin, count);
            target -= count * coin;
        }
    }

    if (target > 0)
    {
        Console.WriteLine("Error");
    }
    else
    {
        Console.WriteLine($"Number of coins to take: {coinsToTake.Values.Sum()}");

        foreach (var coin in coinsToTake)
        {
            Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
        }
    }
}