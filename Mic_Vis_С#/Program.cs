using System;
namespace Main
{
    interface IArray
    {
        double GetArray();
    }
    abstract class Shape
    {
        public abstract void GetInfo();
    }
    class Rectangle : Shape, IArray
    {
        private int Length;
        private int Width;
        public Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }
        public double GetArray() => Length * Width;
        public override void GetInfo() => Console.WriteLine($"Length: {Length}\nWidth: {Width}");
    }
    sealed class Circle : Shape, IArray
    {
        private int Radius;
        public Circle(int radius) => Radius = radius;
        public double GetArray() => Math.PI * Math.Pow(Radius, 2);
        public override void GetInfo() => Console.WriteLine($"Radius: {Radius}");
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(5, 3);
            rect.GetInfo();
            Console.WriteLine($"Rectangle area: {rect.GetArray()}");

            Circle circle = new Circle(4);
            circle.GetInfo();
            Console.WriteLine($"Circle area: {circle.GetArray()}");

        }
    }
}
