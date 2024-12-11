using System;
using System.Linq;
using System.Collections.Generic;

class PathsInLabyrinth {
    static void Main(string[] args) {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        
        var lab = new char[rows, cols];

        for (int i = 0; i < rows; i++) {
            string line = Console.ReadLine();

            for (int j = 0; j < line.Length; j++) {
                lab[i, j] = line[j];
            }
        }
        findPaths(lab, 0, 0, new List<string>(), String.Empty);
    }

    static void findPaths(char[,] lab, int rows, int cols, List<string> directions, string direction) {
        if (rows < 0 || rows >= lab.GetLength(0) || cols < 0 || cols >= lab.GetLength(1) || lab[rows, cols] == '*' || lab[rows, cols] == '&') {
            return;
        }
        
        directions.Add(direction);

        if (lab[rows, cols] == 'e') {
            Console.WriteLine(string.Join(String.Empty, directions));
            directions.RemoveAt(directions.Count - 1);
            return;
        }
        
        lab[rows, cols] = '&';
        
        findPaths(lab, rows - 1, cols, directions, "U");
        findPaths(lab, rows + 1, cols, directions, "D");
        findPaths(lab, rows, cols - 1, directions, "L");
        findPaths(lab, rows, cols + 1, directions, "R");
        
        lab[rows, cols] = '-';
        directions.RemoveAt(directions.Count - 1);
    }
}

