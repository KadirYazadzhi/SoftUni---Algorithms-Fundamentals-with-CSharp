using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {
        List<int> presents = Console.ReadLine().Split().Select(int.Parse).ToList();

        Dictionary<int, int> allSum = FindAllSums(presents);

        int totalSum = presents.Sum();
        int alanSum = totalSum / 2;

        while (alanSum >= 0) { 
            if (allSum.ContainsKey(alanSum)) {
                var alanPresents = FindSubset(allSum, alanSum);
                
                var bobSum = totalSum - alanSum;
                
                Console.WriteLine($"Difference: {bobSum - alanSum}");
                Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
                Console.WriteLine("Bob takes the rest.");
                break;
            }
            alanSum--;
        }
    }

    private static List<int> FindSubset(Dictionary<int, int> allSum, int target) {
        var subset = new List<int>();

        while (target != 0) {
            int prevSum = allSum[target];
            int element = target - prevSum; 
            subset.Add(element);
            target = prevSum; 
        }

        return subset;
    }

    private static Dictionary<int, int> FindAllSums(List<int> presents) {
        Dictionary<int, int> sums = new Dictionary<int, int> { { 0, -1 } }; 

        foreach (int element in presents) {
            List<int> currentSum = sums.Keys.ToList();

            foreach (int sum in currentSum) {
                int newSum = sum + element;

                if (sums.ContainsKey(newSum)) continue;

                sums.Add(newSum, sum);
            }
        }

        return sums;
    }
}
