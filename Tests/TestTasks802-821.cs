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
    }
}
