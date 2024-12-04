using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program {
    public static List<int> numbers = new List<int>{1,2,3,4,5,6,7,8,9,10};
    
    public static void Main() {
        Console.WriteLine("Enter a number to search for: ");
        int target = int.Parse(Console.ReadLine());

        int numberIndex = LinearSearch(target);
        if (numberIndex == -1) {
            Console.WriteLine("No number found");
            return;
        }
        
        Console.WriteLine($"The number is found at index {numberIndex}");
    }

    private static int LinearSearch(int target) {
        for (int i = 0; i < numbers.Count; i++) {
            if (numbers[i] == target) {
                return i;
            }
        }

        return -1;
    }
}

