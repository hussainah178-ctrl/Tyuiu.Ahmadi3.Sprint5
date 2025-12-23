using System;
using System.IO;
using System.Globalization;
using Tyuiu.Ahmadi3.Sprint5.Task5.V22.Lib;

namespace Tyuiu.Ahmadi3.Sprint5.Task5.V22
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();
            double x = 3;
            double result = ds.Calculate(x);
            result = Math.Round(result, 3);

            // ✅ استفاده از فرهنگ روسی برای ویرگول
            CultureInfo culture = new CultureInfo("ru-RU");
            string resultWithComma = result.ToString("F3", culture);

            // ✅ قرار دادن داخل گیومه
            string quotedResult = "\"" + resultWithComma + "\"";

            Console.WriteLine(quotedResult);

            string tempPath = Path.GetTempPath();
            string outputFile = Path.Combine(tempPath, "OutPutFileTask0.txt");

            File.WriteAllText(outputFile, quotedResult);

            Console.ReadKey();
        }
    }
}