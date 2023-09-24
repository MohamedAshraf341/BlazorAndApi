namespace Common.Tools.Filter
{
    public class OrSpecification<T> : ISpecification<T>
    {
        private ISpecification<T>[] parameters;

        public OrSpecification(params ISpecification<T>[] parameters)
        {
            this.parameters = parameters;
        }

        public bool IsSatisfiedBy(T item)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.IsSatisfiedBy(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
