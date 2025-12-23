using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi3.Sprint5.Task1.V7
{
    public class DataService:ISprint5Task1V7
    {
        public double CalcFunction(double x)
        {
            // Проверка деления на ноль
            if (Math.Abs(x + 1) < 0.0001) // x + 1 == 0
                return 0;

            double sinX = Math.Sin(x);
            double term1 = sinX / (x + 1);
            double term2 = sinX * 2;
            double result = term1 - term2 - 2 * x;

            return Math.Round(result, 2);
        }

        public string SaveToFile(int startValue, int stopValue)
        {
            string tempFilePath = Path.GetTempFileName();
            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                writer.WriteLine("Табулирование функции F(x) на интервале [{0}, {1}] с шагом 1", startValue, stopValue);
                writer.WriteLine("{0,10} {1,10}", "x", "F(x)");

                for (int x = startValue; x <= stopValue; x++)
                {
                    double y = CalcFunction(x);
                    writer.WriteLine("{0,10} {1,10:F2}", x, y);
                }
            }

            return tempFilePath;
        }

        public string SaveToFileTextData(int startValue, int stopValue)
        {
            throw new NotImplementedException();
        }
    }
}