using System;

namespace Main
{
    internal class MatrixAnalysis
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Random rnd = new Random();
            int rows = 5;
            int cols = 5;
            int[,] matrix = new int[rows, cols];

            // Заполнение массива случайными числами от 1 до 50
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = rnd.Next(1, 51);

            Console.WriteLine("Матрица:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write($"{matrix[i, j],4}");
                Console.WriteLine();
            }

            // Поиск максимума и минимума
            int max = matrix[0, 0], min = matrix[0, 0];
            int maxRow = 0, maxCol = 0, minRow = 0, minCol = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max) { max = matrix[i, j]; maxRow = i; maxCol = j; }
                    if (matrix[i, j] < min) { min = matrix[i, j]; minRow = i; minCol = j; }
                }
            }

            Console.WriteLine($"\nМаксимальный элемент: {max} (строка {maxRow + 1}, столбец {maxCol + 1})");
            Console.WriteLine($"Минимальный элемент: {min} (строка {minRow + 1}, столбец {minCol + 1})");

            // Сумма и среднее по строкам
            Console.WriteLine("\nСумма и среднее по строкам:");
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++)
                    sum += matrix[i, j];
                double avg = (double)sum / cols;
                Console.WriteLine($"Строка {i + 1}: сумма = {sum}, среднее = {avg:F2}");
            }

            // Сумма и среднее по столбцам
            Console.WriteLine("\nСумма и среднее по столбцам:");
            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++)
                    sum += matrix[i, j];
                double avg = (double)sum / rows;
                Console.WriteLine($"Столбец {j + 1}: сумма = {sum}, среднее = {avg:F2}");
            }
        }
    }
}
