using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void Method(params int[] a)
            {
                foreach (int i in a)
                {
                    if (i % 2 == 0)
                        Console.WriteLine($"Even {i}");
                    else
                        Console.WriteLine($"Odd {i}");
                }
            }

            Method(2,3,4,6,8,9);

            void Method2(params object[] paramList)
            {
                Console.WriteLine(paramList.ToString());

            }
            Method2(2, 3, 4, 6, 8, 9);
        }
    }
}