using System;

namespace Main
{
    internal class Factorial
    {
        public static void Run()
        {
            Console.Write("Введите число: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
            {
                Console.WriteLine("Неверный ввод! Введите неотрицательное число.");
                return;
            }

            long fact = 1;
            for (int i = 2; i <= n; i++)
                fact *= i;

            Console.WriteLine($"Факториал числа {n} = {fact}");
        }
    }
}
