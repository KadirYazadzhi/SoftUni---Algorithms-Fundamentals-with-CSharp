using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program {
    public static List<int> numbers = new List<int>();
    
    public static void Main() {
        numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        int target = int.Parse(Console.ReadLine());
        
        Console.WriteLine(BinarySearch(target));
    }

    private static int BinarySearch(int target) {
        int left = 0; 
        int right = numbers.Count - 1;

        while (left <= right) {
            int middle = (left + right) / 2;

            if (numbers[middle] == target) {
                return middle;
            }

            if (target > numbers[middle]) {
                left = middle + 1;
                continue;
            }
            
            right = middle - 1;
        }

        return -1;
    }
}

