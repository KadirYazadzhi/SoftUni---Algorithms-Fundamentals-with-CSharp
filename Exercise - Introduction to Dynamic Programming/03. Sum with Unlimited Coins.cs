using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        int target = int.Parse(Console.ReadLine());
        
        Console.WriteLine(CountSums(numbers, target));
    }

    private static int CountSums(List<int> numbers, int target) {
        var sums = new int[target + 1];
        sums[0] = 1;

        foreach (int number in numbers) {
            for (int sum = number; sum <= target; sum++) {
                sums[sum] += sums[sum - number];
            }
        }
        
        return sums[target];
    }
}
