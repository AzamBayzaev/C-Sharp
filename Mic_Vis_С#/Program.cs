using System;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] a = new int[rnd.Next(1,6)];
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("Enter th Number: ");
                a[i]=Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine(string.Join(",",a));
            Console.WriteLine($"Length a = {a.Length}");

            var b = a[rnd.Next(a.Length)];
            foreach (int i in a)
            {
                if (b == i)
                {
                    Console.WriteLine($"b = {i}");
                }
            }

            int[,] matrix = new int[rnd.Next(1,5), rnd.Next(1,5)];

            int[][] items;
            items = new int[4][];
            items[0] = new int[3];
            items[1] = new int[10];
            items[2] = new int[40];
            items[3] = new int[25];
        }
    }
}