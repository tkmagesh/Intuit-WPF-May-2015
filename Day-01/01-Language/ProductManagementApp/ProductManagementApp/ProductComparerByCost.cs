namespace ProductManagementApp
{
    public class ProductComparerByCost : IItemComparer<Product>
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Cost < p2.Cost) return -1;
            if (p1.Cost == p2.Cost) return 0;
            return 1;
        }
    }
}