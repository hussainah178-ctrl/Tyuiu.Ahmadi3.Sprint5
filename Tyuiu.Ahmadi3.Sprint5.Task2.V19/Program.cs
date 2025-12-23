using System;

namespace Tyuiu.Ahmadi3.Sprint5.Task2.V19
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Массив из задания
            int[,] mtrx = new int[3, 3]
            {
                { 9, 2, 5 },
                { 8, 8, 2 },
                { 7, 4, 8 }
            };

            Console.WriteLine("Массив:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{mtrx[i, j]} \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            // Получаем обработанный массив
            int[,] res = ds.LoadFromDataFile(mtrx);

            Console.WriteLine("Массив после замены нечетных элементов на 0:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{res[i, j]} \t");
                }
                Console.WriteLine();
            }

            // Сохраняем в файл
            string path = ds.SaveToFileTextData(res);

            Console.WriteLine();
            Console.WriteLine("Данные сохранены в файл: " + path);

            // Читаем и выводим содержимое файла
            Console.WriteLine();
            Console.WriteLine("Содержимое файла:");
            string fileContent = File.ReadAllText(path);
            Console.WriteLine(fileContent.Replace(";", "\t"));

            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}