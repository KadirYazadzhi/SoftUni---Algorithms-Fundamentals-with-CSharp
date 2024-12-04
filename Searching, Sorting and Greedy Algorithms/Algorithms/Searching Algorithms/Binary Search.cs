using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program {
    public static List<int> numbers = new List<int>{5, 10, 15, 30, 50, 80, 140, 150, 155, 167, 190};
    
    public static void Main() {
        Console.WriteLine("Enter a number to search for: ");
        int target = int.Parse(Console.ReadLine());

        int numberIndex = BinarySearch(target);
        if (numberIndex == -1) {
            Console.WriteLine("No number found");
            return;
        }
        
        Console.WriteLine($"The number is found at index {numberIndex}");
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

