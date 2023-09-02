using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Linq
{
    public static partial class IEnumerable
    {
        public static IEnumerable<int> Range(int start, int count)
        {
            if(count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            if((long)start + (long)count -1L > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            return RangeImpl(start, count);
        }

        private static IEnumerable<int> RangeImpl(int start, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }
    }
}
