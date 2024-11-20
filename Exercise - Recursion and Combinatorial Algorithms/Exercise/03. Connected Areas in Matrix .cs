using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

class Program {
    private const char VisitedSymbol = '$';
    private static char[,] matrix;
    private static int size = 0;
    
    static void Main() {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        
        matrix = new char[rows, cols];
        
        ReadMatrix(rows, cols);
        
        List<Area> areas = new List<Area>();
        
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                size = 0;
                ExploreArea(row, col);

                if (size != 0) {
                    areas.Add(new Area(row, col, size));
                }
            }
        }
        
        List<Area> sorted = areas.OrderByDescending(a => a.Size).ThenBy(a => a.Row).ThenBy(a => a.Col).ToList();
        
        PrintResult(sorted);
    }

    private static void PrintResult(List<Area> sorted) {
        Console.WriteLine($"Total areas found: {sorted.Count}");
        for (int i = 0; i < sorted.Count; i++) {
            Console.WriteLine($"Area #{i + 1} at ({sorted[i].Row}, {sorted[i].Col}), size: {sorted[i].Size}");
        }
    }

    private static void ReadMatrix(int rows, int cols) {
        for (int row = 0; row < rows; row++) {
            string colElements = Console.ReadLine();

            for (int col = 0; col < cols; col++) {
                matrix[row, col] = colElements[col];
            }
        }
    }

    private static void ExploreArea(int row, int col) {
        if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col)) {
            return;
        }

        size++;
        matrix[row, col] = VisitedSymbol;
        
        ExploreArea(row - 1, col);
        ExploreArea(row + 1, col);
        ExploreArea(row, col - 1);
        ExploreArea(row, col + 1);
    }

    private static bool IsVisited(int row, int col) {
        return matrix[row, col] == VisitedSymbol;
    }

    private static bool IsWall(int row, int col) {
        return matrix[row, col] == '*';
    }

    private static bool IsOutside(int row, int col) {
        return row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);
    }
}

public class Area {
    public Area(int row, int col, int size) {
        Row = row;
        Col = col;
        Size = size;
    }
    
    public int Row { get; set; }
    public int Col { get; set; }
    public int Size { get; set; }
}
