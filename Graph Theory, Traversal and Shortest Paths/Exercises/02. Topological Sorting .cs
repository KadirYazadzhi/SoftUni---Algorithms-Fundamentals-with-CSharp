using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<string, List<string>> graph;
    private static Dictionary<string, int> dependencies;

    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());

        graph = ReadGraph(n);
        dependencies = ExtractDependencies(graph);

        List<string> sorted = new List<string>();
        while (dependencies.Count > 0) {
            string nodeToRemove = dependencies.FirstOrDefault(d => d.Value == 0).Key;

            if (nodeToRemove == null) {
                break;
            }

            dependencies.Remove(nodeToRemove);
            sorted.Add(nodeToRemove);

            foreach (string child in graph[nodeToRemove]) {
                if (dependencies.ContainsKey(child)) {
                    dependencies[child]--;
                }
            }
        }

        if (dependencies.Count > 0) {
            Console.WriteLine("Invalid topological sorting");
            return;
        }

        Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
    }

    private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> graph) {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var kvp in graph) {
            string node = kvp.Key;
            List<string> children = kvp.Value;

            if (!result.ContainsKey(node)) {
                result[node] = 0;
            }

            foreach (string child in children) {
                if (!result.ContainsKey(child)) {
                    result[child] = 0;
                }

                result[child]++;
            }
        }

        return result;
    }

    private static Dictionary<string, List<string>> ReadGraph(int n) {
        Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

        for (int i = 0; i < n; i++) {
            string[] parts = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToArray();

            string key = parts[0];
            List<string> children = parts.Length > 1
                ? parts[1].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToList()
                : new List<string>();

            result[key] = children;
        }

        return result;
    }
}

