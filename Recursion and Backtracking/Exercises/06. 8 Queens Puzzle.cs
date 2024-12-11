using System;

public class EightQueenPuzzle {
    public static bool[] attackedCols = new bool[8];
    public static bool[] attackedLeftDiagonals = new bool[15];
    public static bool[] attackedRightDiagonals = new bool[15];

    static void Main(string[] args) {
        var board = new bool[8, 8];
        PutQueens(board, 0);
    }

    static void PutQueens(bool[,] board, int row) {
        if (row == 8) {
            PrintBoard(board);
            return;
        }

        for (int col = 0; col < 8; col++) {
            if (CanPlaceQueen(row, col)) {
                attackedCols[col] = true;
                attackedLeftDiagonals[row - col + 7] = true;
                attackedRightDiagonals[row + col] = true;
                board[row, col] = true;

                PutQueens(board, row + 1);

                attackedCols[col] = false;
                attackedLeftDiagonals[row - col + 7] = false;
                attackedRightDiagonals[row + col] = false;
                board[row, col] = false;
            }
        }
    }

    private static void PrintBoard(bool[,] board) {
        for (int row = 0; row < 8; row++) {
            for (int col = 0; col < 8; col++) {
                Console.Write(board[row, col] ? "* " : "- ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private static bool CanPlaceQueen(int row, int col) {
        return !attackedCols[col] && 
               !attackedLeftDiagonals[row - col + 7] &&
               !attackedRightDiagonals[row + col];
    }
}

