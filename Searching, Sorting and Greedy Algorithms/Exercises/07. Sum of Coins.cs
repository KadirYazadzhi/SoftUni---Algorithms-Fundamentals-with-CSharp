using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    public static void Main() {
        SumOfCoins();
    }

    private static void SumOfCoins() {
        Queue<int> coins = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(x => x));
        
        int target = int.Parse(Console.ReadLine());
        Dictionary<int, int> selectedCoins = new Dictionary<int, int>();
        int totalCoins = 0;

        while (target > 0 && coins.Count > 0) {
            int currentCoin = coins.Dequeue();
            int count = target / currentCoin;

            if (count == 0) {
                continue;
            }
            
            selectedCoins[currentCoin] = count;
            totalCoins += count;
            
            target %= currentCoin;
        }
        
        PrintSumOfCoins(totalCoins, selectedCoins, target);
    }

    private static void PrintSumOfCoins(int totalCoins, Dictionary<int, int> selectedCoins, int target) {
        if (target != 0) {
            Console.WriteLine("Error");
            return;
        }
        
        Console.WriteLine($"Number of coins to take: {totalCoins}");

        foreach ((int coinType, int coinCount) in selectedCoins) {
            Console.WriteLine($"{coinType} coin(s) with value {coinCount}");
        }
    }
}
