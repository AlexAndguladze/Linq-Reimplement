using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Linq
{
    public static partial class IEnumerable
    {
        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            if(count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            return RepeatImpl(element, count);
        }
        private static IEnumerable<TResult> RepeatImpl<TResult>(TResult element, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return element;
            }
        }
    }
}
