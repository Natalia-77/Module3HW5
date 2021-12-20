using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Module3HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var text = TotalText().Result;
            Console.WriteLine(text);
        }

        public static async Task<string> ReadHello() => await File.ReadAllTextAsync("Hello.txt");
        public static async Task<string> ReadWorld() => await File.ReadAllTextAsync("World.txt");

        public static async Task<string> TotalText()
        {
            var list = new List<Task<string>>();
            list.Add(ReadHello());
            list.Add(ReadWorld());
            var text = string.Join(" ", await Task.WhenAll(list));
            return text;
        }
    }
}
