using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Tyuiu.Ahmadi3.Sprint5.Task1.V7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckCalcFunction()
        {
            DataService ds = new DataService();
            double res = ds.CalcFunction(0);
            // Пример ожидаемого значения для x=0:
            // sin(0) = 0, значит term1 = 0/(0+1)=0, term2 = 0, result = 0 - 0 - 0 = 0
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void CheckCalcFunctionDivisionByZero()
        {
            DataService ds = new DataService();
            double res = ds.CalcFunction(-1);
            // x = -1 -> деление на ноль, должно вернуть 0
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void ValidSaveToFile()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFile(0, 5);
            Assert.IsTrue(File.Exists(path));

            string fileContent = File.ReadAllText(path);
            Assert.IsTrue(fileContent.Contains("F(x)"));

            File.Delete(path);
        }
    }
}