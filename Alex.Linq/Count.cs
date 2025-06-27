using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Linq
{
    public static partial class IEnumerable
    {
        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) 
        {
            if (source==null)
            {
                throw new ArgumentNullException("source");
            }
            if(predicate==null)
            {
                throw new ArgumentNullException("predicate");
            }
            checked
            {
                int count = 0;
                foreach (var item in source)
                {
                    if(predicate(item))
                        count++;
                }
                return count;
            }
        }
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source==null)
            {
                throw new ArgumentNullException("source");
            }
            ICollection<TSource> genericCollection = source as ICollection<TSource>;
            if (genericCollection != null) 
            {
                return genericCollection.Count;
            }
            ICollection nonGenericCollection = source as ICollection;
            if(nonGenericCollection != null)
            {
                return nonGenericCollection.Count;
            }
            checked
            {
                int count = 0;
                foreach(var item in source)
                {
                    count++;
                }
                return count;
            }
        }

    }
}
