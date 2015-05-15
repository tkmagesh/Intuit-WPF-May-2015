namespace ProductManagementApp
{
    public class NotCriteria<T> : IItemCriateria<T>
    {
        private readonly IItemCriateria<T> _criteria;

        public bool IsSatisfiedBy(T product)
        {
            return !_criteria.IsSatisfiedBy(product);
        }

        public NotCriteria(IItemCriateria<T> criteria)
        {
            _criteria = criteria;
        }
    }
}