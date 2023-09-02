using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Linq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector
            )
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }
            if(selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            return SelectImpl<TSource, TResult>(source, selector);

        }
        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector
            )
        {
            foreach(var item in source)
            {
                yield return selector(item);
            }
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector
            )
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }
            if(selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            return SelectImpl<TSource, TResult>(source, selector);
        }
        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(
           this IEnumerable<TSource> source,
           Func<TSource, int, TResult> selector
           )
        {
            int index = 0;
            foreach(TSource item in source)
            {
                yield return selector(item, index);
                index++;
            }
        }
    }
}
