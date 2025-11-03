using System;
namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter number A: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter number B: ");
                int b = Convert.ToInt32(Console.ReadLine());
                checked
                {
                    int c = a * b;
                    Console.WriteLine($"Result: {c}");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error Overflow");
            }
        }
    }
}
