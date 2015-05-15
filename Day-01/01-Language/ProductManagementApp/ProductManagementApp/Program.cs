using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product(){Id = 1, Name = "Pen", Units = 10, Cost = 25, Category = 1};
            Console.WriteLine(product);
            Console.ReadLine();

            //Create an instance of ProductsCollection
            //Add a few products to the collection
            //Iterate through the collection and print them

        }
    }

    class ProductsCollection
    {
         private ArrayList _list = new ArrayList();

        //Add
        //Removing
        //Get a product by index
        //Count
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public decimal Cost { get; set; }
        public int Category { get; set; }

        public override string ToString()
        {
            return string.Format("Id = {0}\t Name = {1}\t Units = {2}\t Cost = {3}\t Category = {4}", this.Id, Name,
                Units, Cost, Category);
        }
    }
}
