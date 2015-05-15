namespace ProductManagementApp
{
    public class Category1ProductCriteria : IItemCriateria<Product>
    {
        public bool IsSatisfiedBy(Product product)
        {
            return product.Category == 1;
        }
    }
}