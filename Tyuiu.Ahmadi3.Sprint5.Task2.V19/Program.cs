using System;

namespace Tyuiu.Ahmadi3.Sprint5.Task2.V19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Массив из задания
            int[,] matrix = new int[3, 3]
            {
                { 9, 2, 5 },
                { 8, 8, 2 },
                { 7, 4, 8 }
            };

            Console.WriteLine("Массив 3x3:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();

            // Обрабатываем массив
            int[,] resultMatrix = ds.LoadFromDataFile(matrix);

            Console.WriteLine("Массив после замены нечетных элементов на 0:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{resultMatrix[i, j]}\t");
                }
                Console.WriteLine();
            }

            // Сохраняем в файл
            string filePath = ds.SaveToFileTextData(resultMatrix);

            Console.WriteLine();
            Console.WriteLine($"Результат сохранен в файл: {filePath}");

            // Выводим содержимое файла
            Console.WriteLine("Содержимое файла:");
            string fileContent = System.IO.File.ReadAllText(filePath);
            Console.WriteLine(fileContent);

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}