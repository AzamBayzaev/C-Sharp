using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Main
{
    class Animals
    {
        public string Name;
        public Animals(string name) => Name = name;
        public virtual void MakeSound()
        {
            Console.Write($"{Name} says: ");
        }
    }
    class Cat : Animals
    {
        public Cat(string name) : base(name) {}
        public override void MakeSound()
        {
            base.MakeSound();
            Console.WriteLine("miy");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat("Tima");
            cat.MakeSound();

            IntExtensions.IsEven(5);

        }
    }

    static class IntExtensions
    {     
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}