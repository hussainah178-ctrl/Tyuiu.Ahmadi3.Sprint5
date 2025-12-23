using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tyuiu.Ahmadi3.Sprint5.Task1.V7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckGetMassFunction()
        {
            DataService ds = new DataService();

            int startValue = -5;
            int stopValue = 5;

            double[] result = ds.GetMassFunction(startValue, stopValue);

            // Проверяем количество элементов
            Assert.AreEqual(11, result.Length);

            // Проверяем конкретные значения (x = -1 должно быть 0 из-за деления на ноль)
            Assert.AreEqual(0, result[4]); // x = -1 (индекс 4: -5, -4, -3, -2, -1)

            // Проверяем округление до 2 знаков
            foreach (double value in result)
            {
                string strValue = value.ToString("F2");
                double roundedValue = Math.Round(value, 2);
                Assert.AreEqual(roundedValue, value, 0.001);
            }
        }

        [TestMethod]
        public void CheckSaveToFile()
        {
            DataService ds = new DataService();

            string path = ds.SaveToFile(-5, 5);

            // Проверяем, что файл создан
            Assert.IsTrue(File.Exists(path), $"Файл {path} не найден!");

            // Проверяем содержимое файла
            string fileContent = File.ReadAllText(path);

            Assert.IsTrue(fileContent.Contains("Табулирование"));
            Assert.IsTrue(fileContent.Contains("x"));
            Assert.IsTrue(fileContent.Contains("F(x)"));

            // Проверяем наличие всех значений от -5 до 5
            for (int x = -5; x <= 5; x++)
            {
                Assert.IsTrue(fileContent.Contains(x.ToString()));
            }

            // Проверяем, что есть значения с двумя знаками после запятой
            Assert.IsTrue(fileContent.Contains(".00") || fileContent.Contains(".01") ||
                         fileContent.Contains(".02") || fileContent.Contains(".99"));

            // Удаляем файл после теста
            File.Delete(path);
        }
    }
}