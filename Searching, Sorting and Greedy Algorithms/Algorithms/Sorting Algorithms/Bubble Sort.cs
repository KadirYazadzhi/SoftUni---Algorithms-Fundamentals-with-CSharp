using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program {
    public static List<int> numbers = new List<int>{1, 6 , 3, 7, 2, 4, 9, 5, 12, 34, 15};
    
    public static void Main() {
        BubbleSort();
        Console.WriteLine($"The sorted numbers is: {string.Join(" ", numbers)}");
    }

    private static void BubbleSort() {
        bool isSorted = false;
        int sortedCount = 0;

        while (isSorted == false) {
            isSorted = true;
            
            for (int i = 1; i < numbers.Count - sortedCount; i++) {
                int j = i - 1;

                if (numbers[i] < numbers[j]) {
                    Swap(j, i);
                    isSorted = false;
                }
            }
            
            sortedCount++;
        }
    }

    private static void Swap(int first, int second) {
        int temp = numbers[first];
        numbers[first] = numbers[second];
        numbers[second] = temp;
    }
}

