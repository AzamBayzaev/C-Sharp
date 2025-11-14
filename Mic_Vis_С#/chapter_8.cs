using System;
namespace Main
{
    class Circle
    {
        int Radius;
        public Circle(int radius) => Radius = radius;
    }
    class Animal { }
    class Dog : Animal
    {
        public void Bark() => Console.WriteLine("Woof");
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            void AddOne(ref int x)
            {
                x = x + 1; 
            }

            int a = 5;
            AddOne(ref a);
            Console.WriteLine(a); 

            double Pi = 3.14;
            var Copy = Pi;

            Circle c1 = new Circle(42);
            Circle refc = c1;

            void GetValues(out int x)
            {
                x = 10;    
            }

            int b;         
            GetValues(out b);
            Console.WriteLine(a);
            Console.WriteLine(b);

            object o = 100;
            int one = (int)o;

            Animal a1 = new Dog(); 

            if (a1 is Dog)          
            {
                Dog d = (Dog)a1;   
                d.Bark();         
            }
        }
    }
}
