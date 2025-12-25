using System;
class Program
{
    static void Main()
    {
        Perc p1 = new Perc(40);
        Perc p2 = new Perc(35);
        Perc p3 = (Perc)20;      

        Console.WriteLine($"p1 = {p1}"); 
        Console.WriteLine($"p2 = {p2}");
        Console.WriteLine($"p3 = {p3}"); 
      
        Perc sum2 = p1 + 10;          
        Perc diff1 = p1 - p2;         
        
        Console.WriteLine($"sum2 = {sum2}");
        Console.WriteLine($"diff1 = {diff1}");

        Console.WriteLine($"p2 <= p1: {p2 <= p1}");
        Console.WriteLine($"p1 == p1: {p1 == p1}");
        Console.WriteLine($"p1 != p2: {p1 != p2}");

        byte b1 = p1;               
        Perc p4 = (Perc)50;          
        Console.WriteLine($"byte from p1 = {b1}");
        Console.WriteLine($"p4 = {p4}");
    }
}
readonly struct Perc : IEquatable<Perc>, IComparable<Perc>
{
    private readonly byte _byte;
    public byte Value => _byte;
    public Perc(byte bt){if (bt > 100) throw new ArgumentOutOfRangeException("error"); _byte = bt;}
    public static Perc operator +(Perc a, Perc b)
    {
        int sum = a._byte + b._byte;
        if (sum > 100) throw new Exception("error");
        return new Perc((byte)sum);
    }
    public static Perc operator -(Perc a, Perc b)
    {
        int sum = a._byte - b._byte;
        if (sum < 0) throw new Exception("error");
        return new Perc((byte)sum);
    }
    public static Perc operator +(Perc a, byte b)
    {
        int sum = a._byte + b;
        if (sum > 100) throw new Exception("error");
        return new Perc((byte)sum);
    }
    public static Perc operator -(Perc a, byte b)
    {
        int sum = a._byte - b;
        if (sum < 0) throw new Exception("error");
        return new Perc((byte)sum);
    }
    public bool Equals(Perc other) => _byte.Equals(other._byte);
    public int CompareTo(Perc other) => _byte.CompareTo(other._byte);
    public static bool operator ==(Perc a, Perc b) => a._byte.Equals(b._byte);
    public static bool operator !=(Perc a, Perc b) => !a._byte.Equals(b._byte);
    public static bool operator >=(Perc a, Perc b) => a._byte >= b._byte;
    public static bool operator <=(Perc a, Perc b) => a._byte <= b._byte;
    public static bool operator <(Perc a, Perc b) => a._byte < b._byte;
    public static bool operator >(Perc a, Perc b) => a._byte > b._byte;
    public static explicit operator Perc(byte a) => new Perc(a);
    public static implicit operator byte(Perc a) => a._byte;
    public override string ToString() => $"{_byte}%";
}
