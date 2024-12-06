using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static List<int> numbers = new List<int>();
    
    public static void Main() {
        numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        Console.WriteLine(string.Join(" ", MergeSort(numbers)));
    }

    private static List<int> MergeSort(List<int> nums) {
        if (nums.Count <= 1) return nums;

        var mid = nums.Count / 2;
        var left = MergeSort(nums.Take(mid).ToList());
        var right = MergeSort(nums.Skip(mid).ToList());

        return Merge(left, right);
    }


    private static List<int> Merge(List<int> left, List<int> right) {
        var merged = new List<int>();

        int leftIdx = 0;
        int rightIdx = 0;

        while (leftIdx < left.Count && rightIdx < right.Count) {
            if (left[leftIdx] < right[rightIdx]) {
                merged.Add(left[leftIdx++]);
            } else {
                merged.Add(right[rightIdx++]);
            }
        }
        
        while (leftIdx < left.Count) {
            merged.Add(left[leftIdx++]);
        }
        
        while (rightIdx < right.Count) {
            merged.Add(right[rightIdx++]);
        }

        return merged;
    }

}
