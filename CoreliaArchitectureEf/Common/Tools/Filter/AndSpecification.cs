namespace Common.Tools.Filter
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T>[] parameters;

        public AndSpecification(params ISpecification<T>[] parameters)
        {
            this.parameters = parameters;
        }

        public bool IsSatisfiedBy(T item)
        {
            foreach (var parameter in parameters)
            {
                if (!parameter.IsSatisfiedBy(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
