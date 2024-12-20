using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static char[,] graph;
    private static bool[,] visited;
    private static SortedDictionary<char, int> areas;
    
    static void Main(string[] args) {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        
        graph = new char[rows, cols];
        visited = new bool[rows, cols];
        areas = new SortedDictionary<char, int>();

        for (int r = 0; r < rows; r++) {
            string rowElements = Console.ReadLine();

            for (int c = 0; c < cols; c++) {
                graph[r, c] = rowElements[c];
            }
        }

        int areasCount = 0;
        
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (visited[r, c]) {
                    continue;
                }

                char nodeValue = graph[r, c];
                DFS(r, c, nodeValue);

                areasCount++;

                if (areas.ContainsKey(nodeValue)) {
                    areas[nodeValue]++;
                }
                else {
                    areas[nodeValue] = 1;
                }
            }
        }
        
        Console.WriteLine($"Areas: {areasCount}");
        foreach (var kvp in areas) {
            Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
        }
    }

    private static void DFS(int row, int col, char nodeValue) {
        if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1)) {
            return;
        }

        if (visited[row, col]) {
            return;
        }

        if (graph[row, col] != nodeValue) {
            return;
        }
        
        visited[row, col] = true;
        
        DFS(row - 1, col, nodeValue);
        DFS(row + 1, col, nodeValue);
        DFS(row, col - 1, nodeValue);
        DFS(row, col + 1, nodeValue);
    }
}

