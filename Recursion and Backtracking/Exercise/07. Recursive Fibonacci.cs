using System;
using System.Collections.Generic;

class RecursiveFibonacci {
    private static Dictionary<int, long> memo = new Dictionary<int, long>();

    static void Main() {
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine(GetFibonacci(n));
    }

    static long GetFibonacci(int n) {
     
        if (n == 0 || n == 1) return 1;
        
        if (memo.ContainsKey(n)) {
            return memo[n];
        }
        
        long fib = GetFibonacci(n - 1) + GetFibonacci(n - 2);
        memo[n] = fib;

        return fib;
    }
}



