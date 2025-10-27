using System;

namespace Main
{
    internal class RockPaperScissors
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            string[] options = { "камень", "ножницы", "бумага" };
            Random rnd = new Random();

            Console.WriteLine("Давай сыграем в Камень, Ножницы, Бумага!");
            Console.WriteLine("Введите 'камень', 'ножницы' или 'бумага' (для выхода — 'выход').");

            while (true)
            {
                Console.Write("Ваш ход: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Пожалуйста, введи вариант!");
                    continue;
                }

                // Убираем пробелы и приводим к нижнему регистру
                string player = input.Trim().ToLower();

                if (player == "выход") break;

                // Проверка на корректный ввод
                if (Array.IndexOf(options, player) == -1)
                {
                    Console.WriteLine("Неверный ввод! Попробуй ещё раз.");
                    continue;
                }

                // Выбор компьютера
                string computer = options[rnd.Next(0, options.Length)];
                Console.WriteLine($"Компьютер выбрал: {computer}");

                // Определяем победителя
                if (player == computer)
                    Console.WriteLine("Ничья!");
                else if ((player == "камень" && computer == "ножницы") ||
                         (player == "ножницы" && computer == "бумага") ||
                         (player == "бумага" && computer == "камень"))
                    Console.WriteLine("Ты выиграл! 🎉");
                else
                    Console.WriteLine("Компьютер выиграл! 💻");

                Console.WriteLine();
            }

            Console.WriteLine("Игра закончена. Спасибо за игру!");
        }
    }
}
