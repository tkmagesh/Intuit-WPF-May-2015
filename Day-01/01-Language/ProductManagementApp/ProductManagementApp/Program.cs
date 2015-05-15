using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{
    public class Employee : IDisplayable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var emp = new Employee() {Id = 100, Name = "Magesh", Salary = 10000};
            Console.WriteLine(emp.Display());
            
            Console.ReadLine();

            var products = new MyCollection<Product>();
            products.Add( new Product(){Id = 1, Name = "Pen", Units = 10, Cost = 25, Category = 1});
            products.Add(new Product() { Id = 2, Name = "Hen", Units = 60, Cost = 70, Category = 2 });
            products.Add(new Product() { Id = 5, Name = "Ten", Units = 20, Cost = 40, Category = 1 });
            products.Add(new Product() { Id = 9, Name = "Den", Units = 70, Cost = 35, Category = 2 });
            products.Add(new Product() { Id = 4, Name = "Zen", Units = 50, Cost = 60, Category = 1 });

            Console.WriteLine("Default List");
            Console.WriteLine("============================================");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
            Console.WriteLine("Default Sort");
            Console.WriteLine("============================================");
            products.Sort(new ProductComparerById());
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
            Console.WriteLine("Sort by Cost [usng comparer]");
            Console.WriteLine("============================================");
            products.Sort(new ProductComparerByCost());
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
            Console.WriteLine("Sort by Units [usng delegate]");
            Console.WriteLine("============================================");
            //products.Sort(Program.CompareProductByUnits);
            /*products.Sort(delegate (Product p1, Product p2)
            {
                if (p1.Units < p2.Units) return -1;
                if (p1.Units == p2.Units) return 0;
                return 1;
            });*/
            products.Sort((( p1,  p2) => Math.Sign((int) (p1.Units - p2.Units))));
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            


            Console.WriteLine();
            Console.WriteLine("Filter by cost ");
            Console.WriteLine("============================================");
            
            var costlyProducts = products.Filter(new CosltyProductCriteria());
            foreach (var product in costlyProducts)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
            Console.WriteLine("Filter by Category ");
            Console.WriteLine("============================================");

            //var category1Products = products.Filter(new Category1ProductCriteria());
            var category1Products = products.Filter(new Category1ProductCriteria());
            foreach (var product in category1Products)
            {
                Console.WriteLine(product);
            }
            

            Console.WriteLine();
            Console.WriteLine("All category1 costly products");
            var category1CostlyProducts =
                //products.Filter(new AndCriteria<Product>(new CosltyProductCriteria(), new Category1ProductCriteria()));
                products.Filter(new AndCriteria<Product>(new CosltyProductCriteria(), new Category1ProductCriteria()));
            foreach(var product in category1CostlyProducts)
                Console.WriteLine(product);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Either category1 or costly products");
            var category1OrCostlyProducts =
                products.Filter(new OrCriteria<Product>(new CosltyProductCriteria(), new Category1ProductCriteria()));
            foreach (var product in category1OrCostlyProducts)
                Console.WriteLine(product);

            Console.WriteLine();
            Console.WriteLine("All affordable product [NOT costly products]");
            var affordableProducts =
                products.Filter(new NotCriteria<Product>(new CosltyProductCriteria()));
            foreach (var product in affordableProducts)
                Console.WriteLine(product);

            Console.ReadLine();
        }

        
    }
}
