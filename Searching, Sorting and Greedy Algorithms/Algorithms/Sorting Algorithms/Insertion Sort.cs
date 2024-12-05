using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program {
    public static List<int> numbers = new List<int>{1, 7, 5, 3, 9, 12, 2, 14, 32};
    
    public static void Main() {
        InsertionSort();
        Console.WriteLine(string.Join(" ", numbers));
    }

    private static void InsertionSort() {
        for (int i = 1; i < numbers.Count; i++) {
            int j = i;
            
            while (j > 0 && numbers[j] < numbers[j - 1]) {
                Swap(j, j - 1);
                j--;
            }
        }
    }

    private static void Swap(int first, int second) {
        int temp = numbers[first];
        numbers[first] = numbers[second];
        numbers[second] = temp;
    }
}

