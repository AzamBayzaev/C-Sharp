using System;
using System.Collections.Generic;
using System.Linq;
interface IClient
{
    string Name { get; }
    decimal PriceOfSupport { get; }
    int? TicketId { get; set; }
}
class _Queue<T> where T : IClient
{
    private Queue<T> _Que { get; } = new Queue<T>();
    private int _nextTicket = 1;
    public int Id { get; }
    public int MaxLength { get; }
    public _Queue(int id, int maxLength)
    {
        Id = id;
        MaxLength = maxLength;
    }
    public void Add(T client)
    {
        if (_Que.Count >= MaxLength) throw new Exception("Очеред переполнен");
        client.TicketId = _nextTicket++;
        _Que.Enqueue(client);
        Console.WriteLine($"{client.Name} добавлен в очеред {Id} ({typeof(T).Name}), чек -{client.TicketId}");
    }
    public void Serve()
    {
        if (_Que.Count == 0) {Console.WriteLine($"Очердь {Id} пус"); return;}
        var client = _Que.Dequeue();
        Console.WriteLine($"{client.Name} обслужн, платит {client.PriceOfSupport}, чек -{client.TicketId} онулирован");
        client.TicketId = null;
    }
    public void Info()
    {
        if (_Que.Count == 0){Console.WriteLine($"Очередь {Id} ({typeof(T).Name}) пуст");return;}
        Console.WriteLine($"Очередь {Id} ({typeof(T).Name}), клиентов в очереди: {_Que.Count}");
        Console.WriteLine("В очереди: " + string.Join(", ", _Que.Select(c => $"{c.Name} (чек -{c.TicketId})")));
    }
}
class Hospital : IClient
{
    public string Name { get; }
    public decimal PriceOfSupport { get; }
    public int? TicketId { get; set; }
    public Hospital(string name, decimal price) { Name = name; PriceOfSupport = price; }
}
class BaberShop : IClient
{
    public string Name { get; }
    public decimal PriceOfSupport { get; }
    public int? TicketId { get; set; }
    public BaberShop(string name, decimal price){Name = name;PriceOfSupport = price;}
}
class Bank : IClient
{
    public string Name { get; }
    public decimal PriceOfSupport { get; }
    public int? TicketId { get; set; }
    public Bank(string name, decimal price){Name = name; PriceOfSupport = price;}
}
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var _1queH = new _Queue<Hospital>(1, 3);
        var _1queBb = new _Queue<BaberShop>(2, 4);
        var _1queB = new _Queue<Bank>(3, 5);

        _1queH.Add(new Hospital("Абду", 150));
        _1queH.Add(new Hospital("Хусен", 100));
        _1queH.Add(new Hospital("Ануш", 80));

        _1queBb.Add(new BaberShop("Азам", 20));
        _1queBb.Add(new BaberShop("Азамат", 10));
        _1queBb.Add(new BaberShop("Али", 30));

        _1queB.Add(new Bank("Фаррух", 50));
        _1queB.Add(new Bank("Фируз", 30));
        _1queB.Add(new Bank("Саттор", 80));

        _1queH.Serve();
        _1queBb.Serve();
        _1queB.Serve();

        _1queH.Info();
        _1queBb.Info();
        _1queB.Info();
    }
}
