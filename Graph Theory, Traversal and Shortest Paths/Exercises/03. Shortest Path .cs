using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static List<int>[] graph;
    private static int[] parent;
    private static bool[] visited;

    static void Main(string[] args) {
        ReadGraph();

        int start = int.Parse(Console.ReadLine());
        int destination = int.Parse(Console.ReadLine());

        BFS(start, destination);
    }

    private static void BFS(int start, int destination) {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);

        visited[start] = true;

        while (queue.Count > 0) {
            int node = queue.Dequeue();

            if (node == destination) {
                PrintPath(destination);
                return;
            }

            foreach (int child in graph[node]) {
                if (!visited[child]) {
                    parent[child] = node;
                    visited[child] = true;
                    queue.Enqueue(child);
                }
            }
        }

        Console.WriteLine("No path found.");
    }

    private static void PrintPath(int destination) {
        Stack<int> path = new Stack<int>();
        int current = destination;

        while (current != -1) {
            path.Push(current);
            current = parent[current];
        }

        Console.WriteLine($"Shortest path length is: {path.Count - 1}");
        Console.WriteLine(string.Join(" ", path));
    }

    private static void ReadGraph() {
        int n = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());

        graph = new List<int>[n + 1];
        parent = new int[n + 1];
        visited = new bool[n + 1];

        for (int i = 0; i < graph.Length; i++) {
            graph[i] = new List<int>();
        }

        Array.Fill(parent, -1);

        for (int i = 0; i < e; i++) {
            int[] edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int source = edge[0];
            int destination = edge[1];

            graph[source].Add(destination);
            graph[destination].Add(source);
        }
    }
}

