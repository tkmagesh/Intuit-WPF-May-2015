using System;
using System.Linq;
using System.Reflection;

namespace LINQDemo
{
    public class Product : IDisplayable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public decimal Cost { get; set; }

        [IgnoreDisplay]
        public int Category { get; set; }

       
    }

    public interface IDisplayable{}

    public static class PrintUtils
    {
        public static string Display(this IDisplayable obj)
        {
            return obj
                .GetType()
                .GetProperties()
                .Where(propertyInfo => !propertyInfo.GetCustomAttributes<IgnoreDisplayAttribute>().Any())
                .Select(propertyInfo => propertyInfo.Name + " = " + propertyInfo.GetValue(obj, null))
                .Aggregate(string.Empty, (prevResult, s) => prevResult + s + "\t");
        }
    }

    public class IgnoreDisplayAttribute : Attribute
    {
        
    }
}