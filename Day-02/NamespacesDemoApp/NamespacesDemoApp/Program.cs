using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespacesDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new NamespacesDemo.Domain.Customer();
            var product = new NamespacesDemo.Domain.Product();
            var employee = new NamespacesDemo.Domain.Employee();
        }
    }
}
