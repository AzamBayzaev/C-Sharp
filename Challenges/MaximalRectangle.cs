
using System;
using System.Collections.Generic;

class MaximalRectangle
{
    public static int MaximalRectangleArea(int[][] matrix)
    {
        if (matrix.Length == 0) return 0;

        int maxArea = 0;
        int[] heights = new int[matrix[0].Length];

        for (int i = 0; i < matrix.Length; i++)
        {
            // Обновляем гистограмму по строкам
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] == 1)
                    heights[j] += 1;
                else
                    heights[j] = 0;
            }

            maxArea = Math.Max(maxArea, LargestRectangleInHistogram(heights));
        }

        return maxArea;
    }

    private static int LargestRectangleInHistogram(int[] heights)
    {
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;
        int[] extendedHeights = new int[heights.Length + 1];
        Array.Copy(heights, extendedHeights, heights.Length);
        extendedHeights[heights.Length] = 0;  // Дополнительный 0 для очистки стека в конце

        for (int i = 0; i < extendedHeights.Length; i++)
        {
            while (stack.Count > 0 && extendedHeights[i] < extendedHeights[stack.Peek()])
            {
                int height = extendedHeights[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }
            stack.Push(i);
        }

        return maxArea;
    }

    static void Main()
    {
        int[][] matrix = new int[][]
        {
            new int[] {1, 0, 1, 0, 0},
            new int[] {1, 0, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1},
            new int[] {1, 0, 0, 1, 0}
        };

        int maxRectangle = MaximalRectangleArea(matrix);
        Console.WriteLine($"Максимальная площадь прямоугольника из 1: {maxRectangle}");
    }
}
