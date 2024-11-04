using System;
using System.Linq;

class RecursiveFactorial {
    static void Main(string[] args) {
        Console.WriteLine(Factorial(int.Parse(Console.ReadLine())));
    }

    static int Factorial(int n) {
        if (n == 0) {
            return 1;
        }
        
        return n * Factorial(n - 1);
    }
}

