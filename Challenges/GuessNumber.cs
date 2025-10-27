using System;

namespace Main
{
    internal class GuessNumber
    {

        public static void Run()
        {
            Random rnd = new Random();          
            int secret = rnd.Next(1, 101);     
            int guess = 0;
            int attempts = 0;

            Console.WriteLine("Я загадал число от 1 до 100. Попробуй угадать!");

            while (guess != secret)
            {
                Console.Write("Твой вариант: ");
                string input = Console.ReadLine();


                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Пожалуйста, введи число!");
                    continue; 
                }

                attempts++; 

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

