using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee(100) {Name = "Magesh", Salary = 20000};
            employee.Name = "Magesh";
            Console.WriteLine("Employee Id = {0}, Name = {1}", employee.Id, employee.Name);
            employee.Display();
            ICricketer cricketer = (ICricketer) employee;
            
            Console.ReadLine();
        }
    }

    abstract class EmployeeBase
    {
        public int Id { get; set; }

        public virtual void Display(){}
    }

    class Employee : EmployeeBase, ICricketer
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public Employee(int id)
        {
            Id = id;
        }

        

        public override void Display()
        {
            Console.WriteLine("Id = {0}, Name = {1}, Salary = {2}", Id, Name, Salary);
        }

        public string Ball { get; set; }

        void ICricketer.Bowl()
        {
            throw new NotImplementedException();
        }

        public void Bat()
        {
            throw new NotImplementedException();
        }

        public void Field()
        {
            throw new NotImplementedException();
        }
    }

    public interface ICricketer
    {
        string Ball { get; set; }
        void Bowl();
        void Bat();
        void Field();
    }
}
