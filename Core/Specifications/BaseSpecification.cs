using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.BaseSpecifications;

public class BaseSpecification<T> (Expression<Func<T, bool>> criteria): ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria => criteria;
}
