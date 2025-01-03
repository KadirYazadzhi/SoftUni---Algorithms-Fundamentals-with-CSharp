using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<int, long> cache = new Dictionary<int, long>();
    
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(CalFibonacci(n));
    }

    static long CalFibonacci(int n) {
        if (cache.ContainsKey(n)) return cache[n];
        
        if (n < 2) return n;
        
        long result = CalFibonacci(n - 1) + CalFibonacci(n - 2);
        cache[n] = result;
        
        return result;
    }
}


