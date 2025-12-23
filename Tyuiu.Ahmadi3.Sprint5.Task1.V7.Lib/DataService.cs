using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi3.Sprint5.Task1.V7
{
    public class DataService :ISprint5Task1V7
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int len = stopValue - startValue + 1;
            double[] valueArray = new double[len];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                // Проверка деления на ноль
                if (x + 1 == 0)
                {
                    valueArray[count] = 0;
                }
                else
                {
                    double sinX = Math.Sin(x);
                    double term1 = sinX / (x + 1);
                    double term2 = sinX * 2;
                    double result = term1 - term2 - 2 * x;

                    // Округление ДО сохранения в массив
                    valueArray[count] = Math.Round(result, 2);
                }
                count++;
            }

            return valueArray;
        }

        public string SaveToFile(int startValue, int stopValue)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\OutPutFileTask1.txt";

            double[] values = GetMassFunction(startValue, stopValue);

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("Табулирование функции F(x) = sin(x)/(x+1) - sin(x)*2 - 2x");
                writer.WriteLine($"на интервале [{startValue}, {stopValue}] с шагом 1");
                writer.WriteLine();
                writer.WriteLine("{0,5} {1,10}", "x", "F(x)");
                writer.WriteLine("-------------------");

                int count = 0;
                for (int x = startValue; x <= stopValue; x++)
                {
                    writer.WriteLine("{0,5} {1,10:F2}", x, values[count]);
                    count++;
                }
            }

            return path;
        }

        public string SaveToFileTextData(int startValue, int stopValue)
        {
            throw new NotImplementedException();
        }
    }
}