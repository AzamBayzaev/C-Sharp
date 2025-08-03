using System;

class KnapsackProblem
{
    
    public static int Knapsack((int weight, int value)[] items, int maxWeight)
    {
        int n = items.Length;
        int[,] dp = new int[n + 1, maxWeight + 1];

        for (int i = 1; i <= n; i++)
        {
            int weight = items[i - 1].weight;
            int value = items[i - 1].value;

            for (int w = 0; w <= maxWeight; w++)
            {
                if (weight > w)
                {
                    dp[i, w] = dp[i - 1, w];
                }
                else
                {
                    dp[i, w] = Math.Max(dp[i - 1, w], dp[i - 1, w - weight] + value);
                }
            }
        }

        return dp[n, maxWeight];
    }

    static void Main(string[] args)
    {
        var items = new (int weight, int value)[]
        {
            (2, 3),
            (1, 2),
            (3, 4),
            (2, 2)
        };
        int maxWeight = 5;

        int maxValue = Knapsack(items, maxWeight);
        Console.WriteLine($"Максимальная стоимость: {maxValue}");
    }
}
