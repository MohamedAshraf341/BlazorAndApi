using System.Collections.Generic;

namespace Common.Tools.Filter
{
    public class Filter<T> 
    { 
        public List<T> FilterBy(List<T> items, ISpecification<T> spec) 
        {
            List<T> result = new List<T>(); 
            foreach (T item in items) 
            { 
                if (spec.IsSatisfiedBy(item)) 
                {
                    result.Add(item); 
                } 
            } 
            return result; 
        } 
    }
}
