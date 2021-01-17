using System;
using System.Text;
using Tasks;
using NUnit.Framework;

namespace Tests
{
    class TestTasks802_821
    {
        private Tasks802_821 _tasks802821;

        [SetUp]
        public void SetUp()
        {
            _tasks802821 = new Tasks802_821();
        }

        [TestCase("abcd   1 12  b1234", 4)]
        public void Test802(string text, int expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task802(text));
        }

        [TestCase("abcd  sdfsf", false)]
        [TestCase("abcd 3 sdfsf", true)]
        public void Test803(string text, bool expectedResutl)
        {
            Assert.AreEqual(expectedResutl, _tasks802821.Task803(text));
        }

        [TestCase("abcd  123* abc 123", "3333  123* abc 123")]
        [TestCase("abcd 123", "abcd 123")]
        public void Test804A(string text, string expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task804A(text));
        }

        [TestCase("1234   -=+", "1234   -=+")]
        [TestCase("1234 abcd  123", "1234 abcd.....")]
        [TestCase("a12345", "a.....")]
        public void Test805(string text, string expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task805(text));
        }

        [TestCase(1234, "1 234")]
        [TestCase(123, "123")]
        [TestCase(12345, "12 345")]
        [TestCase(123456, "123 456")]
        public void Test809(int n, string expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task809(n));
        }

        [TestCase("abcd+-one", true)]
        [TestCase("abconde", false)]
        [TestCase("one", true)]
        public void Test812A(string text, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task812A(text));
        }

        [TestCase("abc12+-ab1++", false)]
        public void Test812B(string text, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task812B(text));
        }

        [TestCase("abc12+-*bcd", "abc12123bcd")]
        [TestCase("abc12+-=", "abc12+-=")]
        [TestCase("+-=abc", "+-=abc")]
        [TestCase("abc+-*a", "abc123a")]
        [TestCase("a+-*b", "a123b")]
        public void Test812C(string text, string expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task812C(text));
        }

        [TestCase("fac+-ac+-*fff123ffffff", 4)]
        [TestCase("a12bc34f", 1)]
        [TestCase("a12bc23a+f", 0)]
        public void Test812D(string text, int expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task812D(text));
        }

        [TestCase("a", 1)]
        [TestCase("aba11a", 2)]
        [TestCase("aba11aba", 2)]
        [TestCase("a1a1a1a", 4)]
        [TestCase("1a1aba1", 2)]
        [TestCase("", 0)]
        [TestCase("ab", 0)]
        [TestCase("aba", 1)]
        public void Test812E(string text, int expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task812E(text));
        }

        [TestCase("a", new string[] {})]
        [TestCase("aa", new[] { "aa"})]
        [TestCase("aa1aa", new[] { "aa", "aa"})]
        [TestCase("", new string[] { })]
        public void Test812F(string text, string[] expectedResult)
        {
            Assert.IsTrue(IsEqualArrays(expectedResult, _tasks802821.Task812F(text)));
        }

        [TestCase("1", "1")]
        [TestCase("1a2", "1")]
        [TestCase("1a12", "12")]
        [TestCase("12a1", "12")]
        [TestCase("123", "123")]
        public void Test812G(string text, string expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task812G(text));
        }

        [TestCase("123adfsb+-*", "123adfsb+-*")]
        [TestCase("a+-1234", "a+-1234")]
        [TestCase("a1234+123adsf", "a****+123adsf")]
        [TestCase("a1", "a*")]
        [TestCase("a111", "a***")]
        public void Test813(string text, string expectedResult)
        {
            Assert.AreEqual(expectedResult, _tasks802821.Task813(text));
        }

        bool IsEqualArrays(string[] first, string[] second)
        {
            if (first.Length != second.Length)
                return false;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                    return false;
            }
            return true;
        }
    }
}
