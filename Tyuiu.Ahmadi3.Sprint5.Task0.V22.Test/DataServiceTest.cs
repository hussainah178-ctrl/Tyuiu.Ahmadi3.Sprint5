
using Tyuiu.Ahmadi3.Sprint5.Task5.V22.Lib;

namespace Tyuiu.Ahmadi3.Sprint5.Task5.V22.Test
{
    public class DataServiceTest
    {
        [Fact]
        public void ValidCalculate()
        {
            DataService ds = new DataService();
            double x = 3;
            double result = ds.Calculate(x);
            double expected = Math.Round(Math.Pow(1 - x, 2) / (-3 * x), 3);
            Assert.Equals(expected, result);
        }

        [Fact]
        public void InvalidCalculate_DivideByZero()
        {
            DataService ds = new DataService();
            Assert.ThrowsException<DivideByZeroException>(() => ds.Calculate(0));
        }
    }
}