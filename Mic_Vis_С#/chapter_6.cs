using System;
namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {          
            try
            {
                Console.WriteLine("Попытка преобразовать 'abc' в число...");
                int num = int.Parse("abc");
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"Перехвачено FormatException: {fEx.Message}");
            }
         


            try
            {
                int max = int.MaxValue;
                checked
                {
                    max++; 
                }
            }
            catch (OverflowException oEx)
            {
                Console.WriteLine($"Перехвачено OverflowException: {oEx.Message}");
            }

          

            try
            {
                int age = -5;
                if (age < 0)
                    throw new ArgumentOutOfRangeException(nameof(age), "Возраст не может быть отрицательным");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Перехвачено пользовательское исключение: {ex.Message}");
            }      
            


            try
            {
                int[] arr = new int[2];
                Console.WriteLine(arr[5]); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Перехвачено общее исключение: {ex.Message}");
            }
            finally
            {
                
                Console.WriteLine("Блок finally: этот код выполнится всегда, независимо от исключений.");
            }
        }
    }
}
