using System;

class SudokuGenerator
{
    static Random rand = new Random();

    static void Main()
    {
        int[,] board = new int[9, 9];
        if (FillBoard(board))
        {
            PrintBoard(board);
        }
        else
        {
            Console.WriteLine("Не удалось сгенерировать доску.");
        }
    }

    static bool FillBoard(int[,] board)
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (board[row, col] == 0)
                {
                    var numbers = ShuffleNumbers();
                    foreach (int num in numbers)
                    {
                        if (CanPlaceNumber(board, row, col, num))
                        {
                            board[row, col] = num;
                            if (FillBoard(board))
                                return true;
                            board[row, col] = 0; 
                        }
                    }
                    return false; 
                }
            }
        }
        return true;
    }

    static int[] ShuffleNumbers()
    {
        int[] nums = new int[9];
        for (int i = 0; i < 9; i++) nums[i] = i + 1;

        
        for (int i = nums.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        return nums;
    }

    static bool CanPlaceNumber(int[,] board, int row, int col, int num)
    {
        for (int c = 0; c < 9; c++)
            if (board[row, c] == num)
                return false;

        for (int r = 0; r < 9; r++)
            if (board[r, col] == num)
                return false;

        int startRow = (row / 3) * 3;
        int startCol = (col / 3) * 3;
        for (int r = 0; r < 3; r++)
            for (int c = 0; c < 3; c++)
                if (board[startRow + r, startCol + c] == num)
                    return false;

        return true;
    }

    static void PrintBoard(int[,] board)
    {
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                Console.Write(board[r, c] + " ");
            }
            Console.WriteLine();
        }
    }
}

