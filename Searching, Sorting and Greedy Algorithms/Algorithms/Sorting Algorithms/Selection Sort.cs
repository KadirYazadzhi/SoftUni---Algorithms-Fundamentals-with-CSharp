using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program {
    public static List<int> numbers = new List<int>{1, 7, 8, 3, 6, 15, 34, 2, 5};
    
    public static void Main() {
        SelectionSort();
        Console.WriteLine($"The sorted numbers is: {string.Join(" ", numbers)}");
    }

    private static void SelectionSort() {
        for (int i = 0; i < numbers.Count - 1; i++) {
            int min = i;

            for (int j = i + 1; j < numbers.Count; j++) {
                if (numbers[j] < numbers[min]) {
                    min = j;
                }
            }

            Swap(i, min);
        }
    }

    private static void Swap(int first, int second) {
        int temp = numbers[first];
        numbers[first] = numbers[second];
        numbers[second] = temp;
    }
}

