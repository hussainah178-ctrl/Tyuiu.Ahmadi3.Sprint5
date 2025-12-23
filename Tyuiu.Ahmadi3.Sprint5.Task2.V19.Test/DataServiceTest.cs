using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

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

            // Проверяем каждый элемент
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(wait[i, j], res[i, j]);
                }
            }
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

            // Проверяем, что файл создан
            Assert.IsTrue(File.Exists(path), $"Файл {path} не найден!");

            // Читаем содержимое файла
            string fileContent = File.ReadAllText(path);

            // Удаляем все переносы строк для сравнения
            string cleanContent = fileContent.Replace("\r\n", "").Replace("\n", "");

            // Ожидаемый результат (ВСЕ В ОДНУ СТРОКУ)
            string expected = "0;2;0;8;8;2;0;4;8";

            Assert.AreEqual(expected, cleanContent);

            // Проверяем, что нет лишних символов
            Assert.IsFalse(fileContent.Contains("["));
            Assert.IsFalse(fileContent.Contains("]"));
            Assert.IsFalse(fileContent.Contains(","));

            // Удаляем файл после теста
            File.Delete(path);
        }
    }
}