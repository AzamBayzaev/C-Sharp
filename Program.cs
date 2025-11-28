using System;
class Program
{
    static void Main()
    {
        var list = new List<int>() {4,6,8,1,-5,6,1,-6,9};
        for(int i  = 0; i < list.Count; i+=3) 
        {
            equation(list[i], list[i + 1], list[i + 2]);
        }
    }
    static void equation(int a, int b, int c)
    {
        int D = (b * b) - 4 * a * c;
        if (D > 0) 
        { 
            Console.WriteLine($"Your equation: {a}^2+{b}x+{c}=0");
            Console.WriteLine($"your Discromenant: {D}");
            Console.WriteLine($"first root {(-b + Math.Sqrt(D)) / 2 * a}");
            Console.WriteLine($"second root {(-b - Math.Sqrt(D)) / 2 * a}"); 
        }
        if (D < 0) Console.WriteLine($"not find a root D = {D}");
        if (D == 0)
        {
            Console.WriteLine($"Your equation: {a}^2+{b}x+{c}=0");
            Console.WriteLine($"your Discromenant: {D}");
            Console.WriteLine($"find one root {-(b / 2 * a)}");
        }
    }
}
