using System;
using System.Linq;

class GenerateZeroOrOneVectors {
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        
        GenerateZeroOrOne(array, 0);
    }

    static void GenerateZeroOrOne(int[] array, int index) {
        if (index >= array.Length) {
            Console.WriteLine(string.Join(string.Empty, array));
            return;
        }

        for (int i = 0; i < 2; i++) {
            array[index] = i;
            GenerateZeroOrOne(array, index + 1);
        }
    }
}

