using System;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;
namespace Main
{
    public class Point
    {
        public int X, Y;
        private static int ObjectCount = 0;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
            ObjectCount++;
        }
        public static int ObjctCount() => ObjectCount;
    }
    class Math
    {
        public const double PI = 3.14;

    }
internal class Program
    {
        static void Main(string[] args)
        {

            Point p1 = new Point(0, 0);
            Point p2 = new Point(5, 3);

            Console.WriteLine("Points created: " + Point.ObjctCount());

            double radius = 2;
            double area = Math.PI * radius * radius;

            Console.WriteLine("Area = " + area);


        }
    }

}
