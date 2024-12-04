using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program {
    public static List<int> numbers = new List<int>();
    
    public static void Main() {
        numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        BubbleSort();
        Console.WriteLine(string.Join(" ", numbers));
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

