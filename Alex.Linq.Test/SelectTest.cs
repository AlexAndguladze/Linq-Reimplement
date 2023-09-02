using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Alex.Linq.Test
{
    [TestFixture]
    public class SelectTest
    {
        [Test]
        public void SimpleProjectionToDifferentType()
        {
            int[] source = { 1, 5, 2 };
            var result = source.Select(x => x.ToString());
            result.AssertSequenceEqual("1", "5", "2");
        }

        [Test]
        public void WhereAndSelect()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = from x in source
                         where x < 4
                         select x * 2;
            result.AssertSequenceEqual(2, 6, 4, 2);
        }
        [Test]
        public void SelectSubstringWithIndexLength()
        {
            string[] words = { "Banana", "Mango", "Potato", "Strawberry" };
            var result = words.Select((word, index)=> word.Substring(0,index));
            result.AssertSequenceEqual("", "M", "Po", "Str");
        }
    }
}
