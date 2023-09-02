using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //A simple valid range should look right when tested with AssertSequenceEqual
    //The start value should be allowed to be negative
    //Range(Int32.MaxValue, 1) yields just Int32.MaxValue
    //Range(Int32.MinValue, 0) is an empty range
    //The count can’t be negative
    //The count can be zero
    //start+count-1 can’t exceed Int32.MaxValue (so Range(Int32.MaxValue, 2) isn’t valid)
    //start + count - 1 can be Int32.MaxValue (so Range(Int32.MaxValue, 1) is valid)

namespace Alex.Linq.Test
{
    [TestFixture]
    public class RangeTest
    {
        [Test]
        public void SimpleValidRange()
        {
            IEnumerable<int> range = Alex.Linq.IEnumerable.Range(4, 3);
            IEnumerable<int> range2 = new int[] {4,5,6};
            Assert.AreEqual(range, range2);
        }
        [Test]
        public void StartValueAllowedToBeNegative()
        {
            int negativeStart = -4;
            IEnumerable<int> range = Alex.Linq.IEnumerable.Range(negativeStart, 3);
            IEnumerable<int> range2 = new int[] { -4, -3, -2 };
            Assert.Negative(negativeStart);
            Assert.AreEqual(range, range2);
        }
        [Test]
        public void RangeReturnsMaxValue()
        {
            IEnumerable<int> range = Alex.Linq.IEnumerable.Range(int.MaxValue, 1);
            IEnumerable<int> range2 = new int[] { int.MaxValue };
            Assert.AreEqual(range.Count(), 1);
            Assert.AreEqual(range, range2);
        }
        [Test]
        public void RangeReturnsEmptyRange()
        {
            IEnumerable<int> range = Alex.Linq.IEnumerable.Range(int.MinValue, 0);
            IEnumerable<int> range2 = new int[0];
            Assert.AreEqual(range, range2);
        }
        [Test]
        public void NegativeCountThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()=>Alex.Linq.IEnumerable.Range(2, -1),"count");
        }
    }
    
}
