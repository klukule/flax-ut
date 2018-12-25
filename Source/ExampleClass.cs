﻿#if !FLAX_PLUGIN
using FlaxEngine.UnitTesting;

namespace UnitTests
{
    [TestFixture]
    internal class SimpleTests
    {
        [Test]
        public void SuccessTest()
        {
            // Do nothing for success
        }

        [Test]
        public void ErrorTest()
        {
            Assert.True(null != null);
        }
    }

    [TestFixture]
    internal class SetupTests
    {
        private object Tested = null;

        [SetUp]
        public void Setup()
        {
            Tested = "Test";
        }

        [Test]
        public void SetupTest()
        {
            Assert.AreEqual(Tested, "Test");
        }

        [TearDown]
        public void Dispose()
        {
        }
    }

    [TestFixture]
    internal class CaseTests
    {
        // Just a bunch of test cases :)
        [TestCase(0, 5)]
        [TestCase(1, 4)]
        [TestCase(2, 3)]
        [TestCase(3, 2)]
        [TestCase(4, 1)]
        [TestCase(5, 0)]
        public void TestCaseTest(int a, int b)
        {
            Assert.True(a + b == 5);
        }

        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(10, 5, ExpectedResult = 15)]
        public int ExpectedResultsTests(int a, int b)
        {
            return a + b;
        }
    }
}
#endif