using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name :");
            var name = Console.ReadLine();
            var greeter = new Greeter(new TimeService());
            greeter.Name = name;
            greeter.Greet();
            Console.WriteLine(greeter.Message);
            Console.ReadLine();
        }
    }
}
