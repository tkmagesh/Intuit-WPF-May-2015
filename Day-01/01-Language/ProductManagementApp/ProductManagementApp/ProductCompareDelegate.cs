namespace ProductManagementApp
{
    //public delegate int ProductCompareDelegate(Product p1, Product p2);

    public delegate int ItemCompareDelegate<T>(T p1, T p2);
}