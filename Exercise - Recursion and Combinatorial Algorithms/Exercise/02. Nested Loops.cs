using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static int[] elemenents;
    
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        
        elemenents = new int[n];

        GenVectors(0);
    }

    private static void GenVectors(int idx) {
        if (idx >= elemenents.Length) {
            Console.WriteLine(string.Join(" ", elemenents));
            return;
        }

        for (int i = 1; i <= elemenents.Length; i++) {
            elemenents[idx] = i;
            GenVectors(idx + 1);
        }
    }
} 
