using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = new int[] {10, 20, 30, 40};
            var total = numbers.Aggregate(0, (result, number) => result + number);
            Console.WriteLine(total);
            Console.ReadLine();


            var products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "Pen", Units = 10, Cost = 25, Category = 1 });
            products.Add(new Product() { Id = 2, Name = "Hen", Units = 60, Cost = 70, Category = 2 });
            products.Add(new Product() { Id = 5, Name = "Ten", Units = 20, Cost = 40, Category = 1 });
            products.Add(new Product() { Id = 9, Name = "Den", Units = 70, Cost = 35, Category = 2 });
            products.Add(new Product() { Id = 4, Name = "Zen", Units = 50, Cost = 60, Category = 1 });

            products
                .Where(p => p.Cost > 50)
                .Select(p => p.Display())
                .ForEach( Console.WriteLine);

            var category1ProductValue = products
                .Where(p => p.Category == 1)
                .Select(p => p.Units * p.Cost)
                .Sum();


            Console.WriteLine(category1ProductValue);

            Console.ReadLine();
        }
    }

    public static class MyUtils
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }
    }
}
