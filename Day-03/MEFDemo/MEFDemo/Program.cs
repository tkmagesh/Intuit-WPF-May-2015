using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MEFDemo
{
    
    class Program
    {
        [Import]
        public IDataProcessor Processor { get; set; }

        static void Main(string[] args)
        {
            var assemblyCatalog = new AssemblyCatalog(typeof (Program).Assembly);
            var container = new CompositionContainer(assemblyCatalog);
            var p = new Program();
            container.ComposeParts(p);
            p.Processor.Process();
            }
    }

    public interface IDataProcessor
    {
        void Process();
    }

    [Export(typeof(IDataProcessor))]
    public class DataProcessor : IDataProcessor
    {
        
        public IDataProvider DataProvider { get; set; }

        
        public IDataPersistor DataPersistor { get; set; }

        [ImportingConstructor]
        public DataProcessor(IDataProvider provider, IDataPersistor persistor)
        {
            DataProvider = provider;
            DataPersistor = persistor;
        }
        public void Process()
        {
            DataPersistor.Persist(DataProvider.GetData());
        }
    }

    public interface IDataPersistor
    {
        void Persist(string[] data);
    }

    [Export(typeof(IDataPersistor))]
    public class DataPersistor : IDataPersistor
    {
        public void Persist(string[] data)
        {
            new XElement("Employees", data.Select(s =>
            {
                var dataArr = s.Split(',');
                return new XElement("Employee", new XElement("Id", dataArr[0]), new XElement("FirstName", dataArr[1]),
                    new XElement("LastName", dataArr[2]), new XElement("Salary", dataArr[3]));
            })).Save("Employees.xml");
        }
    }

    public interface IDataProvider
    {
        string[] GetData();
    }

    [Export(typeof(IDataProvider))]
    public class DataProvider : IDataProvider
    {
        public string[] GetData()
        {
            return new[]
            {
                "1,Magesh,K,10000", "2,Suresh,P,20000"
            };
        }
    }
}
