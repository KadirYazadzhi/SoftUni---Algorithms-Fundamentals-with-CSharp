using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) { 
        List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
        int target = int.Parse(Console.ReadLine());
        
        bool[] sums = new bool[target + 1];
        sums[0] = true;

        for (int sum = 0; sum < sums.Length; sum++) {
            if (!sums[sum]) continue;

            foreach (var num in nums) {
                var newSum = sum + num;
                
                if (newSum > target) continue;
                
                sums[newSum] = true;
            }
        }

        var subset = new List<int>();

        while (target > 0) {
            foreach (var num in nums) {
                var prevSum = target - num;

                if (prevSum >= 0 && sums[prevSum]) {
                    subset.Add(num);
                    target = prevSum;
                }
            }
        }
        
        Console.WriteLine(string.Join(" ", subset));
    }
}

