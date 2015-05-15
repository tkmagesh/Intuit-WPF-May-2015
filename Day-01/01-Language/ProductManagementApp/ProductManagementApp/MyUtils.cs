using System;

namespace ProductManagementApp
{
    public static class MyUtils
    {
        public static void Sort<T>(this MyCollection<T> list, IItemComparer<T> comparer)
        {

            for (var i = 0; i < list.Count - 1; i++)
                for (var j = i + 1; j < list.Count; j++)
                {
                    var left = (T)list[i];
                    var right = (T)list[j];

                    if (comparer.Compare(left, right) > 0)
                    {
                        list[i] = list[j];
                        list[j] = left;
                    }
                }
        }

        //public static void Sort<T>(this MyCollection<T> list, ItemCompareDelegate<T> compareProduct)
        public static void Sort<T>(this MyCollection<T> list, Func<T,T,int> compareProduct)
        {

            for (var i = 0; i < list.Count - 1; i++)
                for (var j = i + 1; j < list.Count; j++)
                {
                    var left = (T)list[i];
                    var right = (T)list[j];

                    if (compareProduct(left, right) > 0)
                    {
                        list[i] = list[j];
                        list[j] = left;
                    }
                }
        }

        public static MyCollection<T> Filter<T>(this MyCollection<T> list, IItemCriateria<T> itemCriateria)
        {
            var result = new MyCollection<T>();
            foreach (var item in list)
            {
                var product = (T)item;
                if (itemCriateria.IsSatisfiedBy(product))
                    result.Add(product);
            }
            return result;
        }

        public static MyCollection<T> Filter<T>(this MyCollection<T> list, Predicate<T> itemCriateria)
        {
            var result = new MyCollection<T>();
            foreach (var item in list)
            {
                var product = (T)item;
                if (itemCriateria(product))
                    result.Add(product);
            }
            return result;
        }
    }

    public delegate bool ItemCriateriaDelegate<T>(T item);

}