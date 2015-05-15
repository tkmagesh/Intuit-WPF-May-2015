using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            products.Sort(( p1,  p2) => Math.Sign(p1.Units - p2.Units));
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

            var category1Products = products.Filter(new Category1ProductCriteria());
            foreach (var product in category1Products)
            {
                Console.WriteLine(product);
            }
            

            Console.WriteLine();
            Console.WriteLine("All category1 costly products");
            var category1CostlyProducts =
                products.Filter(new AndCriteria(new CosltyProductCriteria(), new Category1ProductCriteria()));
            foreach(var product in category1CostlyProducts)
                Console.WriteLine(product);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Either category1 or costly products");
            var category1OrCostlyProducts =
                products.Filter(new OrCriteria(new CosltyProductCriteria(), new Category1ProductCriteria()));
            foreach (var product in category1OrCostlyProducts)
                Console.WriteLine(product);

            Console.WriteLine();
            Console.WriteLine("All affordable product [NOT costly products]");
            var affordableProducts =
                products.Filter(new NotCriteria(new CosltyProductCriteria()));
            foreach (var product in affordableProducts)
                Console.WriteLine(product);

            Console.ReadLine();
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

        public void Sort(ProductCompareDelegate compareProduct)
        {

            for (var i = 0; i < _list.Count - 1; i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Product)_list[i];
                    var right = (Product)_list[j];

                    if (compareProduct(left, right) > 0)
                    {
                        _list[i] = _list[j];
                        _list[j] = left;
                    }
                }
        }

        public ProductsCollection Filter(IProductCriteria productCriteria)
        {
            var result = new ProductsCollection();
            foreach (var item in _list)
            {
                var product = (Product)item;
                if (productCriteria.IsSatisfiedBy(product))
                    result.Add(product);
            }
            return result;
        }

        public ProductsCollection FilterByCost()
        {
            var result = new ProductsCollection();
            foreach (var item in _list)
            {
                var product = (Product) item;
                if (product.Cost > 50)
                    result.Add(product);
            }
            return result;
        }

        public ProductsCollection FilterByCategory()
        {
            var result = new ProductsCollection();
            foreach (var item in _list)
            {
                var product = (Product)item;
                if (product.Category == 1)
                    result.Add(product);
            }
            return result;
        }
    }

    public interface IProductCriteria
    {
        bool IsSatisfiedBy(Product product);
    }

    public class CosltyProductCriteria : IProductCriteria
    {
        public bool IsSatisfiedBy(Product product)
        {
            return product.Cost > 50;
        }
    }

    public class Category1ProductCriteria : IProductCriteria
    {
        public bool IsSatisfiedBy(Product product)
        {
            return product.Category == 1;
        }
    }

    public class NotCriteria : IProductCriteria
    {
        private readonly IProductCriteria _criteria;

        public bool IsSatisfiedBy(Product product)
        {
            return !_criteria.IsSatisfiedBy(product);
        }

        public NotCriteria(IProductCriteria criteria)
        {
            _criteria = criteria;
        }
    }

    public class  OrCriteria : IProductCriteria
    {
        private readonly IProductCriteria _first;
        private readonly IProductCriteria _second;

        public bool IsSatisfiedBy(Product product)
        {
            return _first.IsSatisfiedBy(product) || _second.IsSatisfiedBy(product);
        }

        public OrCriteria(IProductCriteria first, IProductCriteria second)
        {
            _first = first;
            _second = second;
        }
    }

    public  class AndCriteria : IProductCriteria
    {
        private readonly IProductCriteria _first;
        private readonly IProductCriteria _second;

        public AndCriteria(IProductCriteria first, IProductCriteria second)
        {
            _first = first;
            _second = second;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return _first.IsSatisfiedBy(product) && _second.IsSatisfiedBy(product);
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

    public delegate int ProductCompareDelegate(Product p1, Product p2);

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
