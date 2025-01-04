using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {
        int replaceCost = int.Parse(Console.ReadLine());
        int insertCost = int.Parse(Console.ReadLine());
        int deleteCost = int.Parse(Console.ReadLine());
        
        string str1 = Console.ReadLine();
        string str2 = Console.ReadLine();
        
        int[,] dp = new int[str1.Length + 1, str2.Length + 1];

        for (int col = 1; col < dp.GetLength(1); col++) {
            dp[0, col] = dp[0, col - 1] + insertCost;
        }

        for (int row = 1; row < dp.GetLength(0); row++) {
            dp[row, 0] = dp[row - 1, 0] + deleteCost;
        }

        for (int row = 1; row < dp.GetLength(0); row++) {
            for (int col = 1; col < dp.GetLength(1); col++) {
                if (str1[row - 1] == str2[col - 1]) {
                    dp[row, col] = dp[row - 1, col - 1];
                }
                else {
                    int replace = dp[row - 1, col - 1] + replaceCost;
                    int delete = dp[row - 1, col] + deleteCost;
                    int insert = dp[row, col - 1] + insertCost;
                    
                    dp[row, col] = Math.Min(Math.Min(replace, delete), insert);
                }
            }
        }
        
        Console.WriteLine($"Minimum edit distance: {dp[str1.Length, str2.Length]}");
    }
}
