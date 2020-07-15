using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDDemo;

namespace MSTestDemo
{
    [TestClass]
    public class MSTest
    {
        private MyMath myMath;
        [TestMethod]
        public void Multiple_1()
        {
            myMath = new MyMath();
            Assert.AreEqual(100, myMath.Multiple(10, 10));
        }
    }
}
