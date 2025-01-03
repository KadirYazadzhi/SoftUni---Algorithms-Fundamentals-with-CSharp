using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) { 
        List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
        int target = int.Parse(Console.ReadLine());
        
        Dictionary<int, int> possibleSums = GetAllPossibleSums(nums);

        if (!possibleSums.ContainsKey(target)) return;
       
        Console.WriteLine(string.Join(" ", FindSubset(possibleSums, target)));
    }

    private static List<int> FindSubset(Dictionary<int, int> sums, int target) {
        List<int> subset = new List<int>();
        
        while (target > 0) {
            int num = sums[target];
            
            target -= num;
            
            subset.Add(num);
        }
        
        return subset;
    }

    private static Dictionary<int, int> GetAllPossibleSums(List<int> nums) {
        Dictionary<int, int> sums = new Dictionary<int, int>();

         foreach (var num in nums) {
             List<int> currentSums = sums.Keys.ToList();

             foreach (var sum in currentSums) {
                 int newSum = sum + num;

                 if (sums.ContainsKey(newSum)) continue;
                 
                 sums.Add(newSum, num);
             }
         }

         return sums;
    }
}


