using System;
using static StyleWeaver.API;

namespace StyleWeaver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            API apiContainer = new API();
            
            var data = API.GetFileDataAsync<object>().GetAwaiter().GetResult();
            Console.ReadLine(); 
        }

    }
}
