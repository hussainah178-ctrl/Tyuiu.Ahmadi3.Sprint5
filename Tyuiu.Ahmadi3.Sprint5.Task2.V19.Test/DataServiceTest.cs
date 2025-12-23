using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Tyuiu.Ahmadi3.Sprint5.Task2.V19.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            DataService ds = new DataService();

            int[,] matrix = new int[3, 3]
            {
                { 9, 2, 5 },
                { 8, 8, 2 },
                { 7, 4, 8 }
            };

            int[,] res = ds.LoadFromDataFile(matrix);
            int[,] wait = new int[3, 3]
            {
                { 0, 2, 0 },
                { 8, 8, 2 },
                { 0, 4, 8 }
            };

            CollectionAssert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            DataService ds = new DataService();

            int[,] matrix = new int[3, 3]
            {
                { 0, 2, 0 },
                { 8, 8, 2 },
                { 0, 4, 8 }
            };

            string path = ds.SaveToFileTextData(matrix);

            bool fileExists = File.Exists(path);
            Assert.AreEqual(true, fileExists);

            string fileContent = File.ReadAllText(path);

            // Проверяем наличие ожидаемых строк
            Assert.IsTrue(fileContent.Contains("0;2;0"));
            Assert.IsTrue(fileContent.Contains("8;8;2"));
            Assert.IsTrue(fileContent.Contains("0;4;8"));

            // Удаляем файл после теста
            File.Delete(path);
        }
    }
}