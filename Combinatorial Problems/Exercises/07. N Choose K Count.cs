﻿using System;

class Program {
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine(GetBinom(n, k));
    }

    private static int GetBinom(int row, int col) {
        if (row <= 1 || col == 0 || col == row) {
            return 1;
        }

        return GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
    }

}
