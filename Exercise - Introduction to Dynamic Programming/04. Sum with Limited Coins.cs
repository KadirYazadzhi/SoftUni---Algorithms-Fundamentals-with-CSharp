using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        int target = int.Parse(Console.ReadLine());
        
        Console.WriteLine(CountSum(numbers, target));
    }

    private static int CountSum(List<int> numbers, int target) {
        int count = 0;
        HashSet<int> sums = new HashSet<int> { 0 };

        foreach (var number in numbers) {
            HashSet<int> newSums = new HashSet<int>();
            
            foreach (var sum in sums) {
                var newSum = sum + number;

                if (newSum == target) count++;

                newSums.Add(newSum);
            }
            
            sums.UnionWith(newSums);
        }
        
        return count;
    }
}
