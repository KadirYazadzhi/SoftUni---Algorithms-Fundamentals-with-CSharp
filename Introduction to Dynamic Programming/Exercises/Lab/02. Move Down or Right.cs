using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static int[,] matrix;

    static void Main(string[] args) {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        ReadMatrix(rows, cols);
        int[,] dp = WriteInMatrix(rows, cols);
        FindPath(rows, cols, dp);
    }

    private static void ReadMatrix(int rows, int cols) {
        matrix = new int[rows, cols];

        for (int r = 0; r < rows; r++) {
            List<int> rowElements = Console.ReadLine().Split().Select(int.Parse).ToList();
            for (int c = 0; c < cols; c++) {
                matrix[r, c] = rowElements[c];
            }
        }
    }

    private static int[,] WriteInMatrix(int rows, int cols) {
        var dp = new int[rows, cols];
        dp[0, 0] = matrix[0, 0];

        for (int c = 1; c < cols; c++) {
            dp[0, c] = dp[0, c - 1] + matrix[0, c];
        }

        for (int r = 1; r < rows; r++) {
            dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
        }

        for (int r = 1; r < rows; r++) {
            for (int c = 1; c < cols; c++) {
                dp[r, c] = Math.Max(dp[r - 1, c], dp[r, c - 1]) + matrix[r, c];
            }
        }

        return dp;
    }

    private static void FindPath(int rows, int cols, int[,] dp) {
        Stack<string> path = new Stack<string>();

        int row = rows - 1;
        int col = cols - 1;

        while (row > 0 && col > 0) {
            path.Push($"[{row}, {col}]");

            if (dp[row - 1, col] > dp[row, col - 1]) {
                row--;
            } else {
                col--;
            }
        }

        while (row > 0) {
            path.Push($"[{row}, {col}]");
            row--;
        }

        while (col > 0) {
            path.Push($"[{row}, {col}]");
            col--;
        }

        path.Push($"[0, 0]");

        Console.WriteLine(string.Join(" ", path));
    }
}
