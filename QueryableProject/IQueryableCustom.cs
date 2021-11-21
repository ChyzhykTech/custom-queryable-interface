using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QueryableProject
{

    /// <summary>
    /// Custom interface like <see cref="IQueryable{T}"/>
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public interface IQueryableCustom<out TSource> : IEnumerable<TSource>
    {
        /// <summary>
        /// Query description.
        /// Real <see cref="IQueryable{T}"/> uses <see cref="Expression{TDelegate}"/>
        /// </summary>
        string QueryDescription { get; }

        /// <summary>
        /// Creates new query and put it into QueryDescription
        /// </summary>
        /// <param name="queryDescription"></param>
        /// <returns></returns>
        IQueryableCustom<TSource> CreateNewQueryable(string queryDescription);

        /// <summary>
        /// Executes query on the data provider
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        TResult Execute<TResult>();
    }
}
