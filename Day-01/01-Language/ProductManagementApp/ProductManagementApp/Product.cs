using System;
using System.Reflection;

namespace ProductManagementApp
{
    public class Product : IDisplayable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public decimal Cost { get; set; }
        public int Category { get; set; }

        public override string ToString()
        {
            /*return string.Format("Id = {0}\t Name = {1}\t Units = {2}\t Cost = {3}\t Category = {4}", this.Id, Name,
                Units, Cost, Category);*/
            return PrintUtils.Display(this);
        }
    }

    public interface IDisplayable{}

    public static class PrintUtils
    {
        public static string Display(this IDisplayable obj)
        {
            var objType = obj.GetType();
            PropertyInfo[] propertyInfos = objType.GetProperties();
            var result = "->\t";
            foreach (var propertyInfo in propertyInfos)
            {
                result += propertyInfo.Name + " = ";
                result += propertyInfo.GetValue(obj, null);
                result += "\t";
            }
            return result;
        }
    }
}