namespace Common.Tools.Filter
{
    public interface ISpecification<T>
    { 
        bool IsSatisfiedBy(T item); 
    }

}
