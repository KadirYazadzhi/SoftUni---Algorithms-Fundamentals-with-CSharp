using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    public static void Main() {
        List<string> girls = Console.ReadLine().Split(", ").ToList();
        string[] girlsComb = new string[3];
        List<string[]> girstCombs = new List<string[]>();

        GenCombs(0, 0, girls, girlsComb, girstCombs);
        
        List<string> boys = Console.ReadLine().Split(", ").ToList();
        string[] boysComb = new string[2];
        List<string[]> boysCombs = new List<string[]>();
        
        GenCombs(0, 0, boys, boysComb, boysCombs);
        
        PrintFinalCombs(girstCombs, boysCombs);
    }

    private static void PrintFinalCombs(List<string[]> girstCombs, List<string[]> boysCombs) {
        foreach (string[] girl in girstCombs) {
            foreach (string[] boy in boysCombs) {
                Console.WriteLine($"{string.Join(", ", girl)}, {string.Join(", ", boy)}");
            }
        }
    }

    private static void GenCombs(int idx, int start, List<string> elements, string[] comb, List<string[]> combs) {
        if (idx >= comb.Length) {
            combs.Add(comb.ToArray());
            return;
        }

        for (int i = start; i < elements.Count; i++) {
            comb[idx] = elements[i];
            GenCombs(idx + 1, i + 1, elements, comb, combs);
        }
    }
}
