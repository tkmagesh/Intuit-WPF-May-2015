using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDemo.Contracts;

namespace DITransformer
{
    [Export(typeof(IProductDestination))]
    public class ProductSentenceDestination : IProductDestination
    {
        public void Save(List<Product> products)
        {
            var contents = products
                .Select(
                    p =>
                        string.Format("A {0} with {1} costs {2} are available with {3} units \n", p.Id, p.Name, p.Cost,
                            p.Units))
                .Aggregate(string.Empty, (result, line) => result + line);
            var sw = new StreamWriter("ProductsInfo.txt");
            sw.WriteLine(contents);
            sw.Close();
        }
    }
}
