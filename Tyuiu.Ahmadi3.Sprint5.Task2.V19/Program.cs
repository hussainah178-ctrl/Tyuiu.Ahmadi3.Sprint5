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

            // Создаем массив 3x3 как в задании
            int[,] matrix = new int[3, 3];

            Console.WriteLine("Введите элементы массива 3x3:");

            // Заполнение массива с клавиатуры
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Если нужно использовать готовый массив из задания:
            // int[,] matrix = new int[3, 3] 
            // {
            //     { 9, 2, 5 },
            //     { 8, 8, 2 },
            //     { 7, 4, 8 }
            // };

            Console.WriteLine();
            Console.WriteLine("Исходный массив:");
            PrintMatrix(matrix);

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            // Обрабатываем массив
            int[,] resultMatrix = ds.GetMatrix(matrix);

            Console.WriteLine("Массив после замены нечетных элементов на 0:");
            PrintMatrix(resultMatrix);

            // Сохраняем в файл
            string res = ds.SaveToFileData(resultMatrix);

            Console.WriteLine();
            Console.WriteLine("Файл: " + res);
            Console.WriteLine("Создан!");

            // Выводим содержимое файла
            Console.WriteLine();
            Console.WriteLine("Содержимое файла:");
            string fileContent = System.IO.File.ReadAllText(res);
            Console.WriteLine(fileContent.Replace(';', '\t'));

            Console.ReadKey();
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }
    }
}// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
