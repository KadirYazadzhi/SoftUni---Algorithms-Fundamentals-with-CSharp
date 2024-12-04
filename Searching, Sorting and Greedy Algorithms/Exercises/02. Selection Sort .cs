using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program {
    public static List<int> numbers = new List<int>();
    
    public static void Main() {
        numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        SelectionSort();
        Console.WriteLine(string.Join(" ", numbers));
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

