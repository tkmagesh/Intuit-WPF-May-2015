namespace ProductManagementApp
{
    public class ProductComparerById : IItemComparer<Product>
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Id < p2.Id) return -1;
            if (p1.Id == p2.Id) return 0;
            return 1;
        }
    }
}