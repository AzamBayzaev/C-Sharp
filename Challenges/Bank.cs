using System;
using System.Collections.Generic;
using System.Text;
public class BankClient
{
    public string Name {get;}
    public decimal PriceOfSupport { get;}
    public BankClient(string name, decimal price)
    {
        Name = name;
        PriceOfSupport = price;
    }
}

interface IQueuable
{
    public string Check { get; set; }
}
public class BankQueue
{
    public int QueueR { get; }
    public int MaxLength { get; }
    private Queue<BankClient> queue;
    public BankQueue(int r, int maxLength)
    {
        QueueR = r;
        MaxLength = maxLength;
        queue = new Queue<BankClient>();
    }
    public bool Addqueue(BankClient client)
    {
        if (queue.Count >= MaxLength)
        {
            Console.WriteLine($"Очередь {QueueR} полная. Клиент {client.Name} не может быть добавлен.");
            return false;
        }
        queue.Enqueue(client);
        Console.WriteLine($"Клиент {client.Name} добавлен в очередь {QueueR}.");
        return true;
    }
    public BankClient Serve()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine($"Очередь {QueueR} пуста.");
            return null;
        }
        BankClient client = queue.Dequeue();
        Console.WriteLine($"Клиент {client.Name} обслужен в очереди {QueueR}. Оплата: ${client.PriceOfSupport}");
        return client;
    }
    public void ShowQueue()
    {
        Console.WriteLine($"Очередь {QueueR}: {string.Join(", ", queue.Select(c => $"{c.Name} (${c.PriceOfSupport})"))}");
    }
}
public class BankEmployee
{
    public string Name { get; }
    public BankQueue RQueue { get; }
    public BankEmployee(string name, int queur, int maxQueueLength)
    {
        Name = name;
        RQueue = new BankQueue(queur, maxQueueLength);
    }
    public void AddClient(BankClient client)
    {
        RQueue.Addqueue(client);
    }
    public void ServeClient()
    {
        RQueue.Serve();
    }
}
class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var employee1 = new BankEmployee("Иван", 1, 3);
        var employee2 = new BankEmployee("Мария", 2, 2);

        var client1 = new BankClient("Алексей", 50);
        var client2 = new BankClient("Ольга", 75);
        var client3 = new BankClient("Сергей", 100);
        var client4 = new BankClient("Елена", 60);

        employee1.AddClient(client1);
        employee1.AddClient(client2);
        employee1.AddClient(client3);
        employee1.AddClient(client4);

        employee2.AddClient(client4);
        employee2.AddClient(client1);

        employee1.RQueue.ShowQueue();
        employee2.RQueue.ShowQueue();

        employee1.ServeClient();
        employee1.ServeClient();
        employee1.RQueue.ShowQueue();

        employee2.ServeClient();
        employee2.RQueue.ShowQueue();
    }

}
