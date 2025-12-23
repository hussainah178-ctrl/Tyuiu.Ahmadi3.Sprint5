using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Tyuiu.Ahmadi3.Sprint5.Task2.V19.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckGetMatrix()
        {
            DataService ds = new DataService();

            // Исходный массив из задания
            int[,] matrix = new int[3, 3]
            {
                { 9, 2, 5 },
                { 8, 8, 2 },
                { 7, 4, 8 }
            };

            int[,] result = ds.GetMatrix(matrix);

            // Проверяем размеры
            Assert.AreEqual(3, result.GetLength(0));
            Assert.AreEqual(3, result.GetLength(1));

            // Проверяем замену нечетных на 0
            Assert.AreEqual(0, result[0, 0]); // 9 → 0
            Assert.AreEqual(2, result[0, 1]); // 2 → 2
            Assert.AreEqual(0, result[0, 2]); // 5 → 0
            Assert.AreEqual(8, result[1, 0]); // 8 → 8
            Assert.AreEqual(8, result[1, 1]); // 8 → 8
            Assert.AreEqual(2, result[1, 2]); // 2 → 2
            Assert.AreEqual(0, result[2, 0]); // 7 → 0
            Assert.AreEqual(4, result[2, 1]); // 4 → 4
            Assert.AreEqual(8, result[2, 2]); // 8 → 8
        }

        [TestMethod]
        public void CheckSaveToFileData()
        {
            DataService ds = new DataService();

            // Обработанный массив (нечетные заменены на 0)
            int[,] matrix = new int[3, 3]
            {
                { 0, 2, 0 },
                { 8, 8, 2 },
                { 0, 4, 8 }
            };

            string path = ds.SaveToFileData(matrix);

            // Проверяем создание файла
            Assert.IsTrue(File.Exists(path), $"Файл {path} не найден!");

            // Проверяем содержимое файла
            string fileContent = File.ReadAllText(path);

            // Ожидаемый формат CSV с разделителем ";"
            string expectedLine1 = "0;2;0";
            string expectedLine2 = "8;8;2";
            string expectedLine3 = "0;4;8";

            Assert.IsTrue(fileContent.Contains(expectedLine1));
            Assert.IsTrue(fileContent.Contains(expectedLine2));
            Assert.IsTrue(fileContent.Contains(expectedLine3));

            // Проверяем разделитель
            Assert.IsTrue(fileContent.Contains(";"));

            // Удаляем файл после теста
            File.Delete(path);
        }
    }
}