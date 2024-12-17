using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Edge {
    public string First { get; set; }
    public string Second { get; set; }

    public override string ToString() {
        return $"{First} - {Second}";
    }
}

class Program {
    private static Dictionary<string, List<string>> graph;
    private static List<Edge> edges;
    
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        
        graph = new Dictionary<string, List<string>>();
        edges = new List<Edge>(); // Initialize the list

        for (int i = 0; i < n; i++) {
            string[] nodeAndChildren = Console.ReadLine().Split(" -> ");
            
            string node = nodeAndChildren[0];
            List<string> children = nodeAndChildren[1].Split().ToList();
            
            graph[node] = children;

            foreach (var child in children) {
                edges.Add(new Edge { First = node, Second = child }); // Fix: Correctly store edges
            }
        }
        
        edges = edges.OrderBy(e => e.First).ThenBy(e => e.Second).ToList(); // Fix sorting chain

        List<Edge> removedEdges = new List<Edge>();
        
        foreach (Edge edge in edges) {
            
            bool removed = graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);

            if (!removed) continue;
            
            if (BFS(edge.First, edge.Second)) {
                removedEdges.Add(edge);
                continue;
            }
            
            graph[edge.First].Add(edge.Second);
            graph[edge.Second].Add(edge.First);
        }
        
        Console.WriteLine($"Edges to remove: {removedEdges.Count}");

        foreach (var edge in removedEdges) {
            Console.WriteLine(edge);
        }
    }

    private static bool BFS(string start, string destination) {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(start);
        
        HashSet<string> visited = new HashSet<string> { start };

        while (queue.Count > 0) {
            string node = queue.Dequeue();

            if (node == destination) {
                return true;
            }

            foreach (var child in graph[node]) {
                if (visited.Contains(child)) continue;
                
                visited.Add(child);
                queue.Enqueue(child);
            }
        }
        
        return false;
    }
}

