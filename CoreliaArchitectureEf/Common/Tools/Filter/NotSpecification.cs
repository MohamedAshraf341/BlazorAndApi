namespace Common.Tools.Filter
{
    public class NotSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> spec;

        public NotSpecification(ISpecification<T> spec)
        {
            this.spec = spec;
        }

        public bool IsSatisfiedBy(T item)
        {
            return !spec.IsSatisfiedBy(item);
        }
    }
}
