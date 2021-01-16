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
    }
}
