using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tyuiu.Ahmadi3.Sprint5.Task1.V7.DataService ds = new Tyuiu.Ahmadi3.Sprint5.Task1.V7.DataService();

            int startValue = -5;
            int stopValue = 5;

            Console.WriteLine("Табулирование функции F(x) на интервале [{0}, {1}] с шагом 1", startValue, stopValue);
            Console.WriteLine("{0,10} {1,10}", "x", "F(x)");

            for (int x = startValue; x <= stopValue; x++)
            {
                double y = ds.CalcFunction(x);
                Console.WriteLine("{0,10} {1,10:F2}", x, y);
            }

            string resultFilePath = ds.SaveToFile(startValue, stopValue);
            Console.WriteLine("\nФайл с результатами сохранён по пути:");
            Console.WriteLine(resultFilePath);
            Console.ReadKey();
        }
    }
}