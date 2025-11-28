using System;
using System.Diagnostics;
using System.Text;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var products = new Dictionary<string, int>();

        var bools = true;
        while (bools)
        {
            Console.WriteLine($"a) Показать список продуктов");
            Console.WriteLine($"b) Добавить новый продукт");
            Console.WriteLine($"с) Продать продукт");
            Console.WriteLine($"d) закрыть");

            var select = Console.ReadLine();

            if (select == "a")
            {
                foreach (var i in products)
                {
                    Console.WriteLine($"Name: {i.Key}, Quantity: {i.Value}");
                }
            }
            if (select == "b")
            {
                Console.Write($"Вводите имя: ");
                var _name = Console.ReadLine();

                Console.Write($"Вводите количество: ");
                var _quantity = Convert.ToInt32(Console.ReadLine());

                if (!string.IsNullOrWhiteSpace(_name))
                {
                        if (products.ContainsKey(_name))
                        {
                            products[_name] += _quantity;
                        }
                        else
                        {
                            products.Add(_name, _quantity);
                        }                
                }
            }
            if (select == "c")
            {
                Console.Write($"Вводите имя: ");
                var _name = Console.ReadLine();

                Console.Write($"Вводите количество: ");
                var _quantity = Convert.ToInt32(Console.ReadLine());
                if (!string.IsNullOrWhiteSpace(_name) && products.ContainsKey(_name))
                {
                    products[_name] -= _quantity;
                }
                else
                {
                    throw new Exception("продукт не найденно");
                }
            }
            if (select == "d") bools = false;
        }
    }
}
