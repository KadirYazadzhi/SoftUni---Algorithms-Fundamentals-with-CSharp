# 🕪 Graph Theory: Traversal and Shortest Paths

This module explores the foundational concepts of **Graph Theory**, focusing on graph traversal techniques, shortest path algorithms, and their applications. By the end of this guide, you will:

- Understand graph terminology and structures.
- Learn to implement and analyze traversal algorithms such as DFS and BFS.
- Master topological sorting and shortest path algorithms in unweighted graphs.

## 📋 Table of Contents
1. **Graph Definitions and Representations**  
    - Terminology and Applications  
    - Representing Graphs  
2. **Graph Traversal Algorithms**  
    - Depth-First Search (DFS)  
    - Breadth-First Search (BFS)  
3. **Graph Connectivity**  
4. **Topological Sorting**  
5. **Shortest Path in Unweighted Graphs**  
6. **Where These Algorithms Are Useful**


## 🔗 Graph Definitions and Representations

### 🟡 Terminology

- **Graph (G)**: A set of nodes (V) connected by edges (E).  
- **Directed Graph**: Edges have a direction.  
- **Undirected Graph**: Edges have no direction.  
- **Weighted Graph**: Edges have weights (costs).  
- **Path**: A sequence of nodes where each pair is connected by an edge.  
- **Cycle**: A path that begins and ends at the same node.  
- **Connected Graph**: All nodes are reachable from any other node.  

### 🔖 Representing Graphs

- **Adjacency List**: Each node holds a list of its neighbors.
- **Adjacency Matrix**: A 2D array where each cell indicates if an edge exists.
- **List of Edges**: A list containing all edges of the graph.

### Example: Adjacency List Representation
```csharp
var g = new List<int>[] {
    new List<int> { 3, 6 },
    new List<int> { 2, 3, 4, 5, 6 },
    new List<int> { 1, 4, 5 },
    new List<int> { 0, 1, 5 },
    new List<int> { 1, 2, 6 },
    new List<int> { 1, 2, 3 },
    new List<int> { 0, 1, 4 }
};
```


## 🔎 Graph Traversal Algorithms

### 🟢 Depth-First Search (DFS)

**Description**: Traverses deep into a graph before backtracking.

**Time Complexity**: O(V + E) for adjacency list representation.

**Code Example**:
```csharp
void DFS(int node, bool[] visited, List<int>[] graph) {
    visited[node] = true;
    foreach (int neighbor in graph[node]) {
        if (!visited[neighbor]) {
            DFS(neighbor, visited, graph);
        }
    }
}
```

### 🟣 Breadth-First Search (BFS)

**Description**: Traverses level by level using a queue.

**Time Complexity**: O(V + E).

**Code Example**:
```csharp
void BFS(int start, List<int>[] graph) {
    bool[] visited = new bool[graph.Length];
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);
    visited[start] = true;

    while (queue.Count > 0) {
        int node = queue.Dequeue();
        foreach (int neighbor in graph[node]) {
            if (!visited[neighbor]) {
                queue.Enqueue(neighbor);
                visited[neighbor] = true;
            }
        }
    }
}
```

## 🔗 Graph Connectivity

**Description**: Identifies connected components in an undirected graph.

**Algorithm**:
- Traverse the graph using DFS or BFS.
- Mark all visited nodes as part of the current component.

**Code Example**:
```csharp
int FindConnectedComponents(List<int>[] graph) {
    bool[] visited = new bool[graph.Length];
    int count = 0;

    for (int i = 0; i < graph.Length; i++) {
        if (!visited[i]) {
            DFS(i, visited, graph);
            count++;
        }
    }

    return count;
}
```


## 🏢 Topological Sorting

**Description**: Orders nodes of a directed graph such that for every directed edge (u, v), node u comes before node v.

**Code Example (Source Removal)**:
```csharp
List<int> TopologicalSort(List<int>[] graph, int[] inDegree) {
    Queue<int> queue = new Queue<int>();
    List<int> result = new List<int>();

    for (int i = 0; i < inDegree.Length; i++) {
        if (inDegree[i] == 0) {
            queue.Enqueue(i);
        }
    }

    while (queue.Count > 0) {
        int node = queue.Dequeue();
        result.Add(node);

        foreach (int neighbor in graph[node]) {
            inDegree[neighbor]--;
            if (inDegree[neighbor] == 0) {
                queue.Enqueue(neighbor);
            }
        }
    }

    return result;
}
```


## 📈 Shortest Path in Unweighted Graphs

**Description**: BFS can find the shortest path when all edges have the same weight.

**Code Example**:
```csharp
void ShortestPathBFS(int start, int end, List<int>[] graph) {
    bool[] visited = new bool[graph.Length];
    int[] parent = new int[graph.Length];
    Queue<int> queue = new Queue<int>();

    queue.Enqueue(start);
    visited[start] = true;

    while (queue.Count > 0) {
        int node = queue.Dequeue();
        if (node == end) {
            PrintPath(parent, start, end);
            return;
        }

        foreach (int neighbor in graph[node]) {
            if (!visited[neighbor]) {
                visited[neighbor] = true;
                parent[neighbor] = node;
                queue.Enqueue(neighbor);
            }
        }
    }
}

void PrintPath(int[] parent, int start, int end) {
    Stack<int> path = new Stack<int>();
    for (int at = end; at != start; at = parent[at]) {
        path.Push(at);
    }
    path.Push(start);

    Console.WriteLine(string.Join(" -> ", path));
}
```


## 🛠️ Where These Algorithms Are Useful

- **DFS**:
  - Solving maze and puzzle problems.
  - Detecting cycles in a graph.
  - Topological sorting in DAGs.

- **BFS**:
  - Finding shortest paths in unweighted graphs.
  - Web crawling and social network analysis.
  - Broadcasting in network graphs.

- **Graph Connectivity**:
  - Analyzing subnetworks in communication systems.
  - Clustering in social networks.

- **Topological Sorting**:
  - Task scheduling where dependencies exist.
  - Resolving build dependencies in software.

- **Shortest Path Algorithms**:
  - Navigation systems (e.g., GPS).
  - Network packet routing.
  - Resource allocation in grid systems.


## 📚 Summary

- **Graph Definitions**: Understand nodes, edges, paths, and cycles.
- **Representations**: Adjacency lists, matrices, and edge lists.
- **Traversal Algorithms**: Use DFS for depth exploration and BFS for breadth exploration.
- **Topological Sorting**: Useful for directed acyclic graphs.
- **Shortest Path**: BFS is optimal for unweighted graphs.

> By mastering these concepts, you will be well-equipped to solve real-world problems involving graph structures. 🚀

## 💬 Feedback & Contribution

Contributions and feedback are welcome!

- 💡 Have ideas for improvement? Open an issue.
- 🛠️ Want to contribute? Submit a pull request.


## 👨‍💻 Author

If you have any questions or suggestions, feel free to reach out at:

- 📧 Email: kadiryazadzhi@gmail.com
- 🌐 Portfolio: [Kadir Yazadzhi](https://kadiryazadzhi.github.io/portfolio/)

## ❓ Questions?

For further information, explore:
- [SoftUni](softuni.bg)

 > This guide is powered by insights from SoftUni's presentation on Graph Theory, Traversal and Shortest Paths.

---

Join me on this learning journey, and feel free to explore and try out the solutions on your own. Happy coding! 😃

By mastering these concepts, you will be well-equipped to solve real-world problems involving graph structures. 🚀

