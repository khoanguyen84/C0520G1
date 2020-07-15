using System;
using TDDDemo;
using Xunit;

namespace XUnitDemo
{
    public class XUnitTest
    {
        MathDemo mathDemo;
        public XUnitTest()
        {
            mathDemo = new MathDemo();
        }
        [Fact]
        public void Subtract_1()
        {
            Assert.Equal(5, mathDemo.Subtract(7, 2));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(0)]
        public void Subtract_2(int value)
        {
            Assert.Equal(value, mathDemo.Subtract(value, 0));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(0)]
        public void Subtract_3(int value)
        {
            Assert.NotEqual(value, mathDemo.Subtract(value, 1));
        }
    }
}
