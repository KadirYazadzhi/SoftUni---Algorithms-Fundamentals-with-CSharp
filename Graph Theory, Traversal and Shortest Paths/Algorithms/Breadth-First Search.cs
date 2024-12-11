using System;

class Program {
    private static Dictionary<int, List<int>> graph;
    private static HashSet<int> visited;
    
    static void Main() {
        graph = new Dictionary<int, List<int>> {
            { 1, new List<int> { 19, 21, 14 } },
            { 19, new List<int> { 7, 12, 31, 21 } },
            { 7, new List<int> { 1 } },
            { 31, new List<int> { 21 } },
            { 21, new List<int> { 14 } },
            { 23, new List<int> { 21 } },
            { 14, new List<int> { 6, 23 } },
            { 12, new List<int>() },
            { 6, new List<int>() }
        };
        
        visited = new HashSet<int>();

        foreach (var node in graph.Keys) {
            BFS(node);
        }
    }

    private static void BFS(int node) {
        if (visited.Contains(node)) return;

        Queue<int> queue = new Queue<int>();
        
        queue.Enqueue(node);
        visited.Add(node);

        while (queue.Count > 0) {
            int currentNode = queue.Dequeue();
            
            Console.WriteLine(currentNode);

            foreach (int child in graph[currentNode]) {
                if (visited.Contains(child)) continue;
                
                visited.Add(child);
                queue.Enqueue(child);
            }
        }
    }
}
