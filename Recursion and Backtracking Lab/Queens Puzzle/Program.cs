HashSet<int> attackedRows = new HashSet<int>();
HashSet<int> attackedCols = new HashSet<int>();
HashSet<int> attackedLeftDiagonal = new HashSet<int>();
HashSet<int> attackedRightDiagonal = new HashSet<int>();

bool[,] board = new bool[8, 8];

for (int row = 0; row < board.GetLength(0); row++)
{
    for (int col = 0; col < board.GetLength(1); col++)
    {
        board[row, col] = false;
    }
}

Gen8Queen(board, 0);

void Gen8Queen(bool[,] board, int row)
{
    if (row == board.GetLength(0))
    {
        PrintBoard(board);
        return;
    }

    for (int col = 0; col < board.GetLength(1); col++)
    {
        if (CanAddQueen(row, col))
        {
            attackedCols.Add(col);
            attackedRows.Add(row);
            attackedLeftDiagonal.Add(row + col);
            attackedRightDiagonal.Add(row - col);
            board[row, col] = true;

            Gen8Queen(board, row + 1);

            board[row, col] = false;
            attackedCols.Remove(col);
            attackedRows.Remove(row);
            attackedLeftDiagonal.Remove(row + col);
            attackedRightDiagonal.Remove(row - col);
        }
    }
}

void PrintBoard(bool[,] board)
{
    for (int row = 0; row < board.GetLength(0); row++)
    {
        for (int col = 0; col < board.GetLength(1); col++)
        {
            if (board[row, col])
            {
                Console.Write("* ");
            }
            else
            {
                Console.Write("- ");
            }
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}

bool CanAddQueen(int row, int col)
{
    return !attackedRows.Contains(row) &&
           !attackedCols.Contains(col) &&
           !attackedLeftDiagonal.Contains(row + col) &&
           !attackedRightDiagonal.Contains(row - col);
}