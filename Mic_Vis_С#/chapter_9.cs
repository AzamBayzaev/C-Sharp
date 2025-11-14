using System;
namespace Main
{
    internal class Program
    {
        enum DaysOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        struct Len
        {
            private int Mm, Sm, M;
            public Len(int mm, int sm, int m)
            {
                Mm = mm;
                Sm = sm;
                M = m;
            }
            public void Info()
            {
                if (M > 0 && Sm > 0)
                {
                    Console.WriteLine($"{M}m = {M * 100}sm");
                    Console.WriteLine($"{Sm}sm = {Sm * 10}mm");
                }
                else{Console.WriteLine("error");}
            }

        }

        static void Main(string[] args)
        {
            DaysOfWeek currentDaysOfWeek;
            var a = Console.ReadLine();
            if (Enum.TryParse(a, true, out currentDaysOfWeek))
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

            var len1 = new Len(0, 0, 3);
            len1.Info();
        }
    }
}
