using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static List<int> numbers = new List<int>{1, 7, 23, 12, 4, 8, 14, 2, 5, 21, 32};
    
    public static void Main() {
        QuickSort(0, numbers.Count - 1);
        Console.WriteLine(string.Join(" ", numbers));
    }

    private static void QuickSort(int start, int end) {
        if (start >= end) return;
        
        int pivot = start;
        int left = start + 1;
        int right = end;

        while (left <= right) {
            if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot]) {
                Swap(left, right);
            }

            if (numbers[left] <= numbers[pivot]) {
                left++;
            }

            if (numbers[right] >= numbers[pivot]) {
                right--;
            }
        }
        
        Swap(pivot, right);
        
        QuickSort(start, right - 1);
        QuickSort(right + 1, end);
    }

    private static void Swap(int first, int second) {
        int temp = numbers[first];
        numbers[first] = numbers[second];
        numbers[second] = temp;
    }
}
