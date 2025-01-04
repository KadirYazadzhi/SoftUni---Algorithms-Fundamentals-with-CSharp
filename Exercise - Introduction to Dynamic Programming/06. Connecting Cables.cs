using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        List<int> position = Enumerable.Range(1, numbers.Count).ToList();
        
        var dp = new int[numbers.Count + 1, numbers.Count + 1];

        for (int row = 1; row < dp.GetLength(0); row++) {
            for (int col = 1; col < dp.GetLength(1); col++) {
                if (numbers[row - 1] == position[col - 1]) {
                    dp[row, col] = dp[row - 1, col - 1] + 1;
                }
                else {
                    dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                }
            }
        }
        
        Console.WriteLine($"Maximum pairs connected: {dp[numbers.Count, numbers.Count]}");
    }
}
