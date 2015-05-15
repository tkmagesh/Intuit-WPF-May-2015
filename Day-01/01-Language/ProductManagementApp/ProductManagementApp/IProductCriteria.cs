namespace ProductManagementApp
{
    /*public interface IProductCriteria
    {
        bool IsSatisfiedBy(Product product);
    }*/

    public interface IItemCriateria<T>
    {
        bool IsSatisfiedBy(T item);
    }
}