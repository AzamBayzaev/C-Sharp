using System;
using System.Drawing;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            try
            {
                int number = int.Parse(userInput);
                Console.WriteLine($"You entered a number: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number entered. Please enter a valid number.");
            }

        }
    }
}