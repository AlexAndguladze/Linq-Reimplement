using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Linq.Test
{
    [TestFixture]
    public class RepeatTest
    {
        [Test]
        public void RepeatThreeStrings()
        {
            IEnumerable<string> strings1 = Alex.Linq.IEnumerable.Repeat("Alex", 3);
            IEnumerable<string> strings2 = new List<string>() { "Alex", "Alex", "Alex" };
            Assert.AreEqual(strings1, strings2);
        }
        [Test]
        public void RepeatReturnsEmptySequence()
        {
            IEnumerable<string> strings = Alex.Linq.IEnumerable.Repeat("Alex", 0);
            Assert.IsEmpty(strings);
        }
        [Test]
        public void RepeatCountCantBeNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Alex.Linq.IEnumerable.Repeat("Alex", -3));
        }
    }
}
