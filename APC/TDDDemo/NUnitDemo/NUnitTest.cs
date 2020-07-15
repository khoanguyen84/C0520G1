using NUnit.Framework;
using TDDDemo;

namespace NUnitDemo
{
    public class NUnitTest
    {
        private MyMath myMath;
        [SetUp]
        public void Setup()
        {
            myMath = new MyMath();
        }

        [Test]
        public void Additional_1()
        {
            Assert.AreEqual(10, myMath.Additional(3, 7));
        }
        [Test]
        public void Additional_2()
        {
            Assert.AreNotEqual(11, myMath.Additional(3, 7));
        }

        [TestCase(10)]
        [TestCase(0)]
        [TestCase(100)]
        public void Additional_3(int value)
        {
            Assert.IsTrue(myMath.Additional(value, 0) == value);
        }

        [TestCase(10)]
        [TestCase(0)]
        [TestCase(100)]
        public void Additional_4(int value)
        {
            Assert.IsFalse(myMath.Additional(value, 1) == value);
        }
    }
}
