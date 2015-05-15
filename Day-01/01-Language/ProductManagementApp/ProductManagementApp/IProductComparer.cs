namespace ProductManagementApp
{
   /* public interface IProductComparer
    {
        int Compare(Product p1, Product p2);
    }*/

    public interface IItemComparer<T>
    {
        int Compare(T p1, T p2);
    }
}