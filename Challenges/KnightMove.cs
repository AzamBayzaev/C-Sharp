using System;

namespace Main
{
    internal class KnightMove
    {
        public static bool IsKnightMove(string from, string to)
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to) || from.Length < 2 || to.Length < 2)
                return false;

            int x1 = from[0] - 'a', y1 = from[1] - '1';
            int x2 = to[0] - 'a', y2 = to[1] - '1';

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
        }
        public static void Run()
        {
            Console.Write("Откуда: ");
            string from = Console.ReadLine();
            Console.Write("Куда: ");
            string to = Console.ReadLine();

            if (IsKnightMove(from, to))
                Console.WriteLine("Ход коня верный");
            else
                Console.WriteLine("Так конь не ходит");
        }
    }
}
