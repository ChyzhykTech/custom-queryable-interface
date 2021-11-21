using System;
using System.Collections;
using System.Collections.Generic;

namespace QueryableProject
{
    /// <summary>
    /// <inheritdoc cref="IQueryableCustom{TSource}"/>
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class FakeQueryableCustom<TSource> : IQueryableCustom<TSource>
    {
        private readonly object _dataSource;
        public string QueryDescription { get; private set; }

        public FakeQueryableCustom(string queryDescription, object dataSource)
        {
            _dataSource = dataSource;
            QueryDescription = queryDescription;
        }

        public IQueryableCustom<TSource> CreateNewQueryable(string queryDescription)
        {
            return new FakeQueryableCustom<TSource>(queryDescription, _dataSource);
        }

        public TResult Execute<TResult>()
        {
            // Handling QueryDescription and apply query to dataSource
            throw new NotImplementedException();
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return Execute<IEnumerator<TSource>>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
