using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        using (var Fs = new FileStream("File.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite))
        {
            byte[] buffer = new byte[100];
            var ReadFs = Fs.Read(buffer, 0, 3);
            Console.WriteLine(buffer);
        }
    }
}
