using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace MyAssembliesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeService = new TimeService();
            Console.WriteLine(timeService.GetCurrentTime());
            Console.ReadLine();
        }
    }
}
