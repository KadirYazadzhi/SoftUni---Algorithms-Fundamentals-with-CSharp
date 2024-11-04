using System;
using System.Linq;

class RecursiveDrawing {
    static void Main(string[] args) {
        Drawing(int.Parse(Console.ReadLine()));
    }

    static void Drawing(int row) {
        if (row == 0) {
            return;
        }
        
        Console.WriteLine(new string('*', row)); 
        
        Drawing(row - 1);
        
        Console.WriteLine(new string('#', row));
    }
}
