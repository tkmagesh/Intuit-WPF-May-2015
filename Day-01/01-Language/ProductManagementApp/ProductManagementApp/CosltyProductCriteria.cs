namespace ProductManagementApp
{
    public class CosltyProductCriteria : IItemCriateria<Product>
    {
        public bool IsSatisfiedBy(Product product)
        {
            return product.Cost > 50;
        }
    }
}