using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program {
    public static List<int> numbers = new List<int>();
    
    public static void Main() {
        numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        
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

