using System;
using System.Linq.Expressions;

namespace QueryableProject
{
    /// <summary>
    /// Custom implementation of LINQ methods for <see cref="IQueryableCustom{TSource}"/>
    /// </summary>
    public static class QueryableCustomExtensions
    {

        /// <summary>
        /// Where custom LINQ expression
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryableCustom<TSource> Where<TSource>(this IQueryableCustom<TSource> queryable,
            Expression<Func<TSource, bool>> predicate)
        {
            string newQueryDescription = queryable.QueryDescription + ".Where(" + predicate.ToString() + ")";
            return queryable.CreateNewQueryable(newQueryDescription);
        }

        /// <summary>
        /// OrderBy custom LINQ expression
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryableCustom<TSource> OrderBy<TSource>(this IQueryableCustom<TSource> queryable,
            Expression<Func<TSource, bool>> predicate)
        {
            string newQueryDescription = queryable.QueryDescription + ".OrderBy(" + predicate.ToString() + ")";
            return queryable.CreateNewQueryable(newQueryDescription);
        }

        /// <summary>
        /// Count custom LINQ expression.
        /// Has aggregation role.
        /// Trig of this extension method runs query execution for <see cref="IQueryableCustom{TSource}"/> 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="queryable"></param>
        /// <returns></returns>
        public static int Count<TSource>(this IQueryableCustom<TSource> queryable)
        {
            string newQueryDescription = queryable.QueryDescription + ".Count()";
            IQueryableCustom<TSource> newQueryable = queryable.CreateNewQueryable(newQueryDescription);
            return newQueryable.Execute<int>();
        }
    }
}
