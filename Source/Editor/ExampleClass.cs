﻿#if !FLAX_PLUGIN
using System.Collections.Generic;
using FlaxCommunity.UnitTesting.Editor;
using FlaxEngine;

namespace UnitTests.Editor
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
            Assert.True(1 != 1);
        }
    }

    [TestFixture]
    internal class SetupTests
    {
        private object Tested = null;
        private object Database = null;

        [OneTimeSetUp]
        public void Init()
        {
            Database = new object { };
        }

        [SetUp]
        public void BeforeEach()
        {
            Tested = "Test";
        }

        [Test]
        public void SetupTest()
        {
            Assert.AreEqual(Tested, "Test");
        }

        [TearDown]
        public void AfterEach()
        {
        }

        public void Dispose()
        {
            Database = null;
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

        public IEnumerable<TestCaseData> AddVectorsTestCases()
        {
            yield return new TestCaseData(new Vector2(0, 0), new Vector2(0, 0)).Returns(new Vector2(0, 0));
            yield return new TestCaseData(new Vector2(3, 5), new Vector2(1, 1)).Returns(new Vector2(4, 6));
            yield return new TestCaseData(new Vector2(1, 2), new Vector2(-1, -3)).Returns(new Vector2(0, -1));
        }

        [TestCaseSource(nameof(AddVectorsTestCases))]
        public Vector2 AddVectorsTests(Vector2 a, Vector2 b)
        {
            return a + b;
        }
    }
}
#endif