using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<int, List<int>> graph;
    
    static void Main(string[] args) {
        int nodes = int.Parse(Console.ReadLine());
        int pairs = int.Parse(Console.ReadLine());
        
        graph = new Dictionary<int, List<int>>();

        for (int i = 0; i < nodes; i++) {
            List<string> nodeAndChildren = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries).ToList();
            
            int node = int.Parse(nodeAndChildren[0]);

            if (nodeAndChildren.Count == 1) {
                graph[node] = new List<int>();
                continue;
            }
            
            List<int> children = nodeAndChildren[1].Split().Select(int.Parse).ToList();
            graph[node] = children;
        }

        for (int i = 0; i < pairs; i++) {
            int[] pair = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            
            int start = pair[0];
            int destination = pair[1];

            int steps = BFS(start, destination);
            
            Console.WriteLine($"{{{start}, {destination}}} -> {steps}");
        }
    }

    private static int BFS(int start, int destination) {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
    
        HashSet<int> visited = new HashSet<int>();
        Dictionary<int, int> parent = new Dictionary<int, int>();

        visited.Add(start);  

        while (queue.Count > 0) {
            int node = queue.Dequeue();

            if (node == destination) {
                return GetSteps(parent, destination);
            }

            foreach (int child in graph[node]) {
                if (visited.Contains(child)) {
                    continue;
                }
            
                visited.Add(child);
                queue.Enqueue(child);
                parent[child] = node;
            }
        }

        return -1;  
    }

    private static int GetSteps(Dictionary<int, int> parent, int destination) {
        int node = destination;
        int steps = 0;
        
        if (!parent.ContainsKey(destination)) {
            return 0;  
        }

        while (parent.ContainsKey(node) && parent[node] != -1) {
            node = parent[node];
            steps++;
        }

        return steps;
    }
}

