namespace ProductManagementApp
{
    public class  OrCriteria<T> : IItemCriateria<T>
    {
        private readonly IItemCriateria<T> _first;
        private readonly IItemCriateria<T> _second;

        public bool IsSatisfiedBy(T product)
        {
            return _first.IsSatisfiedBy(product) || _second.IsSatisfiedBy(product);
        }

        public OrCriteria(IItemCriateria<T> first, IItemCriateria<T> second)
        {
            _first = first;
            _second = second;
        }
    }
}