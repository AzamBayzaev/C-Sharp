using System;
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

            Method(1,2,3,4,5,6);

            void Method2(params object[] paramList)
            {
                foreach (var item in paramList)
                {
                    Console.WriteLine($"Type: {item.GetType()}, Value: {item}");
                }
            }
            
            Method2(5, "Hello", 3.14, true, 'A');
        }
    }
}
