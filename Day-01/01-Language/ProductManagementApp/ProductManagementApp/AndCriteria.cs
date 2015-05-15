namespace ProductManagementApp
{
    public class AndCriteria<T> : IItemCriateria<T>
    {
        private readonly IItemCriateria<T> _first;
        private readonly IItemCriateria<T> _second;

        public AndCriteria(IItemCriateria<T> first, IItemCriateria<T> second)
        {
            _first = first;
            _second = second;
        }

        public bool IsSatisfiedBy(T product)
        {
            return _first.IsSatisfiedBy(product) && _second.IsSatisfiedBy(product);
        }
    }
}