using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Linq
{
    public static partial class IEnumerable
    {
        public static IEnumerable<TResult> Empty<TResult>()
        {
            return EmptyHolder<TResult>.Array;
        }
        private static class EmptyHolder<T>
        {
            internal static readonly T[] Array = new T[0];
        }
    }
}
