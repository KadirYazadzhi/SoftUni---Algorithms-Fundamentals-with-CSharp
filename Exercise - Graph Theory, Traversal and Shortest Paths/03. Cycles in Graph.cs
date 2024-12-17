using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<string, List<string>> graph;
    private static HashSet<string> visited;
    private static HashSet<string> cycles;
    
    static void Main(string[] args) {
        graph = new Dictionary<string, List<string>>();
        visited = new HashSet<string>();
        cycles = new HashSet<string>();

        string line = null;
        while ((line = Console.ReadLine()) != "End") {
            string[] edge = line.Split('-');
            string from = edge[0];
            string to = edge[1];

            if (!graph.ContainsKey(from)) {
                graph.Add(from, new List<string>());
            }
            
            graph[from].Add(to);
        }

        try {
            foreach (string node in graph.Keys) {
                DFS(node);
            }
            
            Console.WriteLine("Acyclic: Yes");
        }
        catch (InvalidOperationException) {
            Console.WriteLine("Acyclic: No");
        }
    }

    private static void DFS(string node) {
        if (cycles.Contains(node)) { throw new InvalidOperationException(); }
        if (visited.Contains(node)) return;
    
        visited.Add(node);
        cycles.Add(node);
    
        if (graph.ContainsKey(node)) { 
            foreach (string child in graph[node]) {
                DFS(child);
            }
        }
    
        cycles.Remove(node);
    }
}
