using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var products = new ProductsCollection();
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
            Console.ReadLine();
            //Create an instance of ProductsCollection
            //Add a few products to the collection
            //Iterate through the collection and print them

        }
    }

    class ProductsCollection : IEnumerable, IEnumerator
    {
         private ArrayList _list = new ArrayList();

        public void Add(Product product )
        {
            _list.Add(product);
        }

        public Product this[int index]
        {
            get { return (Product) _list[index]; }
        }
        public Product Get(int index)
        {
            return (Product) _list[index];
        }

        public int Count
        {
            get { return _list.Count; }
        }
        //Add
        //Removing
        //Get a product by index
        //Count
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        private int _index = -1;
        public bool MoveNext()
        {
            ++_index;
            if (_index < _list.Count)
            {
                return true;
            } else 
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            _index = -1;
        }

        public object Current {
            get { return _list[_index]; }
        }

        public void Sort(IProductComparer comparer)
        {
            
            for(var i=0; i<_list.Count-1; i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Product) _list[i];
                    var right = (Product) _list[j];

                    if (comparer.Compare(left, right ) > 0)
                    {
                        _list[i] = _list[j];
                        _list[j] = left;
                    }
                }
        }
    }

    public interface IProductComparer
    {
        int Compare(Product p1, Product p2);
    }

    public class ProductComparerById : IProductComparer
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Id < p2.Id) return -1;
            if (p1.Id == p2.Id) return 0;
            return 1;
        }
    }

    public class ProductComparerByCost : IProductComparer
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Cost < p2.Cost) return -1;
            if (p1.Cost == p2.Cost) return 0;
            return 1;
        }
    }

    public class Product
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
