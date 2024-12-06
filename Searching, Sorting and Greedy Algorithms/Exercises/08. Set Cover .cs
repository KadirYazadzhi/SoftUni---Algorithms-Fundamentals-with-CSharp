using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    public static void Main() {
        SetCover();
    }

    private static void SetCover() {
        HashSet<int> universe = Console.ReadLine().Split(", ").Select(int.Parse).ToHashSet();
        
        int n = int.Parse(Console.ReadLine());
        
        List<List<int>> sets = new List<List<int>>();

        for (int i = 0; i < n; i++) {
            List<int> set = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            
            sets.Add(set);
        }
        
        List<List<int>> selectedSets = new List<List<int>>();

        while (universe.Count > 0) {
            var set = sets.OrderByDescending(s => s.Count(e => universe.Contains(e))).FirstOrDefault();
            
            selectedSets.Add(set);
            
            sets.Remove(set);

            foreach (var element in set) {
                universe.Remove(element);
            }
        }
        
        Print(selectedSets);
    }

    private static void Print(List<List<int>> selectedSets) {
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (var set in selectedSets) {
            Console.WriteLine(string.Join(", ", set));
        }
    }
}
