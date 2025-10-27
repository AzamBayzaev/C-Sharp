using System;

namespace Main
{
    internal class GuessNumber
    {
        // Метод запуска игры
        public static void Run()
        {
            Random rnd = new Random();          // Генератор случайных чисел
            int secret = rnd.Next(1, 101);     // Загаданное число от 1 до 100
            int guess = 0;
            int attempts = 0;

            Console.WriteLine("Я загадал число от 1 до 100. Попробуй угадать!");

            while (guess != secret)
            {
                Console.Write("Твой вариант: ");
                string input = Console.ReadLine();

                // Проверяем, ввёл ли пользователь число
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Пожалуйста, введи число!");
                    continue; // Если не число, продолжаем цикл
                }

                attempts++; // Считаем попытку

                if (guess < secret)
                    Console.WriteLine("bБольше!");
                else if (guess > secret)
                    Console.WriteLine("mМеньше!");
                else
                    Console.WriteLine($"Верно! Ты угадал за {attempts} попыток!");
            }
        }
    }
}
